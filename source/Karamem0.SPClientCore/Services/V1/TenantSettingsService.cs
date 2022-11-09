//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface ITenantSettingsService
    {

        TenantSettings GetObject();

    }

    public class TenantSettingsService : ClientService, ITenantSettingsService
    {

        public TenantSettingsService(ClientContext clientContext) : base(clientContext)
        {
        }

        public TenantSettings GetObject()
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/sp_tenantsettings_current");
            return this.ClientContext.GetObject<TenantSettings>(requestUrl);
        }

    }

}
