//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

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

    [Cmdlet("Remove", "SPRoleDefinition")]
    [OutputType(typeof(void))]
    public class RemoveRoleDefinitionCommand : PSCmdlet
    {

        public RemoveRoleDefinitionCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public RoleDefinitionPipeBind RoleDefinition { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var roleDefinitionService = ClientObjectService.ServiceProvider.GetService<IRoleDefinitionService>();
            var roleDefinition = roleDefinitionService.GetRoleDefinition(this.RoleDefinition);
            roleDefinitionService.RemoveRoleDefinition(roleDefinition.Id);
        }

    }

}
