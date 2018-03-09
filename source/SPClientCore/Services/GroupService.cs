//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IGroupService
    {

        Group CreateGroup(IDictionary<string, object> groupParameters, string groupQuery = null);

        IEnumerable<Group> FindGroups(string groupQuery = null);

        Group GetGroup(GroupPipeBind groupPipeBind, string groupQuery = null);

        void RemoveGroup(int? groupId);

        void UpdateGroup(int? groupId, IDictionary<string, object> groupParameters);

    }

    public class GroupService : ClientObjectService, IGroupService
    {

        public GroupService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Group CreateGroup(IDictionary<string, object> groupParameters, string groupQuery = null)
        {
            if (groupParameters == null)
            {
                throw new ArgumentNullException(nameof(groupParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitegroups")
                .ConcatQuery(groupQuery);
            var requestPayload = new ODataRequestPayload<Group>(groupParameters);
            return this.ClientContext.PostObject<Group>(requestUrl, requestPayload.Entity);
        }

        public IEnumerable<Group> FindGroups(string groupQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitegroups")
                .ConcatQuery(groupQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<Group>>(requestUrl);
        }

        public Group GetGroup(GroupPipeBind groupPipeBind, string groupQuery = null)
        {
            if (groupPipeBind == null)
            {
                throw new ArgumentNullException(nameof(groupPipeBind));
            }
            if (groupPipeBind.ClientObject != null)
            {
                if (groupPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = groupPipeBind.ClientObject.Metadata.Uri.ConcatQuery(groupQuery);
                    return this.ClientContext.GetObject<Group>(requestUrl);
                }
                else
                {
                    var requestUrl = groupPipeBind.ClientObject.Deferred.Uri.ConcatQuery(groupQuery);
                    return this.ClientContext.GetObject<Group>(requestUrl);
                }
            }
            if (groupPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/sitegroups/getbyid('{0}')", groupPipeBind.Id)
                    .ConcatQuery(groupQuery);
                return this.ClientContext.GetObject<Group>(requestUrl);
            }
            if (groupPipeBind.Name != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/sitegroups/getbyname('{0}')", groupPipeBind.Name)
                    .ConcatQuery(groupQuery);
                return this.ClientContext.GetObject<Group>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(GroupPipeBind)), nameof(groupPipeBind));
        }

        public void RemoveGroup(int? groupId)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitegroups/removebyid('{0}')", groupId);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UpdateGroup(int? groupId, IDictionary<string, object> groupParameters)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (groupParameters == null)
            {
                throw new ArgumentNullException(nameof(groupParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitegroups('{0}')", groupId);
            var requestPayload = new ODataRequestPayload<Group>(groupParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

    }

}
