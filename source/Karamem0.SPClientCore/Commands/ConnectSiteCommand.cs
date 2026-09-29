//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Commands;
using Karamem0.SharePoint.PowerShell.Runtime.OAuth;
using System.IO;
using System.Management.Automation;
using System.Security;

namespace Karamem0.SharePoint.PowerShell.Commands;

[Cmdlet(VerbsCommunications.Connect, "Site")]
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
    [Parameter(
        Mandatory = true,
        ParameterSetName = "ParamSet6",
        Position = 0,
        ValueFromPipeline = true
    )]
    [Parameter(
        Mandatory = true,
        ParameterSetName = "ParamSet7",
        Position = 0,
        ValueFromPipeline = true
    )]
    public Uri? Url { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public string? ClientId { get; private set; }

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet3")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet5")]
    [Parameter(Mandatory = false, ParameterSetName = "ParamSet6")]
    public Uri Authority { get; private set; } = new Uri(OAuthConstants.AadAuthority, UriKind.Absolute);

    [Parameter(Mandatory = false, ParameterSetName = "ParamSet1")]
    public SwitchParameter UserMode { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public byte[]? Certificate { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public string? CertificatePath { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet2")]
    [Parameter(Mandatory = true, ParameterSetName = "ParamSet4")]
    public SecureString? CertificatePassword { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet3")]
    public byte[]? PrivateKey { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet5")]
    public string? PrivateKeyPath { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet6")]
    public SwitchParameter Cached { get; private set; }

    [Parameter(Mandatory = true, ParameterSetName = "ParamSet7")]
    public SecureString? ClientSecret { get; private set; }

    protected override async Task ProcessRecordAsync()
    {
        if (this.ParameterSetName == "ParamSet1")
        {
            _ = this.ClientId ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ClientId));
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            await this.Service.ConnectWithDeviceCodeAsync(
                this.Authority,
                this.ClientId,
                this.Url,
                this.UserMode,
                this.WriteWarning
            );
        }
        if (this.ParameterSetName == "ParamSet2")
        {
            _ = this.ClientId ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ClientId));
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            _ = this.Certificate ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Certificate));
            _ = this.CertificatePassword ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.CertificatePassword));
            await this.Service.ConnectWithCertificateAsync(
                this.Authority,
                this.ClientId,
                this.Url,
                BinaryData.FromBytes(this.Certificate),
                this.CertificatePassword
            );
        }
        if (this.ParameterSetName == "ParamSet3")
        {
            _ = this.ClientId ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ClientId));
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            _ = this.Certificate ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Certificate));
            _ = this.PrivateKey ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.PrivateKey));
            await this.Service.ConnectWithCertificateAsync(
                this.Authority,
                this.ClientId,
                this.Url,
                BinaryData.FromBytes(this.Certificate),
                BinaryData.FromBytes(this.PrivateKey)
            );
        }
        if (this.ParameterSetName == "ParamSet4")
        {
            _ = this.ClientId ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ClientId));
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            _ = this.CertificatePath ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.CertificatePath));
            _ = this.CertificatePassword ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.CertificatePassword));
            var certificatePath = this.GetUnresolvedProviderPathFromPSPath(this.CertificatePath);
            var certificateBytes = BinaryData.FromBytes(File.ReadAllBytes(certificatePath));
            await this.Service.ConnectWithCertificateAsync(
                this.Authority,
                this.ClientId,
                this.Url,
                certificateBytes,
                this.CertificatePassword
            );
        }
        if (this.ParameterSetName == "ParamSet5")
        {
            _ = this.ClientId ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ClientId));
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            _ = this.CertificatePath ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.CertificatePath));
            _ = this.PrivateKeyPath ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.PrivateKeyPath));
            var certificatePath = this.GetUnresolvedProviderPathFromPSPath(this.CertificatePath);
            var certificateBytes = BinaryData.FromBytes(File.ReadAllBytes(certificatePath));
            var privateKeyPath = this.GetUnresolvedProviderPathFromPSPath(this.PrivateKeyPath);
            var privateKeyBytes = BinaryData.FromBytes(File.ReadAllBytes(privateKeyPath));
            await this.Service.ConnectWithCertificateAsync(
                this.Authority,
                this.ClientId,
                this.Url,
                certificateBytes,
                privateKeyBytes
            );
        }
        if (this.ParameterSetName == "ParamSet6")
        {
            this.ValidateSwitchParameter(nameof(this.Cached));
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            await this.Service.ConnectWithCacheAsync(this.Authority, this.Url);
        }
        if (this.ParameterSetName == "ParamSet7")
        {
            _ = this.ClientId ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ClientId));
            _ = this.ClientSecret ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.ClientSecret));
            _ = this.Url ?? throw new ArgumentException(StringResources.ErrorValueCannotBeNull, nameof(this.Url));
            await this.Service.ConnectWithClientSecretAsync(
                this.ClientId,
                this.ClientSecret,
                this.Url
            );
        }
    }

}
