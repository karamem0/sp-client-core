//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Test.Utility;

public class PSCmdletOptions
{

    public static readonly Lazy<PSCmdletOptions> instance = new(() =>
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("SPClientCore.Test.Utility.config.json");
            var config = builder.Build();
            var options = config.Get<PSCmdletOptions>();
            return options;
        }
    );

    public static PSCmdletOptions Instance => instance.Value;

    public string ImageFileBase64 { get; set; }

    public string SubscriptionNotificationUrl { get; set; }

}
