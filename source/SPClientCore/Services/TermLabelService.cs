//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface ITermLabelService
    {

        TermLabel CreateObject(Term termObject, string name, uint lcid, bool isDefault);

        TermLabel GetObject(TermLabel termLabelObject);

        TermLabel GetObject(Term termObject, string labelName);

        IEnumerable<TermLabel> GetObjectEnumerable(Term termObject);

        void RemoveObject(TermLabel termLabelObject);

        void SetObjectAsDefault(TermLabel termLabelObject);

        void UpdateObject(TermLabel termLabelObject, IReadOnlyDictionary<string, object> modificationInformation);

    }

    public class TermLabelService : ClientService<TermLabel>, ITermLabelService
    {

        public TermLabelService(ClientContext clientContext) : base(clientContext)
        {
        }

        public TermLabel CreateObject(Term termObject, string name, uint lcid, bool isDefault)
        {
            if (termObject == null)
            {
                throw new ArgumentNullException(nameof(termObject));
            }
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (lcid == default(uint))
            {
                throw new ArgumentNullException(nameof(lcid));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "CreateLabel",
                    requestPayload.CreateParameter(name),
                    requestPayload.CreateParameter(lcid),
                    requestPayload.CreateParameter(isDefault)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TermLabel))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TermLabel>(requestPayload.ActionQueryId);
        }

        public TermLabel GetObject(Term termObject, string labelName)
        {
            if (termObject == null)
            {
                throw new ArgumentNullException(nameof(termObject));
            }
            if (labelName == null)
            {
                throw new ArgumentNullException(nameof(labelName));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Labels"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath3 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath2.Id,
                    "GetByValue",
                    requestPayload.CreateParameter(labelName)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TermLabel))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TermLabel>(requestPayload.ActionQueryId);
        }

        public IEnumerable<TermLabel> GetObjectEnumerable(Term termObject)
        {
            if (termObject == null)
            {
                throw new ArgumentNullException(nameof(termObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                new ObjectPathProperty(objectPath1.Id, "Labels"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(TermLabel))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TermLabelEnumerable>(requestPayload.ActionQueryId);
        }

        public override void RemoveObject(TermLabel termLabelObject)
        {
            if (termLabelObject == null)
            {
                throw new ArgumentNullException(nameof(termLabelObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termLabelObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(objectPathId, "DeleteObject"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Term"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "TermStore"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath5 = requestPayload.Add(
                objectPath4,
                objectPathId => new ClientActionMethod(objectPathId, "CommitAll"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public void SetObjectAsDefault(TermLabel termLabelObject)
        {
            if (termLabelObject == null)
            {
                throw new ArgumentNullException(nameof(termLabelObject));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termLabelObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(objectPathId, "SetAsDefaultForLanguage"));
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Term"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "TermStore"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath5 = requestPayload.Add(
                objectPath4,
                objectPathId => new ClientActionMethod(objectPathId, "CommitAll"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

        public override void UpdateObject(TermLabel termLabelObject, IReadOnlyDictionary<string, object> modificationInformation)
        {
            if (termLabelObject == null)
            {
                throw new ArgumentNullException(nameof(termLabelObject));
            }
            if (modificationInformation == null)
            {
                throw new ArgumentNullException(nameof(modificationInformation));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathIdentity(termLabelObject.ObjectIdentity),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                requestPayload.CreateSetPropertyDelegates(termLabelObject, modificationInformation).ToArray());
            var objectPath3 = requestPayload.Add(
                new ObjectPathProperty(objectPath2.Id, "Term"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath4 = requestPayload.Add(
                new ObjectPathProperty(objectPath3.Id, "TermStore"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId));
            var objectPath5 = requestPayload.Add(
                objectPath4,
                objectPathId => new ClientActionMethod(objectPathId, "CommitAll"));
            this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
