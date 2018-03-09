//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.PipeBinds;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IListItemService
    {

        ListItem CreateListItem(Guid? listId, IDictionary<string, object> listItemParameters, string listItemQuery = null);

        IEnumerable<ListItem> FindListItems(Guid? listId, string listItemQuery = null);

        ListItem GetListItem(Guid? listId, ListItemPipeBind listItemPipeBind, string listItemQuery = null);

        GuidResult RecycleListItem(Guid? listId, int? listItemId);

        void RemoveListItem(Guid? listId, int? listItemId);

        void UpdateListItem(Guid? listId, int? listItemId, IDictionary<string, object> listItemParameters);

        void AddListItemRoleAssignment(Guid? listId, int? listItemId, int? principalId, int? roleDefinitionId);

        IEnumerable<RoleAssignment> FindListItemRoleAssignments(Guid? listId, int? listItemId, string roleAssignmentQuery = null);

        RoleAssignment GetListItemRoleAssignment(Guid? listId, int? listItemId, int? principalId, string roleAssignmentQuery = null);

        void RemoveListItemRoleAssignment(Guid? listId, int? listItemId, int? principalId, int? roleDefinitionId);

        void BreakListItemRoleInheritance(Guid? listId, int? listItemId, bool copyRoleAssignments, bool clearSubscopes);

        void ResetListItemRoleInheritance(Guid? listId, int? listItemId);

    }

    public class ListItemService : ClientObjectService, IListItemService
    {

        public ListItemService(ClientContext context) : base(context)
        {
        }

        public ListItem CreateListItem(Guid? listId, IDictionary<string, object> listItemParameters, string listItemQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemParameters == null)
            {
                throw new ArgumentNullException(nameof(listItemParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items", listId)
                .ConcatQuery(listItemQuery);
            var requestPayload = new ListItem(listItemParameters);
            return this.ClientContext.PostObject<ListItem>(requestUrl, requestPayload);
        }

        public IEnumerable<ListItem> FindListItems(Guid? listId, string listItemQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items", listId)
                .ConcatQuery(listItemQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<ListItem>>(requestUrl);
        }

        public ListItem GetListItem(Guid? listId, ListItemPipeBind listItemPipeBind, string listItemQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemPipeBind == null)
            {
                throw new ArgumentNullException(nameof(listItemPipeBind));
            }
            if (listItemPipeBind.ClientObject != null)
            {
                if (listItemPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = listItemPipeBind.ClientObject.Metadata.Uri.ConcatQuery(listItemQuery);
                    return this.ClientContext.GetObject<ListItem>(requestUrl);
                }
                else
                {
                    var requestUrl = listItemPipeBind.ClientObject.Deferred.Uri.ConcatQuery(listItemQuery);
                    return this.ClientContext.GetObject<ListItem>(requestUrl);
                }
            }
            if (listItemPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists('{0}')/items/getbyid('{1}')", listId, listItemPipeBind.Id)
                    .ConcatQuery(listItemQuery);
                return this.ClientContext.GetObject<ListItem>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(ListItemPipeBind)), nameof(listItemPipeBind));
        }

        public GuidResult RecycleListItem(Guid? listId, int? listItemId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items('{1}')/recycle", listId, listItemId);
            return this.ClientContext.PostObject<GuidResult>(requestUrl, null);
        }

        public void RemoveListItem(Guid? listId, int? listItemId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items('{1}')", listId, listItemId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void UpdateListItem(Guid? listId, int? listItemId, IDictionary<string, object> listItemParameters)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            if (listItemParameters == null)
            {
                throw new ArgumentNullException(nameof(listItemParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items('{1}')", listId, listItemId);
            var requestPayload = new ListItem(listItemParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload);
        }

        public void AddListItemRoleAssignment(Guid? listId, int? listItemId, int? principalId, int? roleDefinitionId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
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
                .ConcatPath("_api/web/lists('{0}')/items({1})/roleassignments/addroleassignment(principalid={2},roledefid={3})",
                    listId, listItemId, principalId, roleDefinitionId);
            this.ClientContext.PostObject<RoleAssignment>(requestUrl, null);
        }

        public IEnumerable<RoleAssignment> FindListItemRoleAssignments(Guid? listId, int? listItemId, string roleAssignmentQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items({1})/roleassignments", listId, listItemId)
                .ConcatQuery(roleAssignmentQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<RoleAssignment>>(requestUrl);
        }

        public RoleAssignment GetListItemRoleAssignment(Guid? listId, int? listItemId, int? principalId, string roleAssignmentQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            if (principalId == null)
            {
                throw new ArgumentNullException(nameof(principalId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items({1})/roleassignments/getbyprincipalid({2})", listId, listItemId, principalId)
                .ConcatQuery(roleAssignmentQuery);
            return this.ClientContext.GetObject<RoleAssignment>(requestUrl);
        }

        public void RemoveListItemRoleAssignment(Guid? listId, int? listItemId, int? principalId, int? roleDefinitionId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
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
                .ConcatPath("_api/web/lists('{0}')/items({1})/roleassignments/removeroleassignment(principalid={2},roledefid={3})",
                    listId, listItemId, principalId, roleDefinitionId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void BreakListItemRoleInheritance(Guid? listId, int? listItemId, bool copyRoleAssignments, bool clearSubscopes)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items({1})/breakroleinheritance(copyroleassignments={2},clearsubscopes={3})",
                    listId, listItemId, copyRoleAssignments, clearSubscopes);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void ResetListItemRoleInheritance(Guid? listId, int? listItemId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (listItemId == null)
            {
                throw new ArgumentNullException(nameof(listItemId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/items({1})/resetroleinheritance", listId, listItemId);
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
