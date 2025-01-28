//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Models.V2;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Get, "KshList")]
[OutputType(typeof(List))]
public class GetListCommand : ClientObjectCmdlet<IListService>
{

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet1"
    )]
    public List Identity { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public ListItem ListItem { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public View View { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    public Drive Drive { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet5")]
    public Guid ListId { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet6")]
    public Uri ListUrl { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet7")]
    public string ListTitle { get; private set; }

    [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet8")]
    public LibraryType LibraryType { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet9")]
    public SwitchParameter NoEnumerate { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Outputs.Add(this.Service.GetObject(this.Identity));
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            this.Outputs.Add(this.Service.GetObject(this.ListItem));
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            this.Outputs.Add(this.Service.GetObject(this.View));
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.Outputs.Add(this.Service.GetObject(this.Drive));
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            this.Outputs.Add(this.Service.GetObject(this.ListId));
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            if (this.ListUrl.IsAbsoluteUri)
            {
                this.Outputs.Add(this.Service.GetObject(new Uri(this.ListUrl.AbsolutePath, UriKind.Relative)));
            }
            else
            {
                this.Outputs.Add(this.Service.GetObject(this.ListUrl));
            }
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            this.Outputs.Add(this.Service.GetObject(this.ListTitle));
        }
        if (this.ParameterSetName == "ParamSet8")
        {
            this.Outputs.Add(this.Service.GetObject(this.LibraryType));
        }
        if (this.ParameterSetName == "ParamSet9")
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
