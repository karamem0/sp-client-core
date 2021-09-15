//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    public static class JsonSerializerManager
    {

        private static readonly Lazy<JsonSerializer> LazyJsonSerializer =
            new Lazy<JsonSerializer>(() =>
                JsonSerializer.Create(new JsonSerializerSettings()
                {
                    Converters = new List<JsonConverter>()
                    {
                        new JsonBase64BinaryConverter(),
                        new JsonDateTimeConverter(),
                        new JsonGuidConverter()
                    },
                    NullValueHandling = NullValueHandling.Ignore
                }));

        public static JsonSerializer JsonSerializer => LazyJsonSerializer.Value;

    }

}
