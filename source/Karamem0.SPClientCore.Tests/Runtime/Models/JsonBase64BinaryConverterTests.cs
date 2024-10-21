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

public class JsonBase64BinaryConverterTests
{

    [Test()]
    public void CanConvertByByteArray()
    {
        var converter = new JsonBase64BinaryConverter();
        var expected = true;
        var actual = converter.CanConvert(typeof(byte[]));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvertByObject()
    {
        var converter = new JsonBase64BinaryConverter();
        var expected = false;
        var actual = converter.CanConvert(typeof(object));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJsonByValidByteArray()
    {
        var converter = new JsonBase64BinaryConverter();
        var textReader = new StringReader(/*lang=json,strict*/ "{\"value\":\"/Base64Binary(VGVzdCBWYWx1ZSAx)/\"}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.String)
        {
            _ = jsonReader.Read();
        }
        var expected = Encoding.UTF8.GetBytes("Test Value 1");
        var actual = converter.ReadJson(jsonReader, typeof(byte[]), null, null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJsonByInvalidByteArray()
    {
        var converter = new JsonBase64BinaryConverter();
        var textReader = new StringReader(/*lang=json,strict*/ "{\"value\":\"/Base64Binary(Test Value 1)\"}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.String)
        {
            _ = jsonReader.Read();
        }
        var expected = (byte[])null;
        var actual = converter.ReadJson(jsonReader, typeof(byte[]), null, null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJsonByNull()
    {
        var converter = new JsonBase64BinaryConverter();
        var textReader = new StringReader(/*lang=json,strict*/ "{\"value\":null}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.Null)
        {
            _ = jsonReader.Read();
        }
        var expected = (byte[])null;
        var actual = converter.ReadJson(jsonReader, typeof(byte[]), null, null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void WriteJsonByByteArray()
    {
        var converter = new JsonBase64BinaryConverter();
        var textWriter = new StringWriter();
        var jsonWriter = new JsonTextWriter(textWriter);
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("value");
        converter.WriteJson(jsonWriter, Encoding.UTF8.GetBytes("Test Value 1"), null);
        jsonWriter.WriteEndObject();
        var expected = /*lang=json,strict*/ "{\"value\":\"VGVzdCBWYWx1ZSAx\"}";
        var actual = textWriter.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void WriteJsonByNull()
    {
        var converter = new JsonBase64BinaryConverter();
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
