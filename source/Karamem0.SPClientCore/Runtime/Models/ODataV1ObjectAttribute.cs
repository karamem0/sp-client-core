//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ODataV1ObjectAttribute : Attribute
{

    public string Name { get; set; }

}
