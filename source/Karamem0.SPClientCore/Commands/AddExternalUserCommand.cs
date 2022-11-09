//
// Copyright (c) 2022 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Add", "KshExternalUser")]
    [Alias("New-KshExternalUser")]
    [OutputType(typeof(UserSharingResult))]
    public class AddExternalUserCommand : ClientObjectCmdlet<IExternalUserService>
    {

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
        public SwitchParameter Site { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        public File File { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet3")]
        public Folder Folder { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet3")]
        public string[] UserId { get; private set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = "ParamSet3")]
        public RoleType Role { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public bool AdditivePermission { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        public bool AllowExternalSharing { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public string CustomMessage { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public bool IncludeAnonymousLinksInNotification { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public bool PropagateAcl { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public bool SendServerManagedNotification { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public bool ValidateExistingPermissions { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                this.ValidateSwitchParameter(nameof(this.Site));
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.AddObject(
                        this.UserId,
                        this.Role,
                        this.SendServerManagedNotification,
                        this.CustomMessage,
                        this.AdditivePermission,
                        this.AllowExternalSharing
                    ));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.AddObject(
                        this.UserId,
                        this.Role,
                        this.SendServerManagedNotification,
                        this.CustomMessage,
                        this.AdditivePermission,
                        this.AllowExternalSharing
                    ));
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.AddObject(
                        this.File.ServerRelativeUrl,
                        this.UserId,
                        this.Role,
                        this.ValidateExistingPermissions,
                        this.AdditivePermission,
                        this.SendServerManagedNotification,
                        this.CustomMessage,
                        this.IncludeAnonymousLinksInNotification,
                        this.PropagateAcl
                    ));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.AddObject(
                        this.File.ServerRelativeUrl,
                        this.UserId,
                        this.Role,
                        this.ValidateExistingPermissions,
                        this.AdditivePermission,
                        this.SendServerManagedNotification,
                        this.CustomMessage,
                        this.IncludeAnonymousLinksInNotification,
                        this.PropagateAcl
                    ));
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.NoEnumerate)
                {
                    this.Outputs.Add(this.Service.AddObject(
                        this.Folder.ServerRelativeUrl,
                        this.UserId,
                        this.Role,
                        this.ValidateExistingPermissions,
                        this.AdditivePermission,
                        this.SendServerManagedNotification,
                        this.CustomMessage,
                        this.IncludeAnonymousLinksInNotification,
                        this.PropagateAcl
                    ));
                }
                else
                {
                    this.Outputs.AddRange(this.Service.AddObject(
                        this.Folder.ServerRelativeUrl,
                        this.UserId,
                        this.Role,
                        this.ValidateExistingPermissions,
                        this.AdditivePermission,
                        this.SendServerManagedNotification,
                        this.CustomMessage,
                        this.IncludeAnonymousLinksInNotification,
                        this.PropagateAcl
                    ));
                }
            }
        }

    }

}
