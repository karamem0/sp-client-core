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
using System.Text.RegularExpressions;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ITermLabelService
{

    TermLabel? AddObject(
        Term termObject,
        string name,
        uint lcid,
        bool isDefault
    );

    TermLabel? GetObject(TermLabel termLabelObject);

    TermLabel? GetObject(Term termObject, string name);

    TermLabel? GetObject(
        Term termObject,
        string name,
        uint lcid
    );

    IEnumerable<TermLabel>? GetObjectEnumerable(Term termObject);

    void RemoveObject(TermLabel termLabelObject);

    void SetObjectAsDefault(TermLabel termLabelObject);

    void SetObject(TermLabel termLabelObject, IReadOnlyDictionary<string, object?> modificationInfo);

    void SetObjectAwait(TermLabel termLabelObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class TermLabelService(ClientContext clientContext) : ClientService<TermLabel>(clientContext), ITermLabelService
{

    public TermLabel? AddObject(
        Term termObject,
        string name,
        uint lcid,
        bool isDefault
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermLabel)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermLabel>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TermLabel? GetObject(Term termObject, string name)
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(TermLabel)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermLabel>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public TermLabel? GetObject(
        Term termObject,
        string name,
        uint lcid
    )
    {
        return this
            .GetObjectEnumerable(termObject)
            .Where(termLabelObject => termLabelObject.Name == name)
            .Where(termLabelObject => termLabelObject.Lcid == lcid)
            .SingleOrDefault();
    }

    public IEnumerable<TermLabel>? GetObjectEnumerable(Term termObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Labels"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(TermLabel))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<TermLabelEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public override void RemoveObject(TermLabel termLabelObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termLabelObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "DeleteObject"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Term"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TermStore"));
        var objectPath5 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void SetObjectAsDefault(TermLabel termLabelObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termLabelObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, objectPathId => ClientActionMethod.Create(objectPathId, "SetAsDefaultForLanguage"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Term"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TermStore"));
        var objectPath5 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public override void SetObject(TermLabel termLabelObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        this.SetObjectAwait(termLabelObject, modificationInfo);
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
            if (this
                .ClientContext.ProcessQuery(requestPayload)
                .IsNull(requestPayload.GetActionId<ClientActionInstantiateObjectPath>()))
            {
                Thread.Sleep(TimeSpan.FromSeconds(ClientConstants.WaitIntervalForTermLabelService));
            }
            else
            {
                return;
            }
        }
    }

    public void SetObjectAwait(TermLabel termLabelObject, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(termLabelObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(objectPath1, requestPayload.CreateSetPropertyDelegates(termLabelObject, modificationInfo));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Term"));
        var objectPath4 = requestPayload.Add(ObjectPathProperty.Create(objectPath3.Id, "TermStore"));
        var objectPath5 = requestPayload.Add(objectPath4, objectPathId => ClientActionMethod.Create(objectPathId, "CommitAll"));
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
