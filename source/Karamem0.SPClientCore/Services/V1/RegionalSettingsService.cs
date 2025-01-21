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

    DateTime ConvertUniversalToLocal(DateTime date);

    DateTime ConvertLocalToUniversal(DateTime date);

    RegionalSettings GetObject();

    void SetObject(IReadOnlyDictionary<string, object> modificationInfo);

}

public class RegionalSettingsService(ClientContext clientContext) : ClientService<RegionalSettings>(clientContext), IRegionalSettingsService
{

    public DateTime ConvertUniversalToLocal(DateTime date)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "RegionalSettings"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathProperty(objectPath3.Id, "TimeZone"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "UTCToLocalTime",
                requestPayload.CreateParameter(date)));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<DateTime>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public DateTime ConvertLocalToUniversal(DateTime date)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "RegionalSettings"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathProperty(objectPath3.Id, "TimeZone"));
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "LocalTimeToUTC",
                requestPayload.CreateParameter(date)));
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<DateTime>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public RegionalSettings GetObject()
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "RegionalSettings"),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(RegionalSettings))
            });
        return this.ClientContext
            .ProcessQuery(requestPayload)
            .ToObject<RegionalSettings>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObject(IReadOnlyDictionary<string, object> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(
            new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathProperty(objectPath2.Id, "RegionalSettings"));
        var objectPath4 = requestPayload.Add(
            objectPath3,
            requestPayload.CreateSetPropertyDelegates(typeof(RegionalSettings), modificationInfo).ToArray());
        var objectPath5 = requestPayload.Add(
            objectPath4,
            objectPathId => new ClientActionMethod(objectPathId, "Update"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
