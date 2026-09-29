//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITenantThemeService
{

    Task<bool> AddObjectAsync(string themeName, IReadOnlyDictionary<string, object?> creationInfo);

    Task<TenantTheme?> GetObjectAsync(TenantTheme themeObject);

    Task<TenantTheme?> GetObjectAsync(TenantTheme themeObject, bool selectAllProperties = true);

    Task<TenantTheme?> GetObjectAsync(string themeName, bool selectAllProperties = true);

    Task<IEnumerable<TenantTheme>?> GetObjectEnumerableAsync(bool selectAllProperties = true);

    Task RemoveObjectAsync(TenantTheme themeObject);

    Task RemoveObjectAsync(string themeName);

    Task<bool> SetObjectAsync(TenantTheme themeObject, IReadOnlyDictionary<string, object?> modificationInfo);

    Task<bool> SetObjectAsync(string themeName, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TenantThemeService(ClientContext clientContext) : ClientService(clientContext), ITenantThemeService
{

    public async Task<bool> AddObjectAsync(string themeName, IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "AddTenantTheme",
                requestPayload.CreateParameter(themeName),
                requestPayload.CreateParameter(JsonConvert.SerializeObject(ClientValueObject.Create<TenantThemeCreationInfo>(creationInfo)))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<bool>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<TenantTheme?> GetObjectAsync(TenantTheme themeObject)
    {
        return await this.GetObjectAsync(themeObject, selectAllProperties: true);
    }

    public async Task<TenantTheme?> GetObjectAsync(TenantTheme themeObject, bool selectAllProperties = true)
    {
        var themeName = themeObject.Name;
        _ = themeName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return await this.GetObjectAsync(themeName, selectAllProperties);
    }

    public async Task<TenantTheme?> GetObjectAsync(string themeName, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "GetTenantTheme",
                requestPayload.CreateParameter(themeName)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TenantTheme)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantTheme>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<IEnumerable<TenantTheme>?> GetObjectEnumerableAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetAllTenantThemes"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TenantTheme))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TenantThemeEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveObjectAsync(TenantTheme themeObject)
    {
        var themeName = themeObject.Name;
        _ = themeName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        await this.RemoveObjectAsync(themeName);
    }

    public async Task RemoveObjectAsync(string themeName)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "DeleteTenantTheme",
                requestPayload.CreateParameter(themeName)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<bool> SetObjectAsync(TenantTheme themeObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var themeName = themeObject.Name;
        _ = themeName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return await this.SetObjectAsync(themeName, modificationInfo);
    }

    public async Task<bool> SetObjectAsync(string themeName, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "UpdateTenantTheme",
                requestPayload.CreateParameter(themeName),
                requestPayload.CreateParameter(JsonConvert.SerializeObject(ClientValueObject.Create<TenantThemeCreationInfo>(modificationInfo)))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<bool>(requestPayload.GetActionId<ClientActionMethod>()));
    }

}
