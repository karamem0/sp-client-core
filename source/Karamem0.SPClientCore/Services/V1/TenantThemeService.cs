//
// Copyright (c) 2018-2025 karamem0
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

    bool AddObject(string themeName, IReadOnlyDictionary<string, object?> creationInfo);

    TenantTheme? GetObject(TenantTheme themeObject);

    TenantTheme? GetObject(string themeName);

    IEnumerable<TenantTheme>? GetObjectEnumerable();

    void RemoveObject(TenantTheme themeObject);

    void RemoveObject(string themeName);

    bool SetObject(TenantTheme themeObject, IReadOnlyDictionary<string, object?> modificationInfo);

    bool SetObject(string themeName, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TenantThemeService(ClientContext clientContext) : ClientService(clientContext), ITenantThemeService
{

    public bool AddObject(string themeName, IReadOnlyDictionary<string, object?> creationInfo)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<bool>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public TenantTheme? GetObject(TenantTheme themeObject)
    {
        var themeName = themeObject.Name;
        _ = themeName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return this.GetObject(themeName);
    }

    public TenantTheme? GetObject(string themeName)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TenantTheme)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantTheme>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<TenantTheme>? GetObjectEnumerable()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathConstructor.Create(typeof(Tenant)));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(objectPath1.Id, "GetAllTenantThemes"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(TenantTheme))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TenantThemeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveObject(TenantTheme themeObject)
    {
        var themeName = themeObject.Name;
        _ = themeName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        this.RemoveObject(themeName);
    }

    public void RemoveObject(string themeName)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public bool SetObject(TenantTheme themeObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var themeName = themeObject.Name;
        _ = themeName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return this.SetObject(themeName, modificationInfo);
    }

    public bool SetObject(string themeName, IReadOnlyDictionary<string, object?> modificationInfo)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<bool>(requestPayload.GetActionId<ClientActionMethod>());
    }

}
