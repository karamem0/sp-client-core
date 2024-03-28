//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Security;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Runtime;

public static class PSCredentialFactory
{

    public static PSCredential CreateCredential(string userName, string password)
    {
        return CreateCredential(new NetworkCredential(userName, password));
    }

    public static PSCredential CreateCredential(string userName, SecureString password)
    {
        return CreateCredential(new NetworkCredential(userName, password));
    }

    public static PSCredential CreateCredential(NetworkCredential credential)
    {
        return new PSCredential(credential.UserName, credential.SecurePassword);
    }

}
