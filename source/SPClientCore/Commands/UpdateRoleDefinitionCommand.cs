//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Update", "SPRoleDefinition")]
    [OutputType(typeof(RoleDefinition))]
    public class UpdateRoleDefinitionCommand : PSCmdlet
    {

        public UpdateRoleDefinitionCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public RoleDefinitionPipeBind RoleDefinition { get; private set; }

        [Parameter(Mandatory = false)]
        public BasePermissions BasePermissions { get; private set; }

        [Parameter(Mandatory = false)]
        public string Description { get; private set; }

        [Parameter(Mandatory = false)]
        public string Name { get; private set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; private set; }

        [Parameter(Mandatory = false)]
        public string[] Includes { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var roleDefinitionService = ClientObjectService.ServiceProvider.GetService<IRoleDefinitionService>();
            var roleDefinitionQuery = ODataQuery.Create<RoleDefinition>(this.MyInvocation.BoundParameters);
            var roleDefinition = roleDefinitionService.GetRoleDefinition(this.RoleDefinition);
            roleDefinitionService.UpdateRoleDefinition(roleDefinition.Id, this.MyInvocation.BoundParameters);
            if (this.PassThru)
            {
                this.WriteObject(roleDefinitionService.GetRoleDefinition(new RoleDefinitionPipeBind(roleDefinition.Id), roleDefinitionQuery));
            }
        }

    }

}
