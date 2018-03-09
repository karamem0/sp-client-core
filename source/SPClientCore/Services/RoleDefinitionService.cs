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

    public interface IRoleDefinitionService
    {

        RoleDefinition CreateRoleDefinition(IDictionary<string, object> roleDefinitionParameters, string roleDefinitionQuery = null);

        IEnumerable<RoleDefinition> FindRoleDefinitions(string roleDefinitionQuery = null);

        RoleDefinition GetRoleDefinition(RoleDefinitionPipeBind roleDefinitionPipeBind, string roleDefinitionQuery = null);

        void RemoveRoleDefinition(int? roleDefinitionId);

        void UpdateRoleDefinition(int? roleDefinitionId, IDictionary<string, object> roleDefinitionParameters);

    }

    public class RoleDefinitionService : ClientObjectService, IRoleDefinitionService
    {

        public RoleDefinitionService(ClientContext clientContext) : base(clientContext)
        {
        }

        public RoleDefinition CreateRoleDefinition(IDictionary<string, object> roleDefinitionParameters, string roleDefinitionQuery = null)
        {
            if (roleDefinitionParameters == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/roledefinitions")
                .ConcatQuery(roleDefinitionQuery);
            var requestPayload = new ODataRequestPayload<RoleDefinition>(roleDefinitionParameters);
            return this.ClientContext.PostObject<RoleDefinition>(requestUrl, requestPayload.Entity);
        }

        public IEnumerable<RoleDefinition> FindRoleDefinitions(string roleDefinitionQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/roledefinitions")
                .ConcatQuery(roleDefinitionQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<RoleDefinition>>(requestUrl);
        }

        public RoleDefinition GetRoleDefinition(RoleDefinitionPipeBind roleDefinitionPipeBind, string roleDefinitionQuery = null)
        {
            if (roleDefinitionPipeBind == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionPipeBind));
            }
            if (roleDefinitionPipeBind.ClientObject != null)
            {
                if (roleDefinitionPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = roleDefinitionPipeBind.ClientObject.Metadata.Uri.ConcatQuery(roleDefinitionQuery);
                    return this.ClientContext.GetObject<RoleDefinition>(requestUrl);
                }
                else
                {
                    var requestUrl = roleDefinitionPipeBind.ClientObject.Deferred.Uri.ConcatQuery(roleDefinitionQuery);
                    return this.ClientContext.GetObject<RoleDefinition>(requestUrl);
                }
            }
            if (roleDefinitionPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/roledefinitions/getbyid('{0}')", roleDefinitionPipeBind.Id)
                    .ConcatQuery(roleDefinitionQuery);
                return this.ClientContext.GetObject<RoleDefinition>(requestUrl);
            }
            if (roleDefinitionPipeBind.Name != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/roledefinitions/getbyname('{0}')", roleDefinitionPipeBind.Name)
                    .ConcatQuery(roleDefinitionQuery);
                return this.ClientContext.GetObject<RoleDefinition>(requestUrl);
            }
            if (roleDefinitionPipeBind.Type != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/roledefinitions/getbytype('{0}')", (int)roleDefinitionPipeBind.Type)
                    .ConcatQuery(roleDefinitionQuery);
                return this.ClientContext.GetObject<RoleDefinition>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(RoleDefinitionPipeBind)), nameof(roleDefinitionPipeBind));
        }

        public void RemoveRoleDefinition(int? roleDefinitionId)
        {
            if (roleDefinitionId == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/roledefinitions({0})", roleDefinitionId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void UpdateRoleDefinition(int? roleDefinitionId, IDictionary<string, object> roleDefinitionParameters)
        {
            if (roleDefinitionId == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionId));
            }
            if (roleDefinitionParameters == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/roledefinitions({0})", roleDefinitionId);
            var requestPayload = new ODataRequestPayload<RoleDefinition>(roleDefinitionParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

    }

}
