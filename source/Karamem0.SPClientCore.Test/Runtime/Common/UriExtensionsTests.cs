//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common.Test;

[Category("Karamem0.SharePoint.PowerShell.Runtime")]
public class UriExtensionsTests
{

    [Test()]
    public void ConcatPath_WithoutFormat_ReturnsUri()
    {
        var args = new
        {
            Uri = new Uri("http://example.com"),
            Path = "path/to/resource"
        };
        var expected = "http://example.com/path/to/resource";
        var actual = UriExtensions.ConcatPath(args.Uri, args.Path);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ConcatPath_WithFormat_ReturnsUri()
    {
        var args = new
        {
            Uri = new Uri("http://example.com"),
            Path = "path/{0}/{1}",
            Args = new string[]
            {
                "to", "resource"
            }
        };
        var expected = "http://example.com/path/to/resource";
        var actual = UriExtensions.ConcatPath(
            args.Uri,
            args.Path,
            args.Args
        );
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ConcatQuery_WithoutQuestionMark_ReturnsUri()
    {
        var args = new
        {
            Uri = new Uri("http://example.com"),
            Query = "key=value"
        };
        var expected = "http://example.com?key=value";
        var actual = UriExtensions.ConcatQuery(args.Uri, args.Query);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void ConcatQuery_WithQuestionMark_ReturnsUri()
    {
        var args = new
        {
            Uri = new Uri("http://example.com"),
            Query = "?key=value"
        };
        var expected = "http://example.com?key=value";
        var actual = UriExtensions.ConcatQuery(args.Uri, args.Query);
        Assert.That(actual, Is.EqualTo(expected));
    }

}
