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
using System.Text.RegularExpressions;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITermLabelService
{

    Task<TermLabel?> AddObjectAsync(
        Term termObject,
        string name,
        uint lcid,
        bool isDefault,
        bool selectAllProperties = true
    );

    Task<TermLabel?> GetObjectAsync(TermLabel termLabelObject);

    Task<TermLabel?> GetObjectAsync(TermLabel termLabelObject, bool selectAllProperties = true);

    Task<TermLabel?> GetObjectAsync(
        Term termObject,
        string name,
        bool selectAllProperties = true
    );

    Task<TermLabel?> GetObjectAsync(
        Term termObject,
        string name,
        uint lcid
    );

    Task<IEnumerable<TermLabel>?> GetObjectEnumerableAsync(Term termObject, bool selectAllProperties = true);

    Task RemoveObjectAsync(TermLabel termLabelObject);

    Task SetObjectAsDefaultAsync(TermLabel termLabelObject);

    Task SetObjectAsync(TermLabel termLabelObject, IReadOnlyDictionary<string, object?> modificationInfo);

    Task SetObjectAwaitAsync(TermLabel termLabelObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermLabelService(ClientContext clientContext) : ClientService<TermLabel>(clientContext), ITermLabelService
{

    public async Task<TermLabel?> AddObjectAsync(
        Term termObject,
        string name,
        uint lcid,
        bool isDefault,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath1.Id,
                "CreateLabel",
                requestPayload.CreateParameter(name),
                requestPayload.CreateParameter(lcid),
                requestPayload.CreateParameter(isDefault)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermLabel)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermLabel>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TermLabel?> GetObjectAsync(
        Term termObject,
        string name,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Labels"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByValue",
                requestPayload.CreateParameter(name)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(TermLabel)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermLabel>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<TermLabel?> GetObjectAsync(
        Term termObject,
        string name,
        uint lcid
    )
    {
        var termLabels = await this.GetObjectEnumerableAsync(termObject);
        return termLabels
            ?.Where(termLabelObject => termLabelObject.Name == name)
            .Where(termLabelObject => termLabelObject.Lcid == lcid)
            .SingleOrDefault();
    }

    public async Task<IEnumerable<TermLabel>?> GetObjectEnumerableAsync(Term termObject, bool selectAllProperties = true)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Labels"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(selectAllProperties, typeof(TermLabel))
            )
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<TermLabelEnumerable>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public override async Task RemoveObjectAsync(TermLabel termLabelObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termLabelObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteObject"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Term"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TermStore"));
        var objectPath5 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public async Task SetObjectAsDefaultAsync(TermLabel termLabelObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termLabelObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "SetAsDefaultForLanguage"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Term"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TermStore"));
        var objectPath5 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

    public override async Task SetObjectAsync(TermLabel termLabelObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        await this.SetObjectAwaitAsync(termLabelObject, modificationInfo);
        var termLabelObjectIdentity = Regex.Replace(
            termLabelObject.ObjectIdentity,
            ";(.+);(.+);(.+)$",
            string.Format(
                ";{0};{1};$3",
                modificationInfo.GetValueOrDefault(nameof(TermLabel.Lcid), "$1"),
                modificationInfo.GetValueOrDefault(nameof(TermLabel.Name), "$2")
            )
        );
        while (true)
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termLabelObjectIdentity), ClientActionInstantiateObjectPath.Create);
            if ((await this.ClientContext.ProcessQueryAsync(requestPayload)).IsNull(requestPayload.GetActionId<ClientActionInstantiateObjectPath>()))
            {
                await Task.Delay(TimeSpan.FromSeconds(ClientConstants.WaitIntervalForTermLabelService));
            }
            else
            {
                return;
            }
        }
    }

    public async Task SetObjectAwaitAsync(TermLabel termLabelObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termLabelObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, requestPayload.CreateSetPropertyDelegates(termLabelObject, modificationInfo));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Term"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TermStore"));
        var objectPath5 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
