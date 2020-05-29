//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    public class ODataV1ObjectAttribute : Attribute   
    {

        public ODataV1ObjectAttribute()
        {
        }

        public string Name { get; set; }

    }

}
