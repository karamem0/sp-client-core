//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IViewService
{

    View? AddObject(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    View? GetObject(View viewObject);

    View? GetObject(View viewObject, bool selectAllProperties = true);

    string? CopyObject(
        List listObject,
        View viewObject,
        string newName,
        bool personalView,
        string? url
    );

    View? GetObject(
        List listObject,
        Guid viewId,
        bool selectAllProperties = true
    );

    View? GetObject(
        List listObject,
        string viewTitle,
        bool selectAllProperties = true
    );

    IEnumerable<View>? GetObjectEnumerable(List listObject, bool selectAllProperties = true);

    void RemoveObject(View viewObject);

    void SetObject(View viewObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class ViewService(ClientContext clientContext) : ClientService<View>(clientContext), IViewService
{

    public View? AddObject(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Views"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ViewCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(View)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public string? CopyObject(
        List listObject,
        View viewObject,
        string newName,
        bool personalView,
        string? url
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPath => ClientActionMethod.Create(
                objectPath,
                "SaveAsNewView",
                requestPayload.CreateParameter(viewObject.Id),
                requestPayload.CreateParameter(newName),
                requestPayload.CreateParameter(personalView),
                requestPayload.CreateParameter(url)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public View? GetObject(
        List listObject,
        Guid viewId,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Views"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(viewId)
            ),
            ClientActionInstantiateObjectPath.Create
        );
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(View)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public View? GetObject(
        List listObject,
        string viewTitle,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Views"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByTitle",
                requestPayload.CreateParameter(viewTitle)
            ),
            ClientActionInstantiateObjectPath.Create
        );
        var objectPath4 = requestPayload.Add(
            objectPath3,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(View)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<View>? GetObjectEnumerable(List listObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Views"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(View))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ViewEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
