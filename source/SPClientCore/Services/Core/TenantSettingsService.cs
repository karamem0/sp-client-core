//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Core
{


    public interface ITenantSettingsService
    {

        TenantSettings GetTenantSettings();

    }

    public class TenantSettingsService : ClientObjectService, ITenantSettingsService
    {

        public TenantSettingsService(ClientContext clientContext) : base(clientContext)
        {
        }

        public TenantSettings GetTenantSettings()
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/sp_tenantsettings_current");
            return this.ClientContext.GetObject<TenantSettings>(requestUrl);
        }

    }

}
