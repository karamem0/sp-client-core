//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface ITermSetService
    {

        TermSet AddObject(TermGroup termGroupObject, string termSetName, Guid? termSetId, uint? lcid);

        TermSet GetObject(TermSet termSetObject);

        TermSet GetObject(TermGroup termGroupObject, Guid? termSetId);

        TermSet GetObject(TermGroup termGroupObject, string termSetName);

        IEnumerable<TermSet> GetObjectEnumerable(TermGroup termGroupObject);

        void RemoveObject(TermSet termSetObject);

        void SetObject(TermSet termSetObject, IReadOnlyDictionary<string, object> modificationInfo);

    }

    public class TermSetService : ClientService<TermSet>, ITermSetService
    {

        public TermSetService(ClientContext clientContext) : base(clientContext)
        {
        }

        public TermSet AddObject(TermGroup termGroupObject, string termSetName, Guid? termSetId, uint? lcid)
        {
            _ = termGroupObject ?? throw new ArgumentNullException(nameof(termGroupObject));
            _ = termSetName ?? throw new ArgumentNullException(nameof(termSetName));
            _ = termSetId ?? throw new ArgumentNullException(nameof(termSetId));
            _ = lcid ?? throw new ArgumentNullException(nameof(lcid));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termGroupObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "CreateTermSet",
                    requestPayload.CreateParameter(termSetName),
                    requestPayload.CreateParameter(termSetId),
                    requestPayload.CreateParameter(lcid)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TermSet))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public TermSet GetObject(TermGroup termGroupObject, Guid? termSetId)
        {
            _ = termGroupObject ?? throw new ArgumentNullException(nameof(termGroupObject));
            _ = termSetId ?? throw new ArgumentNullException(nameof(termSetId));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termGroupObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "TermSets"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetById",
                    requestPayload.CreateParameter(termSetId)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TermSet))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public TermSet GetObject(TermGroup termGroupObject, string termSetName)
        {
            _ = termGroupObject ?? throw new ArgumentNullException(nameof(termGroupObject));
            _ = termSetName ?? throw new ArgumentNullException(nameof(termSetName));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termGroupObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "TermSets"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetByName",
                    requestPayload.CreateParameter(termSetName)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TermSet))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TermSet>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<TermSet> GetObjectEnumerable(TermGroup termGroupObject)
        {
            _ = termGroupObject ?? throw new ArgumentNullException(nameof(termGroupObject));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termGroupObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "TermSets"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(TermSet))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TermSetEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public override void SetObject(TermSet termSetObject, IReadOnlyDictionary<string, object> modificationInfo)
        {
            _ = termSetObject ?? throw new ArgumentNullException(nameof(termSetObject));
            _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termSetObject.ObjectIdentity));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                requestPayload.CreateSetPropertyDelegates(termSetObject, modificationInfo).ToArray());
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "TermStore"));
            var objectPath4 = requestPayload.Add(
                objectPath3,
                objectPathId => new ClientActionMethod(objectPathId, "CommitAll"));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
