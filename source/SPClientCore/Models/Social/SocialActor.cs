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

namespace Karamem0.SharePoint.PowerShell.Models.Social
{

    [JsonObject(Id = "SP.Social.SocialActor")]
    public class SocialActor : ClientObject
    {

        public SocialActor()
        {
        }

        [JsonProperty()]
        public string AccountName { get; private set; }

        [JsonProperty()]
        public string ActorType { get; private set; }

        [JsonProperty()]
        public bool? CanFollow { get; private set; }

        [JsonProperty("ContentUri")]
        public string ContentUrl { get; private set; }

        [JsonProperty()]
        public string EmailAddress { get; private set; }

        [JsonProperty("FollowedContentUri")]
        public string FollowedContentUrl { get; private set; }

        [JsonProperty()]
        public string Id { get; private set; }

        [JsonProperty("ImageUri")]
        public string ImageUrl { get; private set; }

        [JsonProperty()]
        public bool? IsFollowed { get; private set; }

        [JsonProperty("LibraryUri")]
        public string LibraryUrl { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty("PersonalSiteUri")]
        public string PersonalSiteUrl { get; private set; }

        [JsonProperty()]
        public string Status { get; private set; }

        [JsonProperty()]
        public string StatusText { get; private set; }

        [JsonProperty()]
        public Guid? TagGuid { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public string TypeId { get; private set; }

        [JsonProperty("Uri")]
        public string Url { get; private set; }

    }

}
