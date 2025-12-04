//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISitePageService
{

    void AddObject(
        Folder folderObject,
        string pageName,
        SitePageLayoutType pageLayoutType
    );

    void RemoveObject(Folder folderObject, string pageName);

    void SetObject(
        Folder folderObject,
        string pageName,
        IReadOnlyDictionary<string, object?> modificationInfo
    );

}

public class SitePageService(ClientContext clientContext) : ClientService(clientContext), ISitePageService
{

    public void AddObject(
        Folder folderObject,
        string pageName,
        SitePageLayoutType pageLayoutType
    )
    {
        var fileName = System.IO.Path.ChangeExtension(pageName, ".aspx");
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Files"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "AddTemplateFile",
                requestPayload.CreateParameter($"{folderObject.ServerRelativeUrl}/{fileName}"),
                requestPayload.CreateParameter(TemplateFileType.ClientSidePage)
            )
        );
        var objectPath4 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath3.Id, "ListItemAllFields"),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("ClientSideApplicationId"),
                requestPayload.CreateParameter("b6917cb1-93a0-4b97-a84d-7cf49975d4ec")
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("ContentTypeId"),
                requestPayload.CreateParameter("0x0101009D1CB255DA76424F860D91F20E6C4118")
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("PageLayoutType"),
                requestPayload.CreateParameter(pageLayoutType.ToString())
            ),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValue",
                requestPayload.CreateParameter("Title"),
                requestPayload.CreateParameter(pageName)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObject(Folder folderObject, string pageName)
    {
        var fileName = System.IO.Path.ChangeExtension(pageName, ".aspx");
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Files"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByUrl",
                requestPayload.CreateParameter(fileName)
            )
        );
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteObject"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(
        Folder folderObject,
        string pageName,
        IReadOnlyDictionary<string, object?> modificationInfo
    )
    {
        var fileName = System.IO.Path.ChangeExtension(pageName, ".aspx");
        var requestPayload = new ClientRequestPayload();
        var pageLayoutType = modificationInfo["PageLayoutType"]
            ?.ToString();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Files"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByUrl",
                requestPayload.CreateParameter(fileName)
            )
        );
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "ListItemAllFields"));
        if (modificationInfo.ContainsKey("PageLayoutType"))
        {
            var objectPath5 = requestPayload.Add(
                objectPath4,
                objectPathId => ClientActionMethod.Create(
                    objectPathId,
                    "SetFieldValue",
                    requestPayload.CreateParameter("PageLayoutType"),
                    requestPayload.CreateParameter(pageLayoutType)
                )
            );
        }
        if (modificationInfo.ContainsKey("Title"))
        {
            var objectPath5 = requestPayload.Add(
                objectPath4,
                objectPathId => ClientActionMethod.Create(
                    objectPathId,
                    "SetFieldValue",
                    requestPayload.CreateParameter("Title"),
                    requestPayload.CreateParameter(modificationInfo["Title"])
                )
            );
        }
        var objectPath6 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
