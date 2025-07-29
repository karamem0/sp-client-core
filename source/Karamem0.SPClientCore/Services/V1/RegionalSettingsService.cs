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

public interface IRegionalSettingsService
{

    void AddSupportedUILanguage(uint lcid);

    void DisableMultilingual(bool force);

    void EnableMultilingual(bool force);

    DateTime ConvertUniversalToLocal(DateTime date);

    DateTime ConvertLocalToUniversal(DateTime date);

    RegionalSettings? GetObject();

    void RemoveSupportedUILanguage(uint lcid);

    void SetObject(IReadOnlyDictionary<string, object?> modificationInfo);

}

public class RegionalSettingsService(ClientContext clientContext) : ClientService<RegionalSettings>(clientContext), IRegionalSettingsService
{

    public void AddSupportedUILanguage(uint lcid)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void DisableMultilingual(bool force)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void EnableMultilingual(bool force)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public DateTime ConvertUniversalToLocal(DateTime date)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<DateTime>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public DateTime ConvertLocalToUniversal(DateTime date)
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
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<DateTime>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public RegionalSettings? GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath2.Id, "RegionalSettings"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(RegionalSettings)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<RegionalSettings>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void RemoveSupportedUILanguage(uint lcid)
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObject(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "RegionalSettings"));
        var objectPath4 = requestPayload.Add(objectPath3, requestPayload.CreateSetPropertyDelegates(typeof(RegionalSettings), modificationInfo));
        var objectPath5 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
