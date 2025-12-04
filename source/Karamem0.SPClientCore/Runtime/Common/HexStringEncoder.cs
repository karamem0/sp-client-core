//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

namespace Karamem0.SharePoint.PowerShell.Runtime.Common;

public static class HexStringEncoder
{

    public static BinaryData Decode(string input)
    {
        var bytes = new byte[input.Length / 2];
        for (var i = 0; i < input.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(input.Substring(i, 2), 16);
        }
        return BinaryData.FromBytes(bytes);
    }

    public static string Encode(BinaryData input)
    {
        var builder = new StringBuilder();
        foreach (var item in input.ToArray())
        {
            _ = builder.Append(item.ToString("X2"));
        }
        return builder.ToString();
    }

}
