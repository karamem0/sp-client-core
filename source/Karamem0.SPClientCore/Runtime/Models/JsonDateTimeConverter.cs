//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public class JsonDateTimeConverter : JsonConverter
{

    public JsonDateTimeConverter()
    {
    }

    public override bool CanRead => true;

    public override bool CanWrite => true;

    public override bool CanConvert(Type objectType)
    {
        if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var value = new DateTime();
        if (reader.Value is null)
        {
            return value;
        }
        if (DateTime.TryParse(reader.Value.ToString(), out value))
        {
            return value;
        }
        if (DateTimeConverter.TryParse(reader.Value.ToString(), out value))
        {
            return value;
        }
        return null;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value is null || (DateTime)value == new DateTime())
        {
            writer.WriteNull();
        }
        else
        {
            JToken.FromObject(value).WriteTo(writer);
        }
    }

}
