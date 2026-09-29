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

public interface IListTemplateService
{

    Task<ListTemplate?> GetObjectAsync(ListTemplate listTemplateObject);

    Task<ListTemplate?> GetObjectAsync(ListTemplate listTemplateObject, bool selectAllProperties = true);

    Task<ListTemplate?> GetObjectAsync(string listTemplateTitle, bool selectAllProperties = true);

    Task<IEnumerable<ListTemplate>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

}

public class ListTemplateService(ClientContext clientContext) : ClientService<ListTemplate>(clientContext), IListTemplateService
{

    public async Task<ListTemplate?> GetObjectAsync(string listTemplateTitle, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "ListTemplates"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetByName",
                requestPayload.CreateParameter(listTemplateTitle)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(ListTemplate)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListTemplate>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<ListTemplate>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "ListTemplates"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(ListTemplate))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ListTemplateEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

}
