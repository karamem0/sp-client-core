//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IProfileLoaderService
    {

        UserProfile GetOwnerUserProfile(string userProfileQuery = null);

        UserProfile GetUserProfile(string userProfileQuery = null);

    }

    public class ProfileLoaderService : ClientObjectService, IProfileLoaderService
    {

        public ProfileLoaderService(ClientContext clientContext) : base(clientContext)
        {
        }

        public UserProfile GetOwnerUserProfile(string userProfileQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/sp.userprofiles.profileloader.getowneruserprofile")
                .ConcatQuery(userProfileQuery);
            return this.ClientContext.PostObject<UserProfile>(requestUrl, null);
        }

        public UserProfile GetUserProfile(string userProfileQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/sp.userprofiles.profileloader.getprofileloader/getuserprofile")
                .ConcatQuery(userProfileQuery);
            return this.ClientContext.PostObject<UserProfile>(requestUrl, null);
        }

    }

}
