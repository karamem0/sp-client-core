//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests
{

    public class PSCmdletContext : IDisposable
    {

        public IConfigurationRoot AppSettings { get; private set; }

        public Runspace Runspace { get; private set; }

        public PSCmdletContext()
        {
            this.AppSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("SPClientCore.Tests.config.json")
                .Build();
            this.Runspace = RunspaceFactory.CreateRunspace();
            this.Runspace.Open();
            this.Runspace.InvokeCommand(
                "Set-ExecutionPolicy",
                new Dictionary<string, object>()
                {
                    { "ExecutionPolicy", "RemoteSigned" }
                });
            this.Runspace.InvokeCommand(
                "Import-Module",
                new Dictionary<string, object>()
                {
                    { "Name", "./SPClientCore.psd1" }
                });
            if (this.AppSettings["ServiceType"] == "Server")
            {
                this.Runspace.InvokeCommand(
                    "Connect-SPServer",
                    new Dictionary<string, object>()
                    {
                        { "Url", this.AppSettings["LoginUrl"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            this.AppSettings["LoginUserName"],
                            this.AppSettings["LoginPassword"]) }
                    });
            }
            if (this.AppSettings["ServiceType"] == "Online")
            {
                this.Runspace.InvokeCommand(
                    "Connect-SPOnline",
                    new Dictionary<string, object>()
                    {
                        { "Url", this.AppSettings["LoginUrl"] },
                        { "Credential", PSCredentialFactory.CreateCredential(
                            this.AppSettings["LoginUserName"],
                            this.AppSettings["LoginPassword"]) }
                    });
            }
            this.Runspace.InvokeCommand(
                "Select-SPWeb",
                new Dictionary<string, object>()
                {
                    { "Web", this.AppSettings["Web1Id"] }
                }
            );
        }

        public void Dispose()
        {
            if (this.Runspace != null)
            {
                this.Runspace.Dispose();
                this.Runspace = null;
            }
        }

        public string GetUserEmail(string userName)
        {
            return $"{userName}@{this.AppSettings["LoginDomainName"]}";
        }

        public string GetUserLoginName(string userName)
        {
            if (this.AppSettings["ServiceType"] == "Server")
            {
                return $"i:0#.w|{this.AppSettings["LoginDomainName"].Split('.')[0].ToUpper()}\\{userName}";
            }
            if (this.AppSettings["ServiceType"] == "Online")
            {
                return $"i:0#.f|membership|{userName}@{this.AppSettings["LoginDomainName"]}";
            }
            throw new InvalidOperationException();
        }

    }

}
