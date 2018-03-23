//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Core
{

    public interface IListService
    {

        List CreateList(IDictionary<string, object> listParameters, string listQuery = null);

        IEnumerable<List> FindLists(string listQuery = null);

        List GetList(ListPipeBind listPipeBind, string listQuery = null);

        GuidResult RecycleList(Guid? listId);

        void RemoveList(Guid? listId);

        void UpdateList(Guid? listId, IDictionary<string, object> listParameters);

        void AddListRoleAssignment(Guid? listId, int? principalId, int? roleDefinitionId);

        IEnumerable<RoleAssignment> FindListRoleAssignments(Guid? listId, string roleAssignmentQuery = null);

        RoleAssignment GetListRoleAssignment(Guid? listId, int? principalId, string roleAssignmentQuery = null);

        void RemoveListRoleAssignment(Guid? listId, int? principalId, int? roleDefinitionId);

        void BreakListRoleInheritance(Guid? listId, bool copyRoleAssignments, bool clearSubscopes);

        void ResetListRoleInheritance(Guid? listId);

    }

    public class ListService : ClientObjectService, IListService
    {

        public ListService(ClientContext clientContext) : base(clientContext)
        {
        }

        public List CreateList(IDictionary<string, object> listParameters, string listQuery = null)
        {
            if (listParameters == null)
            {
                throw new ArgumentNullException(nameof(listParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists")
                .ConcatQuery(listQuery);
            var requestPayload = new ODataRequestPayload<List>(listParameters);
            return this.ClientContext.PostObject<List>(requestUrl, requestPayload.Entity);
        }

        public IEnumerable<List> FindLists(string listQuery)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists")
                .ConcatQuery(listQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<List>>(requestUrl);
        }

        public List GetList(ListPipeBind listPipeBind, string listQuery = null)
        {
            if (listPipeBind == null)
            {
                throw new ArgumentNullException(nameof(listPipeBind));
            }
            if (listPipeBind.ClientObject != null)
            {
                if (listPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = listPipeBind.ClientObject.Metadata.Uri.ConcatQuery(listQuery);
                    return this.ClientContext.GetObject<List>(requestUrl);
                }
                else
                {
                    var requestUrl = listPipeBind.ClientObject.Deferred.Uri.ConcatQuery(listQuery);
                    return this.ClientContext.GetObject<List>(requestUrl);
                }
            }
            if (listPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists/getbyid('{0}')", listPipeBind.Id)
                    .ConcatQuery(listQuery);
                return this.ClientContext.GetObject<List>(requestUrl);
            }
            if (listPipeBind.Title != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists/getbytitle('{0}')", listPipeBind.Title)
                    .ConcatQuery(listQuery);
                return this.ClientContext.GetObject<List>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(ListPipeBind)), nameof(listPipeBind));
        }

        public GuidResult RecycleList(Guid? listId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/recycle", listId);
            return this.ClientContext.PostObject<GuidResult>(requestUrl, null);
        }

        public void RemoveList(Guid? listId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')", listId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void UpdateList(Guid? listId, IDictionary<string, object> listParameters)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listParameters == null)
            {
                throw new ArgumentNullException(nameof(listParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')", listId);
            var requestPayload = new ODataRequestPayload<List>(listParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

        public void AddListRoleAssignment(Guid? listId, int? principalId, int? roleDefinitionId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (principalId == null)
            {
                throw new ArgumentNullException(nameof(principalId));
            }
            if (roleDefinitionId == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/roleassignments/addroleassignment(principalid={1},roledefid={2})",
                    listId, principalId, roleDefinitionId);
            this.ClientContext.PostObject<RoleAssignment>(requestUrl, null);
        }

        public IEnumerable<RoleAssignment> FindListRoleAssignments(Guid? listId, string roleAssignmentQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/roleassignments", listId)
                .ConcatQuery(roleAssignmentQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<RoleAssignment>>(requestUrl);
        }

        public RoleAssignment GetListRoleAssignment(Guid? listId, int? principalId, string roleAssignmentQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (principalId == null)
            {
                throw new ArgumentNullException(nameof(principalId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/roleassignments/getbyprincipalid({1})", listId, principalId)
                .ConcatQuery(roleAssignmentQuery);
            return this.ClientContext.GetObject<RoleAssignment>(requestUrl);
        }

        public void RemoveListRoleAssignment(Guid? listId, int? principalId, int? roleDefinitionId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (principalId == null)
            {
                throw new ArgumentNullException(nameof(principalId));
            }
            if (roleDefinitionId == null)
            {
                throw new ArgumentNullException(nameof(roleDefinitionId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/roleassignments({1})", listId, principalId, roleDefinitionId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void BreakListRoleInheritance(Guid? listId, bool copyRoleAssignments, bool clearSubscopes)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/breakroleinheritance(copyroleassignments={1},clearsubscopes={2})",
                    listId, copyRoleAssignments, clearSubscopes);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void ResetListRoleInheritance(Guid? listId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/resetroleinheritance", listId);
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
