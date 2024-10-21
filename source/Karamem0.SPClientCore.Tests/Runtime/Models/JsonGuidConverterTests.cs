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

namespace Karamem0.SharePoint.PowerShell.Tests.Runtime.Models;

public class JsonGuidConverterTests
{

    [Test()]
    public void CanConvertByGuid()
    {
        var converter = new JsonGuidConverter();
        var expected = true;
        var actual = converter.CanConvert(typeof(Guid));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvertByNullableGuid()
    {
        var converter = new JsonGuidConverter();
        var expected = true;
        var actual = converter.CanConvert(typeof(Guid?));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvertByObject()
    {
        var converter = new JsonGuidConverter();
        var expected = false;
        var actual = converter.CanConvert(typeof(object));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJsonByValidGuid()
    {
        var converter = new JsonGuidConverter();
        var textReader = new StringReader(/*lang=json,strict*/ "{\"value\":\"/Guid(8155c423-5475-4cbc-89f9-e0f7b5f2bc68)/\"}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.String)
        {
            _ = jsonReader.Read();
        }
        var expected = Guid.Parse("8155c423-5475-4cbc-89f9-e0f7b5f2bc68");
        var actual = converter.ReadJson(jsonReader, typeof(Guid), null, null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJsonByInvalidGuid()
    {
        var converter = new JsonGuidConverter();
        var textReader = new StringReader(/*lang=json,strict*/ "{\"value\":\"/Guid(Test Value 1)\"}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.String)
        {
            _ = jsonReader.Read();
        }
        var expected = (Guid?)null;
        var actual = converter.ReadJson(jsonReader, typeof(Guid), null, null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJsonByNull()
    {
        var converter = new JsonGuidConverter();
        var textReader = new StringReader(/*lang=json,strict*/ "{\"value\":null}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.Null)
        {
            _ = jsonReader.Read();
        }
        var expected = new Guid();
        var actual = converter.ReadJson(jsonReader, typeof(Guid), null, null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void WriteJsonByGuid()
    {
        var converter = new JsonGuidConverter();
        var textWriter = new StringWriter();
        var jsonWriter = new JsonTextWriter(textWriter);
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("value");
        converter.WriteJson(jsonWriter, Guid.Parse("8155c423-5475-4cbc-89f9-e0f7b5f2bc68"), null);
        jsonWriter.WriteEndObject();
        var expected = /*lang=json,strict*/ "{\"value\":\"8155c423-5475-4cbc-89f9-e0f7b5f2bc68\"}";
        var actual = textWriter.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void WriteJsonByNull()
    {
        var converter = new JsonGuidConverter();
        var textWriter = new StringWriter();
        var jsonWriter = new JsonTextWriter(textWriter);
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("value");
        converter.WriteJson(jsonWriter, null, null);
        jsonWriter.WriteEndObject();
        var expected = /*lang=json,strict*/ "{\"value\":null}";
        var actual = textWriter.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }

}