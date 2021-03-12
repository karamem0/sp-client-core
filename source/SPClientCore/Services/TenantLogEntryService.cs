//
// Copyright (c) 2021 karamem0
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

    public interface ITenantLogEntryService
    {

        IEnumerable<TenantLogEntry> GetObjectEnumerable(DateTime beginDateTime, DateTime endDateTime, uint rows);

    }

    public class TenantLogEntryService : ClientService, ITenantLogEntryService
    {

        public TenantLogEntryService(ClientContext clientContext) : base(clientContext)
        {
        }

        public IEnumerable<TenantLogEntry> GetObjectEnumerable(DateTime beginDateTime, DateTime endDateTime, uint rows)
        {
            if (beginDateTime == default(DateTime))
            {
                throw new ArgumentNullException(nameof(beginDateTime));
            }
            if (endDateTime == default(DateTime))
            {
                throw new ArgumentNullException(nameof(endDateTime));
            }
            if (rows == default(uint))
            {
                throw new ArgumentNullException(nameof(rows));
            }
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(TenantLog)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetEntries",
                    requestPayload.CreateParameter(beginDateTime),
                    requestPayload.CreateParameter(endDateTime),
                    requestPayload.CreateParameter(rows)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(TenantLogEntry))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantLogEntryEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

    }

}
