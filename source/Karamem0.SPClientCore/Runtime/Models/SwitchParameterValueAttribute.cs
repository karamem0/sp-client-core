//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public class SwitchParameterValueAttribute : Attribute
{

    public object? TrueValue { get; set; }

    public object? FalseValue { get; set; }

}
