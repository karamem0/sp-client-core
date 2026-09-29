//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Services.V1;
using System.Collections;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommon.Set, "Property")]
[OutputType(typeof(PropertyValues))]
public class SetPropertyCommand : ClientObjectCmdlet<IPropertyService>
{

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    public SwitchParameter Site { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet2"
    )]
    public File? File { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet3"
    )]
    public Folder? Folder { get; private set; }

    [Parameter(
        Mandatory = true,
        Position = 0,
        ValueFromPipeline = true,
        ParameterSetName = "ParamSet4"
    )]
    public ListItem? ListItem { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public PSObject? Value { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
    public SwitchParameter PassThru { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
    public SwitchParameter SelectAllProperties { get; private set; } = true;

    protected override async Task ProcessRecordAsync()
    {
        _ = this.Value ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Value));
        if (this.ParameterSetName == "ParamSet1")
        {
            if (this.Value.BaseObject is Hashtable hashtable)
            {
                await this.Service.SetObjectAsync(
                    hashtable
                        .ToDictionary<string, object?>()
                        .AsReadOnly()
                );
            }
            else
            {
                await this.Service.SetObjectAsync(
                    this
                        .Value.ToDictionary()
                        .AsReadOnly()
                );
            }
            if (this.PassThru)
            {
                this.Outputs.Add(await this.Service.GetObjectAsync(this.SelectAllProperties));
            }
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.File ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.File));
            if (this.Value.BaseObject is Hashtable hashtable)
            {
                await this.Service.SetObjectAsync(
                    this.File,
                    hashtable
                        .ToDictionary<string, object?>()
                        .AsReadOnly()
                );
            }
            else
            {
                await this.Service.SetObjectAsync(
                    this.File,
                    this
                        .Value.ToDictionary()
                        .AsReadOnly()
                );
            }
            if (this.PassThru)
            {
                this.Outputs.Add(await this.Service.GetObjectAsync(this.File, this.SelectAllProperties));
            }
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.Folder ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Folder));
            if (this.Value.BaseObject is Hashtable hashtable)
            {
                await this.Service.SetObjectAsync(
                    this.Folder,
                    hashtable
                        .ToDictionary<string, object?>()
                        .AsReadOnly()
                );
            }
            else
            {
                await this.Service.SetObjectAsync(
                    this.Folder,
                    this
                        .Value.ToDictionary()
                        .AsReadOnly()
                );
            }
            if (this.PassThru)
            {
                this.Outputs.Add(await this.Service.GetObjectAsync(this.Folder, this.SelectAllProperties));
            }
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.ListItem ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ListItem));
            if (this.Value.BaseObject is Hashtable hashtable)
            {
                await this.Service.SetObjectAsync(
                    this.ListItem,
                    hashtable
                        .ToDictionary<string, object?>()
                        .AsReadOnly()
                );
            }
            else
            {
                await this.Service.SetObjectAsync(
                    this.ListItem,
                    this
                        .Value.ToDictionary()
                        .AsReadOnly()
                );
            }
            if (this.PassThru)
            {
                this.Outputs.Add(await this.Service.GetObjectAsync(this.ListItem, this.SelectAllProperties));
            }
        }
    }

}
