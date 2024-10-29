//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common.Tests;

[Category("Karamem0.SharePoint.PowerShell.Runtime")]
public class UriQueryTests
{

    [Test()]
    public void Create_NotNull_ReturnsQuery()
    {
        var args = new
        {
            Parameters = new Dictionary<string, object>()
            {
                { "Key1", "Test Value Value1" },
                { "Key2", true },
                { "Key3", 123 },
                { "Key4", null },
            },
            Quote = false
        };
        var expected = "Key1=Test%20Value%20Value1&Key2=true&Key3=123&Key4=";
        var actual = UriQuery.Create(args.Parameters, args.Quote);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void Create_Quote_ReturnsQuery()
    {
        var args = new
        {
            Parameters = new Dictionary<string, object>()
            {
                { "Key1", "Test Value Value1" },
                { "Key2", true },
                { "Key3", 123 },
                { "Key4", null },
            },
            Quote = true
        };
        var expected = "Key1=%27Test%20Value%20Value1%27&Key2=true&Key3=123&Key4=";
        var actual = UriQuery.Create(args.Parameters, args.Quote);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void Create_Null_ReturnsEmpty()
    {
        var args = new
        {
            Parameters = default(Dictionary<string, object>),
            Quote = true
        };
        var expected = "";
        var actual = UriQuery.Create(args.Parameters, args.Quote);
        Assert.That(actual, Is.EqualTo(expected));
    }

}
