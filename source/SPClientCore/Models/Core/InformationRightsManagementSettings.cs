//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.InformationRightsManagementSettings")]
    public class InformationRightsManagementSettings : ClientObject
    {

        public InformationRightsManagementSettings()
        {
        }

        [JsonProperty()]
        public bool? AllowPrint { get; private set; }

        [JsonProperty()]
        public bool? AllowScript { get; private set; }

        [JsonProperty()]
        public bool? AllowWriteCopy { get; private set; }

        [JsonProperty()]
        public bool? DisableDocumentBrowserView { get; private set; }

        [JsonProperty()]
        public int? DocumentAccessExpireDays { get; private set; }

        [JsonProperty()]
        public DateTime? DocumentLibraryProtectionExpireDate { get; private set; }

        [JsonProperty()]
        public bool? EnableDocumentAccessExpire { get; private set; }

        [JsonProperty()]
        public bool? EnableDocumentBrowserPublishingView { get; private set; }

        [JsonProperty()]
        public bool? EnableGroupProtection { get; private set; }

        [JsonProperty()]
        public bool? EnableLicenseCacheExpire { get; private set; }

        [JsonProperty()]
        public string GroupName { get; private set; }

        [JsonProperty()]
        public bool? IrmEnabled { get; private set; }

        [JsonProperty()]
        public int? LicenseCacheExpireDays { get; private set; }

        [JsonProperty()]
        public string PolicyDescription { get; private set; }

        [JsonProperty()]
        public string PolicyTitle { get; private set; }

        [JsonProperty()]
        public string TemplateId { get; private set; }

    }

}
