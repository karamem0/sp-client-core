//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.PipeBinds
{

    public class FolderPipeBind : ClientObjectPipeBind<Folder>
    {

        public FolderPipeBind(Folder inputObject) : base(inputObject)
        {
        }

        public FolderPipeBind(Uri inputUrl)
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

        public FolderPipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            else if (Uri.TryCreate(inputString, UriKind.Relative, out var inputUrl))
            {
                this.ServerRelativeUrl = inputUrl;
            }
            else
            {
                throw new FormatException();
            }
        }

        public Uri ServerRelativeUrl { get; private set; }

    }

}
