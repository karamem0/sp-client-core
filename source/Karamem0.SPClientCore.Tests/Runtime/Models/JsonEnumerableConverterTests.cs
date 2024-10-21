//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Karamem0.SharePoint.PowerShell.Models.V1;

namespace Karamem0.SharePoint.PowerShell.Tests.Runtime.Models;

public class JsonEnumerableConverterTests
{

    [Test()]
    public void CanConvertByCollection()
    {
        var converter = new JsonEnumerableConverter();
        var expected = true;
        var actual = converter.CanConvert(typeof(IReadOnlyCollection<Site>));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvertByArray()
    {
        var converter = new JsonEnumerableConverter();
        var expected = false;
        var actual = converter.CanConvert(typeof(string[]));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvertByObject()
    {
        var converter = new JsonEnumerableConverter();
        var expected = false;
        var actual = converter.CanConvert(typeof(object));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJsonByValidCollection()
    {
        var converter = new JsonEnumerableConverter();
        var textReader = new StringReader(/*lang=json,strict*/ "{\"value\":[{\"_ObjectType_\":\"SP.Web\"}]}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.StartArray)
        {
            _ = jsonReader.Read();
        }
        var expected = JsonConvert.DeserializeObject<Site[]>(/*lang=json,strict*/ "[{\"_ObjectType_\":\"SP.Web\"}]");
        var actual = converter.ReadJson(jsonReader, typeof(IReadOnlyCollection<Site>), null, new JsonSerializer());
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJsonByInvalidCollection()
    {
        var converter = new JsonEnumerableConverter();
        var textReader = new StringReader(/*lang=json,strict*/ "{\"value\":[\"SP.Web\"]}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.StartArray)
        {
            _ = jsonReader.Read();
        }
        var expected = new string[] { "SP.Web" };
        var actual = converter.ReadJson(jsonReader, typeof(IReadOnlyCollection<string>), null, new JsonSerializer());
        Assert.That(actual, Is.EqualTo(expected));
    }

}
