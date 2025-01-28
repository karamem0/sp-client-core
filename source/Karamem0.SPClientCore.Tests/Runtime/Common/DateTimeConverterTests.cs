//
// Copyright (c) 2018-2025 karamem0
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
public class DateTimeConverterTests
{

    [Test()]
    public void TryParse_Match_ReturnsTrue()
    {
        var args = new
        {
            Input = "/Date(2000,00,01,15,30,45,500)/",
        };
        var expected = new DateTime(2000, 1, 1, 15, 30, 45, 500, DateTimeKind.Utc);
        var actual = DateTimeConverter.TryParse(args.Input, out var result);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.True);
            Assert.That(result, Is.EqualTo(expected));
        });
    }

    [Test()]
    public void TryParse_DoesNotMatch_ReturnsFalse()
    {
        var args = new
        {
            Input = "2000,00,01,15,30,45,500",
        };
        var actual = DateTimeConverter.TryParse(args.Input, out var result);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.False);
            Assert.That(result, Is.Default);
        });
    }

}
