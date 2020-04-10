//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshSiteCollectionAppCatalog")]
    [OutputType(typeof(SiteCollectionAppCatalog))]
    public class GetSiteCollectionAppCatalogCommand : ClientObjectCmdlet<ISiteCollectionAppCatalogService>
    {

        public GetSiteCollectionAppCatalogCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
        public SiteCollection SiteCollection { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        public Uri SiteCollectionUrl { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        public Guid SiteCollectionId { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.WriteObject(this.Service.GetObjectEnumerable().Single(obj => obj.SiteCollectionId == this.SiteCollection.Id));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.SiteCollectionUrl.IsAbsoluteUri)
                {
                    this.WriteObject(this.Service.GetObjectEnumerable().Single(obj => obj.AbsoluteUrl == this.SiteCollectionUrl.ToString()));
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.SiteCollectionUrl),
                        nameof(this.SiteCollectionUrl));
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.WriteObject(this.Service.GetObjectEnumerable().Single(obj => obj.SiteCollectionId == this.SiteCollectionId));
            }
            if (this.ParameterSetName == "ParamSet4")
            {
                this.WriteObject(this.Service.GetObjectEnumerable(), this.NoEnumerate ? false : true);
            }
        }

    }

}
