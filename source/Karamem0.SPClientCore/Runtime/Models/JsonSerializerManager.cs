//
// Copyright (c) 2018-2024 karamem0
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

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public static class JsonSerializerManager
{

    private static readonly Lazy<JsonSerializer> LazyJsonSerializer =
        new(() =>
            JsonSerializer.Create(new JsonSerializerSettings()
            {
                Converters = [
                    new JsonBase64BinaryConverter(),
                    new JsonDateTimeConverter(),
                    new JsonGuidConverter()
                ],
                MaxDepth = 128,
                NullValueHandling = NullValueHandling.Ignore
            }));

    public static JsonSerializer JsonSerializer => LazyJsonSerializer.Value;

}
