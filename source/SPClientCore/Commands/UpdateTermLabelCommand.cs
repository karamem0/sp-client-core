//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Update", "KshTermLabel")]
    [OutputType(typeof(TermLabel))]
    public class UpdateTermLabelCommand : ClientObjectCmdlet<ITermService, ITermLabelService>
    {

        public UpdateTermLabelCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet3")]
        public TermLabel Identity { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
        public uint Lcid { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
        public string Name { get; private set; }

        [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
        public SwitchParameter IsDefault { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public SwitchParameter PassThru { get; private set; }

        protected override void ProcessRecordCore()
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                if (this.PassThru)
                {
                    var termObject = this.Service1.GetObject(this.Identity);
                    this.Service2.UpdateObject(this.Identity, this.MyInvocation.BoundParameters);
                    while (true)
                    {
                        var termLabelObject = this.Service2.GetObjectEnumerable(termObject)
                            .Where(obj => obj.Lcid == this.Lcid)
                            .Where(obj => obj.Name == this.Identity.Name)
                            .SingleOrDefault();
                        if (termLabelObject != null)
                        {
                            this.WriteObject(termLabelObject);
                            break;
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
                else
                {
                    this.Service2.UpdateObject(this.Identity, this.MyInvocation.BoundParameters);
                }
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.PassThru)
                {
                    var termObject = this.Service1.GetObject(this.Identity);
                    this.Service2.UpdateObject(this.Identity, this.MyInvocation.BoundParameters);
                    while (true)
                    {
                        var termLabelObject = this.Service2.GetObjectEnumerable(termObject)
                            .Where(obj => obj.Lcid == this.Identity.Lcid)
                            .Where(obj => obj.Name == this.Name)
                            .SingleOrDefault();
                        if (termLabelObject != null)
                        {
                            this.WriteObject(termLabelObject);
                            break;
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
                else
                {
                    this.Service2.UpdateObject(this.Identity, this.MyInvocation.BoundParameters);
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                this.ValidateSwitchParameter(nameof(this.IsDefault));
                this.Service2.SetObjectAsDefault(this.Identity);
                if (this.PassThru)
                {
                    this.WriteObject(this.Service2.GetObject(this.Identity));
                }
            }
        }

    }

}
