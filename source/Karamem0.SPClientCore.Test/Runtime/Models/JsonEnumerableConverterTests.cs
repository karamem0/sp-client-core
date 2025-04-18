//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models.Test;

[Category("Karamem0.SharePoint.PowerShell.Runtime")]
public class JsonEnumerableConverterTests
{

    [Test()]
    public void CanConvert_Collection_ReturnsTrue()
    {
        var converter = new JsonEnumerableConverter();
        var expected = true;
        var actual = converter.CanConvert(typeof(IReadOnlyCollection<Site>));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvert_Array_ReturnsFalse()
    {
        var converter = new JsonEnumerableConverter();
        var expected = false;
        var actual = converter.CanConvert(typeof(string[]));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvert_Object_ReturnsFalse()
    {
        var converter = new JsonEnumerableConverter();
        var expected = false;
        var actual = converter.CanConvert(typeof(object));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJson_Valid_ReturnsClientObjectCollection()
    {
        var converter = new JsonEnumerableConverter();
        var textReader = new StringReader( /*lang=json,strict*/ "{\"value\":[{\"_ObjectType_\":\"SP.Web\"}]}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.StartArray)
        {
            _ = jsonReader.Read();
        }
        var expected = JsonConvert.DeserializeObject<Site[]>( /*lang=json,strict*/ "[{\"_ObjectType_\":\"SP.Web\"}]");
        var actual = converter.ReadJson(
            jsonReader,
            typeof(IReadOnlyCollection<Site>),
            null,
            new JsonSerializer()
        );
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJson_Invalid_ReturnsStringCollection()
    {
        var converter = new JsonEnumerableConverter();
        var textReader = new StringReader( /*lang=json,strict*/ "{\"value\":[\"SP.Web\"]}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.StartArray)
        {
            _ = jsonReader.Read();
        }
        var expected = new string[]
        {
            "SP.Web"
        };
        var actual = converter.ReadJson(
            jsonReader,
            typeof(IReadOnlyCollection<string>),
            null,
            new JsonSerializer()
        );
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJson_Null_ReturnsNull()
    {
        var converter = new JsonEnumerableConverter();
        var textReader = new StringReader( /*lang=json,strict*/ "{\"value\":null}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.Null)
        {
            _ = jsonReader.Read();
        }
        var expected = default(IReadOnlyCollection<string>);
        var actual = converter.ReadJson(
            jsonReader,
            typeof(IReadOnlyCollection<string>),
            null,
            new JsonSerializer()
        );
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void WriteJson_ThrowsException()
    {
        var converter = new JsonEnumerableConverter();
        var textWriter = new StringWriter();
        var jsonWriter = new JsonTextWriter(textWriter);
        _ = Assert.Throws<NotImplementedException>(
            () => converter.WriteJson(
                jsonWriter,
                null,
                null
            )
        );
    }

}
