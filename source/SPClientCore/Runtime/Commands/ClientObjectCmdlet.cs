//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Commands
{

    public abstract class ClientObjectCmdlet : PSCmdlet
    {

        protected ClientObjectCmdlet()
        {
        }

        protected override void ProcessRecord()
        {
            try
            {
                this.ProcessRecordCore();
            }
            catch (PipelineStoppedException)
            {
            }
            catch (Exception ex)
            {
                this.WriteError(new ErrorRecord(ex, "Exception", ErrorCategory.NotSpecified, null));
            }
        }

        protected abstract void ProcessRecordCore();

    }

}
