//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Get", "KshRecycleBinItem")]
    [OutputType(typeof(RecycleBinItem))]
    public class GetRecycleBinItemCommand : ClientObjectCmdlet<IRecycleBinItemService>
    {

        public GetRecycleBinItemCommand()
        {
        }

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "ParamSet1")]
        public RecycleBinItem Identity { get; private set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "ParamSet2")]
        public Guid ItemId { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public SwitchParameter SecondStage { get; private set; }

        [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
        public SwitchParameter NoEnumerate { get; private set; }

        protected override void ProcessRecordCore(ref List<object> outputs)
        {
            if (this.ParameterSetName == "ParamSet1")
            {
                outputs.Add(this.Service.GetObject(this.Identity));
            }
            if (this.ParameterSetName == "ParamSet2")
            {
                if (this.SecondStage)
                {
                    outputs.Add(this.Service.GetObject(this.ItemId, RecycleBinItemState.SecondStageRecycleBin));
                }
                else
                {
                    outputs.Add(this.Service.GetObject(this.ItemId, RecycleBinItemState.FirstStageRecycleBin));
                }
            }
            if (this.ParameterSetName == "ParamSet3")
            {
                if (this.SecondStage)
                {
                    if (this.NoEnumerate)
                    {
                        outputs.Add(this.Service.GetObjectEnumerable(RecycleBinItemState.SecondStageRecycleBin));
                    }
                    else
                    {
                        outputs.AddRange(this.Service.GetObjectEnumerable(RecycleBinItemState.SecondStageRecycleBin));
                    }
                }
                else
                {
                    if (this.NoEnumerate)
                    {
                        outputs.Add(this.Service.GetObjectEnumerable(RecycleBinItemState.FirstStageRecycleBin));
                    }
                    else
                    {
                        outputs.AddRange(this.Service.GetObjectEnumerable(RecycleBinItemState.FirstStageRecycleBin));
                    }
                }
            }
        }

    }

}
