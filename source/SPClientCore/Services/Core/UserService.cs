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

    public interface IUserService
    {

        User CreateUser(IDictionary<string, object> userParameters, string userQuery = null);

        User CreateUser(int? groupId, IDictionary<string, object> userParameters, string userQuery = null);

        IEnumerable<User> FindUsers(int? groupId, string userQuery = null);

        IEnumerable<User> FindUsers(string userQuery = null);

        User GetUser(int? groupId, UserPipeBind userPipeBind = null, string userQuery = null);

        User GetUser(UserPipeBind userPipeBind = null, string userQuery = null);

        void RemoveUser(int? groupId, string userLoginName);

        void RemoveUser(string userLoginName);

        void UpdateUser(int? groupId, string userLoginName, IDictionary<string, object> userParameters);

        void UpdateUser(string userLoginName, IDictionary<string, object> userParameters);

    }

    public class UserService : ClientObjectService, IUserService
    {

        public UserService(ClientContext clientContext) : base(clientContext)
        {
        }

        public User CreateUser(IDictionary<string, object> userParameters, string userQuery = null)
        {
            if (userParameters == null)
            {
                throw new ArgumentNullException(nameof(userParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/siteusers")
                .ConcatQuery(userQuery);
            var requestPayload = new ODataRequestPayload<User>(userParameters);
            return this.ClientContext.PostObject<User>(requestUrl, requestPayload.Entity);
        }

        public User CreateUser(int? groupId, IDictionary<string, object> userParameters, string userQuery = null)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (userParameters == null)
            {
                throw new ArgumentNullException(nameof(userParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitegroups('{0}')/users", groupId)
                .ConcatQuery(userQuery);
            var requestPayload = new ODataRequestPayload<User>(userParameters);
            return this.ClientContext.PostObject<User>(requestUrl, requestPayload.Entity);
        }

        public IEnumerable<User> FindUsers(string userQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/siteusers")
                .ConcatQuery(userQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<User>>(requestUrl);
        }

        public IEnumerable<User> FindUsers(int? groupId, string userQuery = null)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitegroups('{0}')/users", groupId)
                .ConcatQuery(userQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<User>>(requestUrl);
        }

        public User GetUser(UserPipeBind userPipeBind = null, string userQuery = null)
        {
            if (userPipeBind == null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/currentuser")
                    .ConcatQuery(userQuery);
                return this.ClientContext.GetObject<User>(requestUrl);
            }
            if (userPipeBind.ClientObject != null)
            {
                if (userPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = userPipeBind.ClientObject.Metadata.Uri.ConcatQuery(userQuery);
                    return this.ClientContext.GetObject<User>(requestUrl);
                }
                else
                {
                    var requestUrl = userPipeBind.ClientObject.Deferred.Uri.ConcatQuery(userQuery);
                    return this.ClientContext.GetObject<User>(requestUrl);
                }
            }
            if (userPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/siteusers/getbyid('{0}')", userPipeBind.Id)
                    .ConcatQuery(userQuery);
                return this.ClientContext.GetObject<User>(requestUrl);
            }
            if (userPipeBind.LoginName != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/siteusers/getbyloginname(@v)?@v='{0}'", userPipeBind.LoginName)
                    .ConcatQuery(userQuery);
                return this.ClientContext.GetObject<User>(requestUrl);
            }
            if (userPipeBind.Email != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/siteusers/getbyemail('{0}')", userPipeBind.Email)
                    .ConcatQuery(userQuery);
                return this.ClientContext.GetObject<User>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(UserPipeBind)), nameof(userPipeBind));
        }

        public User GetUser(int? groupId, UserPipeBind userPipeBind = null, string userQuery = null)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (userPipeBind == null)
            {
                throw new ArgumentNullException(nameof(userPipeBind));
            }
            if (userPipeBind.ClientObject != null)
            {
                if (userPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = userPipeBind.ClientObject.Metadata.Uri.ConcatQuery(userQuery);
                    return this.ClientContext.GetObject<User>(requestUrl);
                }
                else
                {
                    var requestUrl = userPipeBind.ClientObject.Deferred.Uri.ConcatQuery(userQuery);
                    return this.ClientContext.GetObject<User>(requestUrl);
                }
            }
            if (userPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/sitegroups({0})/users/getbyid('{1}')", groupId, userPipeBind.Id)
                    .ConcatQuery(userQuery);
                return this.ClientContext.GetObject<User>(requestUrl);
            }
            if (userPipeBind.LoginName != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/sitegroups({0})/users/getbyloginname(@v)?@v='{1}'", groupId, userPipeBind.LoginName)
                    .ConcatQuery(userQuery);
                return this.ClientContext.GetObject<User>(requestUrl);
            }
            if (userPipeBind.Email != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/sitegroups({0})/users/getbyemail('{1}')", groupId, userPipeBind.Email)
                    .ConcatQuery(userQuery);
                return this.ClientContext.GetObject<User>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(UserPipeBind)), nameof(userPipeBind));
        }

        public void RemoveUser(string userLoginName)
        {
            if (userLoginName == null)
            {
                throw new ArgumentNullException(nameof(userLoginName));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/siteusers/removebyloginname(@v)?@v='{0}'", userLoginName);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveUser(int? groupId, string userLoginName)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (userLoginName == null)
            {
                throw new ArgumentNullException(nameof(userLoginName));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitegroups('{0}')/users/removebyloginname(@v)?@v='{1}'", groupId, userLoginName);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UpdateUser(string userLoginName, IDictionary<string, object> userParameters)
        {
            if (userLoginName == null)
            {
                throw new ArgumentNullException(nameof(userLoginName));
            }
            if (userParameters == null)
            {
                throw new ArgumentNullException(nameof(userParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/siteusers(@v)?@v='{0}'", userLoginName);
            var requestPayload = new ODataRequestPayload<User>(userParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

        public void UpdateUser(int? groupId, string userLoginName, IDictionary<string, object> userParameters)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException(nameof(groupId));
            }
            if (userLoginName == null)
            {
                throw new ArgumentNullException(nameof(userLoginName));
            }
            if (userParameters == null)
            {
                throw new ArgumentNullException(nameof(userParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitegroups('{0}')/users(@v)?@v='{1}'", groupId, userLoginName);
            var requestPayload = new ODataRequestPayload<User>(userParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

    }

}
