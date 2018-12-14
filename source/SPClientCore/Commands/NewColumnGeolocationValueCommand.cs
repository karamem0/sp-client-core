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

    [Cmdlet("New", "KshColumnGeolocationValue")]
    [OutputType(typeof(ColumnGeolocationValue))]
    public class NewColumnGeolocationValueCommand : ClientObjectCmdlet
    {

        public NewColumnGeolocationValueCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public double Altitude { get; private set; }

        [Parameter(Mandatory = true)]
        public double Latitude { get; private set; }

        [Parameter(Mandatory = true)]
        public double Longitude { get; private set; }

        [Parameter(Mandatory = false)]
        public double Measure { get; private set; }

        protected override void ProcessRecordCore()
        {
            this.WriteObject(new ColumnGeolocationValue(this.Altitude, this.Latitude, this.Longitude, this.Measure));
        }

    }

}
