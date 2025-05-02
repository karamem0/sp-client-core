//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.Site", Id = "{e1bb82e8-0d1e-4e52-b90c-684802ab4ef6}")]
[JsonObject()]
public class SiteCollection : ClientObject
{

    [JsonProperty()]
    public virtual bool AllowCreateDeclarativeWorkflow { get; set; }

    [JsonProperty()]
    public virtual bool AllowDesigner { get; set; }

    [JsonProperty()]
    public virtual bool AllowMasterPageEditing { get; set; }

    [JsonProperty()]
    public virtual bool AllowRevertFromTemplate { get; set; }

    [JsonProperty()]
    public virtual bool AllowSaveDeclarativeWorkflowAsTemplate { get; set; }

    [JsonProperty()]
    public virtual bool AllowSavePublishDeclarativeWorkflow { get; set; }

    [JsonProperty()]
    public virtual bool AllowSelfServiceUpgrade { get; set; }

    [JsonProperty()]
    public virtual bool AllowSelfServiceUpgradeEvaluation { get; set; }

    [JsonProperty()]
    public virtual int AuditLogTrimmingRetention { get; set; }

    [JsonProperty()]
    public virtual Guid ChannelGroupId { get; set; }

    [JsonProperty()]
    public virtual string? Classification { get; set; }

    [JsonProperty()]
    public virtual int CompatibilityLevel { get; set; }

    [JsonProperty()]
    public virtual ChangeToken? CurrentChangeToken { get; set; }

    [JsonProperty()]
    public virtual bool DisableAppViews { get; set; }

    [JsonProperty()]
    public virtual bool DisableCompanyWideSharingLinks { get; set; }

    [JsonProperty()]
    public virtual bool DisableFlows { get; set; }

    [JsonProperty()]
    public virtual bool ExternalSharingTipsEnabled { get; set; }

    [JsonProperty()]
    public virtual string? GeoLocation { get; set; }

    [JsonProperty()]
    public virtual Guid GroupId { get; set; }

    [JsonProperty()]
    public virtual Guid HubSiteId { get; set; }

    [JsonProperty()]
    public virtual Guid Id { get; set; }

    [JsonProperty()]
    public virtual bool IsHubSite { get; set; }

    [JsonProperty()]
    public virtual string? LockIssue { get; set; }

    [JsonProperty()]
    public virtual int MaxItemsPerThrottledOperation { get; set; }

    [JsonProperty()]
    public virtual bool MediaTranscriptionDisabled { get; set; }

    [JsonProperty()]
    public virtual bool NeedsB2BUpgrade { get; set; }

    [JsonProperty()]
    public virtual ResourcePath? ResourcePath { get; set; }

    [JsonProperty("PrimaryUri")]
    public virtual string? PrimaryUrl { get; set; }

    [JsonProperty()]
    public virtual bool ReadOnly { get; set; }

    [JsonProperty()]
    public virtual string? RequiredDesignerVersion { get; set; }

    [JsonProperty()]
    public virtual int SandboxedCodeActivationCapability { get; set; }

    [JsonProperty()]
    public virtual Guid SensitivityLabel { get; set; }

    [JsonProperty()]
    public virtual string? SensitivityLabelId { get; set; }

    [JsonProperty()]
    public virtual string? ServerRelativeUrl { get; set; }

    [JsonProperty()]
    public virtual bool ShareByEmailEnabled { get; set; }

    [JsonProperty()]
    public virtual bool ShareByLinkEnabled { get; set; }

    [JsonProperty()]
    public virtual bool ShowUrlStructure { get; set; }

    [JsonProperty()]
    public virtual bool TrimAuditLog { get; set; }

    [JsonProperty()]
    public virtual bool UIVersionConfigurationEnabled { get; set; }

    [JsonProperty()]
    public virtual DateTime UpgradeReminderDate { get; set; }

    [JsonProperty()]
    public virtual bool UpgradeScheduled { get; set; }

    [JsonProperty()]
    public virtual DateTime UpgradeScheduledDate { get; set; }

    [JsonProperty()]
    public virtual bool Upgrading { get; set; }

    [JsonProperty()]
    public virtual string? Url { get; set; }

    [JsonProperty()]
    public virtual bool WriteLocked { get; set; }

}
