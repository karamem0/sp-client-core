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
using System.Management.Automation.Runspaces;
using System.Runtime.InteropServices;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Test.Utility;

public class PSCmdletContext : IDisposable
{

    public IConfigurationRoot AppSettings { get; private set; }

    public Runspace Runspace { get; private set; }

    public PSCmdletContext()
    {
        this.AppSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("SPClientCore.Test.config.json")
            .Build();
        this.Runspace = RunspaceFactory.CreateRunspace();
        this.Runspace.Open();
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            _ = this.Runspace.InvokeCommand(
                "Set-ExecutionPolicy",
                new Dictionary<string, object>()
                {
                    {
                        "ExecutionPolicy", "RemoteSigned"
                    }
                }
            );
        }
        _ = this.Runspace.InvokeCommand(
            "Import-Module",
            new Dictionary<string, object>()
            {
                {
                    "Name", "./SPClientCore.psd1"
                }
            }
        );
    }

    public void Dispose()
    {
        if (this.Runspace is not null)
        {
            this.Runspace.Dispose();
            this.Runspace = null;
        }
        GC.SuppressFinalize(this);
    }

}
