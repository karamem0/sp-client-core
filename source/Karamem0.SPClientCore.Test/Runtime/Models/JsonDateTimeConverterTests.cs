//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models.Test;

[Category("Karamem0.SharePoint.PowerShell.Runtime")]
public class JsonDateTimeConverterTests
{

    [Test()]
    public void CanConvert_DateTime_ReturnsTrue()
    {
        var converter = new JsonDateTimeConverter();
        var expected = true;
        var actual = converter.CanConvert(typeof(DateTime));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvert_NullableDateTime_ReturnsTrue()
    {
        var converter = new JsonDateTimeConverter();
        var expected = true;
        var actual = converter.CanConvert(typeof(DateTime?));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void CanConvert_Object_ReturnsFalse()
    {
        var converter = new JsonDateTimeConverter();
        var expected = false;
        var actual = converter.CanConvert(typeof(object));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJson_Valid_ReturnsDateTime()
    {
        var converter = new JsonDateTimeConverter();
        var textReader = new StringReader( /*lang=json,strict*/ "{\"value\":\"/Date(2000,00,01,15,30,45,500)/\"}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.String)
        {
            _ = jsonReader.Read();
        }
        var expected = new DateTime(
            2000,
            1,
            1,
            15,
            30,
            45,
            500,
            DateTimeKind.Utc
        );
        var actual = converter.ReadJson(
            jsonReader,
            typeof(DateTime),
            null,
            null
        );
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJson_Invalid_ReturnsNull()
    {
        var converter = new JsonDateTimeConverter();
        var textReader = new StringReader( /*lang=json,strict*/ "{\"value\":\"/Date(Test Value 1)\"}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.String)
        {
            _ = jsonReader.Read();
        }
        var expected = (DateTime?)null;
        var actual = converter.ReadJson(
            jsonReader,
            typeof(DateTime),
            null,
            null
        );
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ReadJson_Null_ReturnsDefault()
    {
        var converter = new JsonDateTimeConverter();
        var textReader = new StringReader( /*lang=json,strict*/ "{\"value\":null}");
        var jsonReader = new JsonTextReader(textReader);
        while (jsonReader.TokenType != JsonToken.Null)
        {
            _ = jsonReader.Read();
        }
        var expected = new DateTime();
        var actual = converter.ReadJson(
            jsonReader,
            typeof(DateTime),
            null,
            null
        );
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void WriteJson_DateTime_ReturnsDateTimeString()
    {
        var converter = new JsonDateTimeConverter();
        var textWriter = new StringWriter();
        var jsonWriter = new JsonTextWriter(textWriter);
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("value");
        converter.WriteJson(
            jsonWriter,
            new DateTime(
                2000,
                1,
                1,
                15,
                30,
                45,
                500,
                DateTimeKind.Utc
            ),
            null
        );
        jsonWriter.WriteEndObject();
        var expected = /*lang=json,strict*/ "{\"value\":\"2000-01-01T15:30:45.5Z\"}";
        var actual = textWriter.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void WriteJson_Null_ReturnsNull()
    {
        var converter = new JsonDateTimeConverter();
        var textWriter = new StringWriter();
        var jsonWriter = new JsonTextWriter(textWriter);
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("value");
        converter.WriteJson(
            jsonWriter,
            null,
            null
        );
        jsonWriter.WriteEndObject();
        var expected = /*lang=json,strict*/ "{\"value\":null}";
        var actual = textWriter.ToString();
        Assert.That(actual, Is.EqualTo(expected));
    }

}
