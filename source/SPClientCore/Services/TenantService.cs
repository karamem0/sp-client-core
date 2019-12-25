//
// Copyright (c) 2020 karamem0
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

    public interface ITenantService
    {

        Tenant GetObject();

    }

    public class TenantService : ClientService, ITenantService
    {

        public TenantService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Tenant GetObject()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<Tenant>(requestPayload.ActionQueryId);
        }

    }

}
