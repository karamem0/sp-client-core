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

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISiteTemplateService
{

    SiteTemplate? GetObject(
        string name,
        uint lcid,
        bool includeCrossLanguage
    );

    IEnumerable<SiteTemplate>? GetObjectEnumerable(uint lcid, bool includeCrossLanguage);

}

public class SiteTemplateService(ClientContext clientContext) : ClientService(clientContext), ISiteTemplateService
{

    public SiteTemplate? GetObject(
        string name,
        uint lcid,
        bool includeCrossLanguage
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetAvailableWebTemplates",
                requestPayload.CreateParameter(lcid),
                requestPayload.CreateParameter(includeCrossLanguage)
            ),
            ClientActionInstantiateObjectPath.Create
        );
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "GetByName",
                requestPayload.CreateParameter(name)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(SiteTemplate)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteTemplate>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<SiteTemplate>? GetObjectEnumerable(uint lcid, bool includeCrossLanguage)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetAvailableWebTemplates",
                requestPayload.CreateParameter(lcid),
                requestPayload.CreateParameter(includeCrossLanguage)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(SiteTemplate))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<SiteTemplateEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
