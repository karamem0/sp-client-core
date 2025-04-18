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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IFileVersionService
{

    FileVersion GetObject(FileVersion fileVersionObject);

    FileVersion GetObject(File fileObject, int? fileVersionId);

    IEnumerable<FileVersion> GetObjectEnumerable(File fileObject);

    void RecycleObject(FileVersion fileVersionObject);

    void RemoveObject(FileVersion fileVersionObject);

    void RemoveObjectAll(File fileObject);

    void RestoreObject(FileVersion fileVersionObject);

}

public class FileVersionService(ClientContext clientContext) : ClientService<FileVersion>(clientContext), IFileVersionService
{

    public FileVersion GetObject(File fileObject, int? fileVersionId)
    {
        _ = fileObject ?? throw new ArgumentNullException(nameof(fileObject));
        _ = fileVersionId ?? throw new ArgumentNullException(nameof(fileVersionId));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(fileVersionId)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(FileVersion))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FileVersion>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<FileVersion> GetObjectEnumerable(File fileObject)
    {
        _ = fileObject ?? throw new ArgumentNullException(nameof(fileObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Versions"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = ClientQuery.Empty,
                ChildItemQuery = new ClientQuery(true, typeof(FileVersion))
            }
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<FileVersionEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RecycleObject(FileVersion fileVersionObject)
    {
        _ = fileVersionObject ?? throw new ArgumentNullException(nameof(fileVersionObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(
                string.Join(
                    ":",
                    fileVersionObject
                        .ObjectIdentity.Split(':')
                        .SkipLast(2)
                )
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId)
        );
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "RecycleByLabel",
                requestPayload.CreateParameter(fileVersionObject.VersionLabel)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public override void RemoveObject(FileVersion fileVersionObject)
    {
        _ = fileVersionObject ?? throw new ArgumentNullException(nameof(fileVersionObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(
                string.Join(
                    ":",
                    fileVersionObject
                        .ObjectIdentity.Split(':')
                        .SkipLast(2)
                )
            )
        );
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "DeleteByLabel",
                requestPayload.CreateParameter(fileVersionObject.VersionLabel)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RemoveObjectAll(File fileObject)
    {
        _ = fileObject ?? throw new ArgumentNullException(nameof(fileObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(fileObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(objectPath2, objectPathId => new ClientActionMethod(objectPathId, "DeleteAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void RestoreObject(FileVersion fileVersionObject)
    {
        _ = fileVersionObject ?? throw new ArgumentNullException(nameof(fileVersionObject));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathIdentity(
                string.Join(
                    ":",
                    fileVersionObject
                        .ObjectIdentity.Split(':')
                        .SkipLast(2)
                )
            )
        );
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Versions"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "RestoreByLabel",
                requestPayload.CreateParameter(fileVersionObject.VersionLabel)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
