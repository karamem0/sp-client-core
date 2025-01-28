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
public class Base64BinaryConverterTests
{

    [Test()]
    public void TryParse_Match_ReturnsTrue()
    {
        var args = new
        {
            Input = "/Base64Binary(VGVzdCBWYWx1ZSAx)/",
        };
        var expected = Encoding.UTF8.GetBytes("Test Value 1");
        var actual = Base64BinaryConverter.TryParse(args.Input, out var result);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.True);
            Assert.That(result, Is.EqualTo(expected.ToArray()));
        });
    }

    [Test()]
    public void TryParse_DoesNotMatch_ReturnsFalse()
    {
        var args = new
        {
            Input = "VGVzdCBWYWx1ZSAx",
        };
        var actual = Base64BinaryConverter.TryParse(args.Input, out var result);
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.False);
            Assert.That(result, Is.Null);
        });
    }

}
