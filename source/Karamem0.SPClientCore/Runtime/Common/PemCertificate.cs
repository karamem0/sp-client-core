//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common;

public class PemCertificate(BinaryData certData, BinaryData keyData)
{

    public string Thumbprint
    {
        get
        {
            var base64 = certData.ToString()
                .Replace("-----BEGIN CERTIFICATE-----", "")
                .Replace("-----END CERTIFICATE-----", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Trim();
            var bytes = Convert.FromBase64String(base64);
            var certificate = new X509Certificate2(bytes);
            var thumbprint = certificate.Thumbprint;
            return thumbprint;
        }
    }

    public RSA RSA
    {
        get
        {
            var base64 = keyData.ToString()
                .Replace("-----BEGIN PRIVATE KEY-----", "")
                .Replace("-----END PRIVATE KEY-----", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Trim();
            var bytes = Convert.FromBase64String(base64);
            var rsa = RSA.Create();
            rsa.ImportPkcs8PrivateKey(bytes, out var _);
            return rsa;
        }
    }

}
