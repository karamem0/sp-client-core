//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    public class JsonGuidConverter : JsonConverter
    {

        public JsonGuidConverter()
        {
        }

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(Guid) || objectType == typeof(Guid?))
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
            var value = Guid.Empty;
            if (reader.Value == null)
            {
                return value;
            }
            if (Guid.TryParse(reader.Value.ToString(), out value))
            {
                return value;
            }
            if (GuidConverter.TryParse(reader.Value.ToString(), out value))
            {
                return value;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null || (Guid)value == Guid.Empty)
            {
                writer.WriteNull();
            }
            else
            {
                JToken.FromObject(value).WriteTo(writer);
            }
        }

    }

}
