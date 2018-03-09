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

    public interface ISiteService
    {

        Site GetSite(string siteQuery = null);

    }

    public class SiteService : ClientObjectService, ISiteService
    {

        public SiteService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Site GetSite(string siteQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/site")
                .ConcatQuery(siteQuery);
            return this.ClientContext.GetObject<Site>(requestUrl);
        }

    }

}
