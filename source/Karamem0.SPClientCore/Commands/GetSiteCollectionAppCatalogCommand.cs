//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshSiteCollectionAppCatalog")]
[OutputType(typeof(SiteCollectionAppCatalog))]
public class GetSiteCollectionAppCatalogCommand : ClientObjectCmdlet<ISiteCollectionAppCatalogService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public SiteCollectionAppCatalog Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet2"
    )]
    public SiteCollection SiteCollection { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet3"
    )]
    public Uri SiteCollectionUrl { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ParameterSetName = "ParamSet4"
    )]
    public Guid SiteCollectionId { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet5")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(
                    this.Service
                        .GetObjectEnumerable()
                        .Where(obj => obj.SiteCollectionId == this.SiteCollection.Id)
                        .ToArray()
                );
            }
            else
            {
                this.Outputs.AddRange(
                    this.Service
                        .GetObjectEnumerable()
                        .Where(obj => obj.SiteCollectionId == this.SiteCollection.Id)
                        .ToArray()
                );
            }
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            if (this.SiteCollectionUrl.IsAbsoluteUri)
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(
                        this.Service
                            .GetObjectEnumerable()
                            .Where(obj => obj.AbsoluteUrl == this.SiteCollectionUrl.ToString())
                            .ToArray()
                    );
                }
                else
                {
                    this.Outputs.AddRange(
                        this.Service
                            .GetObjectEnumerable()
                            .Where(obj => obj.AbsoluteUrl == this.SiteCollectionUrl.ToString())
                            .ToArray()
                    );
                }
            }
            else
            {
                throw new InvalidOperationException(
                    string.Format(StringResources.ErrorValueIsNotAbsoluteUrl, this.SiteCollectionUrl)
                );
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(
                    this.Service
                        .GetObjectEnumerable()
                        .Where(obj => obj.SiteCollectionId == this.SiteCollectionId)
                        .ToArray()
                );
            }
            else
            {
                this.Outputs.AddRange(
                    this.Service
                        .GetObjectEnumerable()
                        .Where(obj => obj.SiteCollectionId == this.SiteCollectionId)
                        .ToArray()
                );
            }
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service.GetObjectEnumerable());
            }
            else
            {
                this.Outputs.AddRange(this.Service.GetObjectEnumerable());
            }
        }
    }

}
