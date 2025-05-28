//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IFolderService
{

    void CopyObject(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    Folder? AddObject(Folder folderObject, string folderName);

    Folder? GetObject(Folder folderObject);

    Folder? GetObject(List listObject);

    Folder? GetObject(ListItem listItemObject);

    Folder? GetObject(Guid folderId);

    Folder? GetObject(Uri folderUrl);

    Folder? GetObject(Folder folderObject, string folderName);

    IEnumerable<Folder>? GetObjectEnumerable();

    IEnumerable<Folder>? GetObjectEnumerable(Folder folderObject);

    void MoveObject(Folder folderObject, Uri folderUrl);

    void MoveObject(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    );

    Guid RecycleObject(Folder folderObject);

    void RemoveObject(Folder folderObject);

    void SetObject(Folder folderObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class FolderService(ClientContext clientContext) : ClientService<Folder>(clientContext), IFolderService
{

    public void CopyObject(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    )
    {
        var serverRelativeUrl = folderObject.ServerRelativeUrl;
        _ = serverRelativeUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(MoveCopyUtil),
                "CopyFolder",
                requestPayload.CreateParameter(
                    new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority))
                        .ConcatPath(serverRelativeUrl.ToString())
                ),
                requestPayload.CreateParameter(folderUrl),
                requestPayload.CreateParameter(ClientValueObject.Create<MoveCopyOptions>(moveCopyOptions))
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public Folder? AddObject(Folder folderObject, string folderName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Folders"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(folderName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(List listObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "RootFolder"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(ListItem listItemObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Folder"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(Guid folderId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetFolderById",
                requestPayload.CreateParameter(folderId)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(Uri folderUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetFolderByServerRelativeUrl",
                requestPayload.CreateParameter(folderUrl)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public Folder? GetObject(Folder folderObject, string folderName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Folders"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByUrl",
                requestPayload.CreateParameter(folderName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Folder)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Folder>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Folder>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "Folders"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FolderEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<Folder>? GetObjectEnumerable(Folder folderObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(folderObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Folders"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Folder))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FolderEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void MoveObject(Folder folderObject, Uri folderUrl)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(folderObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "MoveTo",
                requestPayload.CreateParameter(folderUrl)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void MoveObject(
        Folder folderObject,
        Uri folderUrl,
        IReadOnlyDictionary<string, object?> moveCopyOptions
    )
    {
        var serverRelativeUrl = folderObject.ServerRelativeUrl;
        _ = serverRelativeUrl ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestPayload = new ClientRequestPayload();
        requestPayload.Actions.Add(
            ClientActionStaticMethod.Create(
                typeof(MoveCopyUtil),
                "MoveFolder",
                requestPayload.CreateParameter(
                    new Uri(this.ClientContext.BaseAddress.GetLeftPart(UriPartial.Authority))
                        .ConcatPath(serverRelativeUrl.ToString())
                ),
                requestPayload.CreateParameter(folderUrl),
                requestPayload.CreateParameter(ClientValueObject.Create<MoveCopyOptions>(moveCopyOptions))
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public Guid RecycleObject(Folder folderObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(folderObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "Recycle")
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<Guid>(requestPayload.GetActionId<ClientActionMethod>());
    }

}
