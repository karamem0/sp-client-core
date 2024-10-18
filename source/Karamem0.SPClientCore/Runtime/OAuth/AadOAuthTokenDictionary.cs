//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth;

public class AadOAuthTokenDictionary : Dictionary<string, AadOAuthToken>
{

    private static readonly FileInfo fileInfo = new(
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".spclientcore",
            "oauthtoken.json"
        )
    );

    public static AadOAuthTokenDictionary Load()
    {
        if (fileInfo.Exists)
        {
            var json = File.ReadAllText(fileInfo.FullName);
            if (JsonSerializerManager.Instance.TryDeserialize(json, out AadOAuthTokenDictionary oAuthTokens))
            {
                return oAuthTokens;
            }
            if (JsonSerializerManager.Instance.TryDeserialize(json, out AadOAuthToken oAuthToken))
            {
                var jwtToken = new JsonWebToken(oAuthToken.AccessToken);
                var jwtAudience = jwtToken.GetPayloadValue<string>("aud");
                return new AadOAuthTokenDictionary()
                {
                    { jwtAudience, oAuthToken }
                };
            }
        }
        return [];
    }

    public AadOAuthTokenDictionary()
    {
    }

    public void Save()
    {
        fileInfo.Directory.Create();
        using var stream = fileInfo.Open(FileMode.Create, FileAccess.Write);
        using var writer = new JsonTextWriter(new StreamWriter(stream));
        JsonSerializerManager.Instance.Serialize(writer, this);
    }

}
