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

    Task<View?> AddObjectAsync(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool selectAllProperties = true
    );

    Task<View?> GetObjectAsync(View viewObject);

    Task<View?> GetObjectAsync(View viewObject, bool selectAllProperties = true);

    Task<string?> CopyObjectAsync(
        List listObject,
        View viewObject,
        string newName,
        bool personalView,
        string? url
    );

    Task<View?> GetObjectAsync(
        List listObject,
        Guid viewId,
        bool selectAllProperties = true
    );

    Task<View?> GetObjectAsync(
        List listObject,
        string viewTitle,
        bool selectAllProperties = true
    );

    Task<IEnumerable<View>?> GetObjectEnumerableAsync(List listObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(View viewObject);

    Task SetObjectAsync(View viewObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class ViewService(ClientContext clientContext) : ClientService<View>(clientContext), IViewService
{

    public async Task<View?> AddObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<View>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<string?> CopyObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<string>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<View?> GetObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<View>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<View?> GetObjectAsync(
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<View>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<View>?> GetObjectEnumerableAsync(List listObject, bool selectAllProperties = true)
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
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ViewEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}
