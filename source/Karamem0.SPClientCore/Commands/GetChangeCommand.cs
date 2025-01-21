//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshChange")]
[OutputType(typeof(Change))]
public class GetChangeCommand : ClientObjectCmdlet<ISiteCollectionService, ISiteService, IChangeService>
{

    public GetChangeCommand()
    {
    }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SwitchParameter SiteCollection { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SwitchParameter Site { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
    public List List { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public ChangeToken BeginToken { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public ChangeToken EndToken { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public long FetchLimit { get; private set; }

    // [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    // [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    // [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    // public bool LatestFirst { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public ChangeObjects Objects { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public ChangeOperations Operations { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public bool RecursiveAll { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        var changeQuery = new ChangeQuery(this.MyInvocation.BoundParameters);
        if (this.ParameterSetName == "ParamSet1")
        {
            this.ValidateSwitchParameter(nameof(this.SiteCollection));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service3.GetObjectEnumerable(this.Service1.GetObject(), changeQuery));
            }
            else
            {
                this.Outputs.AddRange(this.Service3.GetObjectEnumerable(this.Service1.GetObject(), changeQuery));
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.ValidateSwitchParameter(nameof(this.Site));
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service3.GetObjectEnumerable(this.Service2.GetObject(), changeQuery));
            }
            else
            {
                this.Outputs.AddRange(this.Service3.GetObjectEnumerable(this.Service2.GetObject(), changeQuery));
            }
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            if (this.NoEnumerate)
            {
                this.Outputs.Add(this.Service3.GetObjectEnumerable(this.List, changeQuery));
            }
            else
            {
                this.Outputs.AddRange(this.Service3.GetObjectEnumerable(this.List, changeQuery));
            }
        }
    }

}
