//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Initialize", "KshColumnTaxonomyValue")]
    [OutputType(typeof(ColumnTaxonomyValue))]
    public class InitializeColumnTaxonomyValueCommand : ClientObjectCmdlet
    {

        public InitializeColumnTaxonomyValueCommand()
        {
        }

        [Parameter(Mandatory = true)]
        public Term Term { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.WriteObject(new ColumnTaxonomyValue(this.Term.Name, this.Term.Id.ToString(), -1));
        }

    }

}
