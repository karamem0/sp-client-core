//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common.Test;

[Category("Karamem0.SharePoint.PowerShell.Runtime")]
public class HexStringEncoderTests
{

    [Test()]
    public void Decode_Valid_ReturnsBinaryData()
    {
        var args = new
        {
            HexString = "010203"
        };
        var expected = new BinaryData([0x01, 0x02, 0x03]);
        var actual = HexStringEncoder.Decode(args.HexString);
        Assert.That(actual.ToArray(), Is.EquivalentTo(expected.ToArray()));
    }

    [Test()]
    public void Encode_Valid_ReturnsHexString()
    {
        var args = new
        {
            Data = new BinaryData([0x01, 0x02, 0x03])
        };
        var expected = "010203";
        var actual = HexStringEncoder.Encode(args.Data);
        Assert.That(actual, Is.EqualTo(expected));
    }

}
