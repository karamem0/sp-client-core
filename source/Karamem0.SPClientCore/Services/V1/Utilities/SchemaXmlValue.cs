//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1.Utilities;

public class SchemaXmlValue(object value)
{

    private readonly object value = value;

    public override string ToString()
    {
        return this.value switch
        {
            null => "",
            Enum enumValue => enumValue.ToString(),
            bool boolValue => boolValue.ToString().ToUpper(),
            byte byteValue => byteValue.ToString(),
            byte[] byteArrayValue => Convert.ToBase64String(byteArrayValue),
            char charValue => charValue.ToString(),
            short shortValue => shortValue.ToString(),
            ushort ushortValue => ushortValue.ToString(),
            int intValue => intValue.ToString(),
            uint uintValue => uintValue.ToString(),
            long longValue => longValue.ToString(),
            ulong ulongValue => ulongValue.ToString(),
            float singleValue => singleValue.ToString(),
            double doubleValue => doubleValue.ToString(),
            decimal decimalValue => decimalValue.ToString(),
            DateTime dateValue => dateValue.ToString("s"),
            Guid guidValue => guidValue.ToString("B"),
            string stringValue => stringValue,
            SwitchParameter switchValue => switchValue.ToBool().ToString().ToUpper(),
            _ => throw new NotImplementedException(string.Format(StringResources.ErrorValueIsInvalid, this.value)),
        };
    }

}
