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

public interface IRegionalSettingsService
{

    Task AddSupportedUILanguageAsync(uint lcid);

    Task DisableMultilingualAsync(bool force);

    Task EnableMultilingualAsync(bool force);

    Task<DateTime> ConvertUniversalToLocalAsync(DateTime date);

    Task<DateTime> ConvertLocalToUniversalAsync(DateTime date);

    Task<RegionalSettings?> GetObjectAsync(bool selectAllProperties = true);

    Task RemoveSupportedUILanguageAsync(uint lcid);

    Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo);

}

public class RegionalSettingsService(ClientContext clientContext) : ClientService<RegionalSettings>(clientContext), IRegionalSettingsService
{

    public async Task AddSupportedUILanguageAsync(uint lcid)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "AddSupportedUILanguage",
                requestPayload.CreateParameter(lcid)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task DisableMultilingualAsync(bool force)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = ObjectPathProperty.Create(objectPath1.Id, "Web");
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionSetProperty.Create(
                objectPathId,
                "IsMultilingual",
                requestPayload.CreateParameter(false)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Features"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Remove",
                requestPayload.CreateParameter("24611c05-ee19-45da-955f-6602264abaf8"),
                requestPayload.CreateParameter(force)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task EnableMultilingualAsync(bool force)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = ObjectPathProperty.Create(objectPath1.Id, "Web");
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionSetProperty.Create(
                objectPathId,
                "IsMultilingual",
                requestPayload.CreateParameter(true)
            ),
            objectPathId => ClientActionMethod.Create(objectPathId, "Update")
        );
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Features"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "Add",
                requestPayload.CreateParameter("24611c05-ee19-45da-955f-6602264abaf8"),
                requestPayload.CreateParameter(force),
                requestPayload.CreateParameter(FeatureDefinitionScope.None)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task<DateTime> ConvertUniversalToLocalAsync(DateTime date)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RegionalSettings"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TimeZone"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "UTCToLocalTime",
                requestPayload.CreateParameter(date)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<DateTime>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<DateTime> ConvertLocalToUniversalAsync(DateTime date)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RegionalSettings"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TimeZone"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "LocalTimeToUTC",
                requestPayload.CreateParameter(date)
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<DateTime>(requestPayload.GetActionId<ClientActionMethod>()));
    }

    public async Task<RegionalSettings?> GetObjectAsync(bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "RegionalSettings"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(RegionalSettings)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<RegionalSettings>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task RemoveSupportedUILanguageAsync(uint lcid)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            objectPath2,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "RemoveSupportedUILanguage",
                requestPayload.CreateParameter(lcid)
            )
        );
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RegionalSettings"));
        var objectPath4 = requestPayload.Add(objectPath3, requestPayload.CreateSetPropertyDelegates(typeof(RegionalSettings), modificationInfo));
        var objectPath5 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
