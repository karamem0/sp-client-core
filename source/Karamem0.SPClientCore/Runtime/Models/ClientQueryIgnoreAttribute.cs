//
// Copyright (c) 2018-2024 karamem0
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

public class ClientQueryIgnoreAttribute : Attribute
{

    public ClientQueryIgnoreAttribute()
    {
    }

    public ClientQueryIgnoreAttribute(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

}
