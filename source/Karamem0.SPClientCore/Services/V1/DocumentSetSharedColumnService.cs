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

public interface IDocumentSetSharedColumnService
{

    void AddObject(
        ContentType contentTypeObject,
        Column columnObject,
        bool pushChanges
    );

    IEnumerable<Column>? GetObjectEnumerable(ContentType contentTypeObject);

    void RemoveObject(
        ContentType contentTypeObject,
        Column columnObject,
        bool pushChanges
    );

}

public class DocumentSetSharedColumnService(ClientContext clientContext) : ClientService(clientContext), IDocumentSetSharedColumnService
{

    public void AddObject(
        ContentType contentTypeObject,
        Column columnObject,
        bool pushChanges
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathIdentity.Create(columnObject.ObjectIdentity));
        var objectPath3 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                ClientRequestParameterObjectPath.Create(objectPath1)
            )
        );
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SharedFields"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Add",
                ClientRequestParameterObjectPath.Create(objectPath2)
            )
        );
        var objectPath6 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public IEnumerable<Column>? GetObjectEnumerable(ContentType contentTypeObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                ClientRequestParameterObjectPath.Create(objectPath1)
            )
        );
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "SharedFields"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(Column))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SharedColumnEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(
        ContentType contentTypeObject,
        Column columnObject,
        bool pushChanges
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(contentTypeObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathIdentity.Create(columnObject.ObjectIdentity));
        var objectPath3 = requestPayload.Add(
            ObjectPathStaticMethod.Create(
                typeof(DocumentSetTemplate),
                "GetDocumentSetTemplate",
                ClientRequestParameterObjectPath.Create(objectPath1)
            )
        );
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "SharedFields"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                ClientRequestParameterObjectPath.Create(objectPath2)
            )
        );
        var objectPath6 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Update",
                requestPayload.CreateParameter(pushChanges)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
