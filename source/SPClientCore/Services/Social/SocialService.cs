//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models.Social;
using Karamem0.SharePoint.PowerShell.PipeBinds.Social;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Social
{

    public interface ISocialService
    {

        SocialRestActor GetSocialActor(SocialActorPipeBind socialActorPipeBind);

        SocialRestFeed GetSocialFeed(SocialActorPipeBind socialActorPipeBind);

    }

    public class SocialService : ClientObjectService, ISocialService
    {

        public SocialService(ClientContext clientContext) : base(clientContext)
        {
        }

        public SocialRestActor GetSocialActor(SocialActorPipeBind socialActorPipeBind)
        {
            if (socialActorPipeBind == null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/social.feed/my");
                return this.ClientContext.GetObject<SocialRestActor>(requestUrl);
            }
            if (socialActorPipeBind.ClientObject != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/social.feed/actor(@v)?@v='{0}'", socialActorPipeBind.ClientObject.EmailAddress);
                return this.ClientContext.GetObject<SocialRestActor>(requestUrl);
            }
            if (socialActorPipeBind.Item != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/social.feed/actor(@v)?@v='{0}'", socialActorPipeBind.Item);
                return this.ClientContext.GetObject<SocialRestActor>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(SocialActorPipeBind)), nameof(SocialActorPipeBind));
        }

        public SocialRestFeed GetSocialFeed(SocialActorPipeBind socialActorPipeBind)
        {
            if (socialActorPipeBind == null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/social.feed/my/feed");
                return this.ClientContext.GetObject<SocialRestFeed>(requestUrl);
            }
            if (socialActorPipeBind.ClientObject != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/social.feed/actor(@v)/feed?@v='{0}'", socialActorPipeBind.ClientObject.AccountName);
                return this.ClientContext.GetObject<SocialRestFeed>(requestUrl);
            }
            if (socialActorPipeBind.Item != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/social.feed/actor(@v)/feed?@v='{0}'", socialActorPipeBind.Item);
                return this.ClientContext.GetObject<SocialRestFeed>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(SocialActorPipeBind)), nameof(SocialActorPipeBind));
        }

    }

}
