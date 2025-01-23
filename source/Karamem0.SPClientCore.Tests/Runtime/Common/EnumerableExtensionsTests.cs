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
public class EnumerableExtensionsTests
{

    [Test()]
    public void Chunk_NotNull_ReturnsChunks()
    {
        var args = new
        {
            Array = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            },
            Size = 3
        };
        var expected = new int[][]
        {
            [1, 2, 3], [4, 5, 6], [7, 8, 9], [10]
        };
        var actual = EnumerableExtensions.Chunks(args.Array, args.Size).ToArray();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test()]
    public void Chunk_Null_ThrowsException()
    {
        var args = new
        {
            Array = default(int[]),
            Size = 3
        };
        _ = Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.Chunks(args.Array, args.Size).ToArray());
    }

    [Test()]
    public void Chunk_Zero_ThrowsException()
    {
        var args = new
        {
            Array = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            },
            Size = 0
        };
        _ = Assert.Throws<ArgumentException>(() => EnumerableExtensions.Chunks(args.Array, args.Size).ToArray());
    }

}
