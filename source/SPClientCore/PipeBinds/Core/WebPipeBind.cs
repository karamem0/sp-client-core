//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.PipeBinds.Core
{

    public class WebPipeBind : ClientObjectPipeBind<Web>
    {

        public WebPipeBind(Web inputObject) : base(inputObject)
        {
        }

        public WebPipeBind(Guid? inputId)
        {
            if (inputId == null)
            {
                throw new ArgumentNullException(nameof(inputId));
            }
            this.Id = inputId;
        }

        public WebPipeBind(Uri inputUrl)
        {
            if (inputUrl == null)
            {
                throw new ArgumentNullException(nameof(inputUrl));
            }
            if (inputUrl.IsAbsoluteUri)
            {
                inputUrl = new Uri(inputUrl.AbsolutePath, UriKind.Relative);
            }
            this.ServerRelativeUrl = inputUrl;
        }

        public WebPipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            else if (Guid.TryParse(inputString, out var inputId))
            {
                this.Id = inputId;
            }
            else if (Uri.TryCreate(inputString, UriKind.Relative, out var inputRelativeUrl))
            {
                this.ServerRelativeUrl = inputRelativeUrl;
            }
            else if (Uri.TryCreate(inputString, UriKind.Absolute, out var inputAbsoluteUrl))
            {
                this.ServerRelativeUrl = new Uri(inputAbsoluteUrl.AbsolutePath, UriKind.Relative);
            }
            else
            {
                throw new FormatException();
            }
        }

        public Guid? Id { get; private set; }

        public Uri ServerRelativeUrl { get; private set; }

    }

}
