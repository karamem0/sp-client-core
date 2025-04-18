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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public class ClientRequestValue
{

    public static ClientRequestValue Create(object input)
    {
        if (TryCreate(input, out var output))
        {
            return output;
        }
        throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, input.ToString()), nameof(input));
    }

    public static bool TryCreate(object input, out ClientRequestValue output)
    {
        switch (input)
        {
            case null:
                output = new ClientRequestValue()
                {
                    Type = "Null",
                    Value = null
                };
                return true;
            case Enum:
                output = new ClientRequestValue()
                {
                    Type = "Enum",
                    Value = Convert
                        .ToInt32(input)
                        .ToString(CultureInfo.InvariantCulture)
                };
                return true;
            case bool boolValue:
                output = new ClientRequestValue()
                {
                    Type = "Boolean",
                    Value = boolValue
                        .ToString()
                        .ToLower()
                };
                return true;
            case byte byteValue:
                output = new ClientRequestValue()
                {
                    Type = "Byte",
                    Value = byteValue.ToString()
                };
                return true;
            case byte[] byteArrayValue:
                output = new ClientRequestValue()
                {
                    Type = "Binary",
                    Value = Convert.ToBase64String(byteArrayValue)
                };
                return true;
            case BinaryData binaryDataValue:
                output = new ClientRequestValue()
                {
                    Type = "Binary",
                    Value = Convert.ToBase64String(binaryDataValue)
                };
                return true;
            case char charValue:
                output = new ClientRequestValue()
                {
                    Type = "Char",
                    Value = charValue.ToString()
                };
                return true;
            case short shortValue:
                output = new ClientRequestValue()
                {
                    Type = "Int16",
                    Value = shortValue.ToString()
                };
                return true;
            case ushort ushortValue:
                output = new ClientRequestValue()
                {
                    Type = "UInt16",
                    Value = ushortValue.ToString()
                };
                return true;
            case int intValue:
                output = new ClientRequestValue()
                {
                    Type = "Int32",
                    Value = intValue.ToString()
                };
                return true;
            case uint uintValue:
                output = new ClientRequestValue()
                {
                    Type = "UInt32",
                    Value = uintValue.ToString()
                };
                return true;
            case long longValue:
                output = new ClientRequestValue()
                {
                    Type = "Int64",
                    Value = longValue.ToString()
                };
                return true;
            case ulong ulongValue:
                output = new ClientRequestValue()
                {
                    Type = "UInt64",
                    Value = ulongValue.ToString()
                };
                return true;
            case float singleValue:
                output = new ClientRequestValue()
                {
                    Type = "Single",
                    Value = singleValue.ToString()
                };
                return true;
            case double doubleValue:
                output = new ClientRequestValue()
                {
                    Type = "Double",
                    Value = doubleValue.ToString()
                };
                return true;
            case decimal decimalValue:
                output = new ClientRequestValue()
                {
                    Type = "Decimal",
                    Value = decimalValue.ToString()
                };
                return true;
            case DateTime dateValue:
                output = new ClientRequestValue()
                {
                    Type = "DateTime",
                    Value = dateValue.ToString("o", CultureInfo.InvariantCulture)
                };
                return true;
            case Guid guidValue:
                output = new ClientRequestValue()
                {
                    Type = "Guid",
                    Value = guidValue.ToString("B")
                };
                return true;
            case Uri uriValue:
                output = new ClientRequestValue()
                {
                    Type = "String",
                    Value = uriValue.ToString()
                };
                return true;
            case string stringValue:
                output = new ClientRequestValue()
                {
                    Type = "String",
                    Value = stringValue
                };
                return true;
            case SwitchParameter switchValue:
                output = new ClientRequestValue()
                {
                    Type = "Boolean",
                    Value = switchValue
                        .ToBool()
                        .ToString()
                        .ToLower()
                };
                return true;
            case ODataObject oDataValue:
                output = new ClientRequestValue()
                {
                    Type = "String",
                    Value = JsonSerializerManager.Instance.Serialize(oDataValue)
                };
                return true;
            default:
                output = null;
                return false;
        }
    }

    private ClientRequestValue()
    {
    }

    public string Type { get; private set; }

    public string Value { get; private set; }

}
