//
// Copyright (c) 2020 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.OAuth
{

    [JsonObject()]
    public class OAuthToken : OAuthMessage
    {

        private static readonly string BasePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".spclientcore"
        );

        private static readonly string FileName = "oauthtoken.json";

        public static OAuthToken Load()
        {
            var file = new FileInfo(Path.Combine(BasePath, FileName));
            if (file.Exists)
            {
                using (var stream = file.OpenRead())
                using (var reader = new JsonTextReader(new StreamReader(stream)))
                {
                    return JsonSerializerManager.JsonSerializer.Deserialize<OAuthToken>(reader);
                }
            }
            else
            {
                throw new InvalidOperationException(StringResources.ErrorAccessTokenIsNotCached);
            }
        }

        public OAuthToken()
        {
        }

        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        [JsonProperty("scope")]
        public string Scope { get; private set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; private set; }

        [JsonProperty("ext_expires_in")]
        public int ExtExpiresIn { get; private set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        public void Save()
        {
            Directory.CreateDirectory(BasePath);
            using (var stream = File.Open(Path.Combine(BasePath, FileName), FileMode.OpenOrCreate, FileAccess.Write))
            using (var writer = new JsonTextWriter(new StreamWriter(stream)))
            {
                JsonSerializerManager.JsonSerializer.Serialize(writer, this);
            }
        }

    }

}
