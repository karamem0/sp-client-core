//
// Copyright (c) 2023 karamem0
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

    public interface ITenantOrganizationNewsSiteService
    {

        void AddObject(string organizationNewsSiteUrl);

        IEnumerable<string> GetObjectEnumerable();

        void RemoveObject(string organizationNewsSiteUrl);

    }

    public class TenantOrganizationNewsSiteService : ClientService, ITenantOrganizationNewsSiteService
    {

        public TenantOrganizationNewsSiteService(ClientContext clientContext) : base(clientContext)
        {
        }

        public void AddObject(string organizationNewsSiteUrl)
        {
            _ = organizationNewsSiteUrl ?? throw new ArgumentNullException(nameof(organizationNewsSiteUrl));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "SetOrgNewsSite",
                    requestPayload.CreateParameter(organizationNewsSiteUrl)));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public IEnumerable<string> GetObjectEnumerable()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "GetOrgNewsSites"));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<IEnumerable<string>>(requestPayload.GetActionId<ClientActionMethod>());
        }

        public void RemoveObject(string organizationNewsSiteUrl)
        {
            _ = organizationNewsSiteUrl ?? throw new ArgumentNullException(nameof(organizationNewsSiteUrl));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "RemoveOrgNewsSite",
                    requestPayload.CreateParameter(organizationNewsSiteUrl)));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

    }

}
