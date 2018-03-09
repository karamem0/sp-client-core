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

    public interface IWebService
    {

        Web CreateWeb(IDictionary<string, object> webParameters, string webQuery = null);

        IEnumerable<Web> FindWebs(string webQuery = null);

        Web GetWeb(WebPipeBind webPipeBind, string webQuery = null);

        void RemoveWeb();

        void SelectWeb(string webUrl);

        void UpdateWeb(IDictionary<string, object> webParameters);

        void AddWebRoleAssignment(int? principalId, int? roleDefinitionId);

        IEnumerable<RoleAssignment> FindWebRoleAssignments(string roleAssignmentQuery = null);

        void RemoveWebRoleAssignment(int? principalId, int? roleDefinitionId);

        RoleAssignment GetWebRoleAssignment(int? principalId, string roleAssignmentQuery = null);

        void BreakWebRoleInheritance(bool copyRoleAssignments, bool clearSubscopes);

        void ResetWebRoleInheritance();

        IEnumerable<WebTemplate> FindWebTemplates(uint? lcid, bool doIncludeCrossLanguage, string webTemplateQuery = null);

        WebTemplate GetWebTemplate(string webTemplateName, uint? lcid, bool doIncludeCrossLanguage, string webTemplateQuery = null);

    }

    public class WebService : ClientObjectService, IWebService
    {

        public WebService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Web CreateWeb(IDictionary<string, object> webParameters, string webQuery = null)
        {
            if (webParameters == null)
            {
                throw new ArgumentNullException(nameof(webParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/webs/add()")
                .ConcatQuery(webQuery);
            var requestPayload = new ODataRequestPayload<WebCreationInformation>(webParameters);
            return this.ClientContext.PostObject<Web>(requestUrl, requestPayload);
        }

        public IEnumerable<Web> FindWebs(string webQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/webs")
                .ConcatQuery(webQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<Web>>(requestUrl);
        }

        public Web GetWeb(WebPipeBind webPipeBind = null, string webQuery = null)
        {
            if (webPipeBind == null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web")
                    .ConcatQuery(webQuery);
                return this.ClientContext.GetObject<Web>(requestUrl);
            }
            if (webPipeBind.ClientObject != null)
            {
                if (webPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = webPipeBind.ClientObject.Metadata.Uri.ConcatQuery(webQuery);
                    return this.ClientContext.GetObject<Web>(requestUrl);
                }
                else
                {
                    var requestUrl = webPipeBind.ClientObject.Deferred.Uri.ConcatQuery(webQuery);
                    return this.ClientContext.GetObject<Web>(requestUrl);
                }
            }
            if (webPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/site/openwebbyid('{0}')", webPipeBind.Id)
                    .ConcatQuery(webQuery);
                return this.ClientContext.PostObject<Web>(requestUrl, null);
            }
            if (webPipeBind.ServerRelativeUrl != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/site/openweb('{0}')", webPipeBind.ServerRelativeUrl)
                    .ConcatQuery(webQuery);
                return this.ClientContext.PostObject<Web>(requestUrl, null);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(WebPipeBind)), nameof(webPipeBind));
        }

        public void RemoveWeb()
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web");
            this.ClientContext.DeleteObject(requestUrl);
            this.ClientContext.BaseAddress = this.ClientContext.BaseAddress.MakeParentUri();
        }

        public void SelectWeb(string webUrl)
        {
            if (webUrl == null)
            {
                throw new ArgumentNullException(nameof(webUrl));
            }
            this.ClientContext.BaseAddress = new Uri(webUrl, UriKind.Absolute);
        }

        public void UpdateWeb(IDictionary<string, object> webParameters)
        {
            if (webParameters == null)
            {
                throw new ArgumentNullException(nameof(webParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web");
            var requestPayload = new ODataRequestPayload<Web>(webParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
            if (webParameters.TryGetValue("ServerRelativeUrl", out var serverRelativeUrl))
            {
                this.ClientContext.BaseAddress = this.ClientContext.BaseAddress.MakeParentUri().ConcatPath(serverRelativeUrl.ToString());
            }
        }

        public void AddWebRoleAssignment(int? principalId, int? roleDefinitionId)
        {
            if (principalId == null)
            {
                throw new ArgumentNullException(nameof(principalId));
            }
            if (roleDefinitionId == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/roleassignments/addroleassignment(principalid={0},roledefid={1})", principalId, roleDefinitionId);
            this.ClientContext.PostObject<RoleAssignment>(requestUrl, null);
        }

        public IEnumerable<RoleAssignment> FindWebRoleAssignments(string roleAssignmentQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/roleassignments")
                .ConcatQuery(roleAssignmentQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<RoleAssignment>>(requestUrl);
        }

        public RoleAssignment GetWebRoleAssignment(int? principalId, string roleAssignmentQuery = null)
        {
            if (principalId == null)
            {
                throw new ArgumentNullException(nameof(principalId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/roleassignments/getbyprincipalid({0})", principalId)
                .ConcatQuery(roleAssignmentQuery);
            return this.ClientContext.GetObject<RoleAssignment>(requestUrl);
        }

        public void RemoveWebRoleAssignment(int? principalId, int? roleDefinitionId)
        {
            if (principalId == null)
            {
                throw new ArgumentNullException(nameof(principalId));
            }
            if (roleDefinitionId == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/roleassignments/removeroleassignment(principalid={0},roledefid={1})",
                    principalId, roleDefinitionId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void BreakWebRoleInheritance(bool copyRoleAssignments, bool clearSubscopes)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/breakroleinheritance(copyroleassignments={0},clearsubscopes={1})", copyRoleAssignments, clearSubscopes);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void ResetWebRoleInheritance()
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/resetroleinheritance");
            this.ClientContext.PostObject(requestUrl, null);
        }

        public IEnumerable<WebTemplate> FindWebTemplates(uint? lcid, bool doIncludeCrossLanguage, string webTemplateQuery = null)
        {
            if (lcid == null)
            {
                throw new ArgumentNullException(nameof(lcid));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getavailablewebtemplates(lcid={0},doincludecrosslanguage={1})", lcid, doIncludeCrossLanguage)
                .ConcatQuery(webTemplateQuery);
            return this.ClientContext.PostObject<ClientObjectCollection<WebTemplate>>(requestUrl, null);
        }

        public WebTemplate GetWebTemplate(string webTemplateName, uint? lcid, bool doIncludeCrossLanguage, string webTemplateQuery = null)
        {
            if (webTemplateName == null)
            {
                throw new ArgumentNullException(nameof(webTemplateName));
            }
            if (lcid == null)
            {
                throw new ArgumentNullException(nameof(lcid));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getavailablewebtemplates(lcid={0},doincludecrosslanguage={1})/getbyname('{2}')",
                    lcid, doIncludeCrossLanguage, webTemplateName)
                .ConcatQuery(webTemplateQuery);
            return this.ClientContext.PostObject<WebTemplate>(requestUrl, null);
        }

    }

}
