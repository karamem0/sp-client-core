//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommunications.Connect, "KshSite")]
[OutputType(typeof(void))]
public class ConnectSiteCommand : OAuthCmdlet
{

    [Parameter(
        Mandatory = true,
        ParameterSetName = "ParamSet1",
        Position = 0,
        ValueFromPipeline = true
    )]
    [Parameter(
        Mandatory = true,
        ParameterSetName = "ParamSet2",
        Position = 0,
        ValueFromPipeline = true
    )]
    [Parameter(
        Mandatory = true,
        ParameterSetName = "ParamSet3",
        Position = 0,
        ValueFromPipeline = true
    )]
    [Parameter(
        Mandatory = true,
        ParameterSetName = "ParamSet4",
        Position = 0,
        ValueFromPipeline = true
    )]
    [Parameter(
        Mandatory = true,
        ParameterSetName = "ParamSet5",
        Position = 0,
        ValueFromPipeline = true
    )]
    public Uri Url { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public string ClientId { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
    public Uri Authority { get; private set; } = new Uri(OAuthConstants.AadAuthority, UriKind.Absolute);

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    public SwitchParameter UserMode { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public string CertificatePath { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    public SecureString CertificatePassword { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public string PrivateKeyPath { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public SwitchParameter Cached { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public SecureString ClientSecret { get; private set; }

    protected override void ProcessRecordCore()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            this.Service.ConnectWithDeviceCode(
                this.Authority,
                this.ClientId,
                this.Url,
                this.UserMode,
                this.WriteWarning
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            var certificatePath = this.GetUnresolvedProviderPathFromPSPath(this.CertificatePath);
            var certificateBytes = BinaryData.FromBytes(File.ReadAllBytes(certificatePath));
            this.Service.ConnectWithCertificate(
                this.Authority,
                this.ClientId,
                this.Url,
                certificateBytes,
                this.CertificatePassword
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            var certificatePath = this.GetUnresolvedProviderPathFromPSPath(this.CertificatePath);
            var certificateBytes = BinaryData.FromBytes(File.ReadAllBytes(certificatePath));
            var privateKeyPath = this.GetUnresolvedProviderPathFromPSPath(this.PrivateKeyPath);
            var privateKeyBytes = BinaryData.FromBytes(File.ReadAllBytes(privateKeyPath));
            this.Service.ConnectWithCertificate(
                this.Authority,
                this.ClientId,
                this.Url,
                certificateBytes,
                privateKeyBytes
            );
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            this.ValidateSwitchParameter(nameof(this.Cached));
            this.Service.ConnectWithCache(
                this.Authority,
                this.ClientId,
                this.Url
            );
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            this.Service.ConnectWithClientSecret(
                this.ClientId,
                this.ClientSecret,
                this.Url
            );
        }
    }

}
