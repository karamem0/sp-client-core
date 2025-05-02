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

[ClientObject(Name = "SP.List", Id = "{d89f0b18-614e-4b4a-bac0-fd6142b55448}")]
[JsonObject()]
public class List : SecurableObject
{

    [JsonProperty()]
    public virtual bool AllowContentTypes { get; set; }

    [JsonProperty()]
    public virtual int BaseTemplate { get; set; }

    [JsonProperty()]
    public virtual BaseType? BaseType { get; set; }

    [JsonProperty()]
    public virtual BrowserFileHandling? BrowserFileHandling { get; set; }

    [JsonProperty()]
    public virtual bool ContentTypesEnabled { get; set; }

    [JsonProperty()]
    public virtual bool CrawlNonDefaultViews { get; set; }

    [JsonProperty()]
    public virtual DateTime Created { get; set; }

    [JsonProperty()]
    public virtual ChangeToken? CurrentChangeToken { get; set; }

    [JsonProperty()]
    public virtual CustomActionElementEnumerable? CustomActionElements { get; set; }

    [JsonProperty()]
    public virtual ListDataSource? DataSource { get; set; }

    [JsonProperty()]
    public virtual Guid DefaultContentApprovalWorkflowId { get; set; }

    [JsonProperty()]
    public virtual string? DefaultDisplayFormUrl { get; set; }

    [JsonProperty()]
    public virtual string? DefaultEditFormUrl { get; set; }

    [JsonProperty()]
    public virtual bool DefaultItemOpenUseListSetting { get; set; }

    [JsonProperty()]
    public virtual string? DefaultNewFormUrl { get; set; }

    [JsonProperty()]
    public virtual string? DefaultViewUrl { get; set; }

    [JsonProperty()]
    public virtual string? Description { get; set; }

    [JsonProperty()]
    public virtual string? Direction { get; set; }

    [JsonProperty()]
    public virtual bool DisableCommenting { get; set; }

    [JsonProperty()]
    public virtual bool DisableGridEditing { get; set; }

    [JsonProperty()]
    public virtual string? DocumentTemplateUrl { get; set; }

    [JsonProperty()]
    public virtual DraftVisibilityType? DraftVersionVisibility { get; set; }

    [JsonProperty()]
    public virtual bool EnableAttachments { get; set; }

    [JsonProperty()]
    public virtual bool EnableFolderCreation { get; set; }

    [JsonProperty()]
    public virtual bool EnableMinorVersions { get; set; }

    [JsonProperty()]
    public virtual bool EnableModeration { get; set; }

    [JsonProperty()]
    public virtual bool EnableRequestSignOff { get; set; }

    [JsonProperty()]
    public virtual bool EnableVersioning { get; set; }

    [JsonProperty()]
    public virtual string? EntityTypeName { get; set; }

    [JsonProperty()]
    public virtual bool ExemptFromBlockDownloadOfNonViewableFiles { get; set; }

    [JsonProperty()]
    public virtual bool FileSavePostProcessingEnabled { get; set; }

    [JsonProperty("ForceCheckout")]
    public virtual bool ForceCheckOut { get; set; }

    [JsonProperty()]
    public virtual bool HasExternalDataSource { get; set; }

    [JsonProperty()]
    public override bool HasUniqueRoleAssignments { get; set; }

    [JsonProperty()]
    public virtual bool Hidden { get; set; }

    [JsonProperty()]
    public virtual Guid Id { get; set; }

    [JsonProperty()]
    public virtual ResourcePath? ImagePath { get; set; }

    [JsonProperty()]
    public virtual string? ImageUrl { get; set; }

    [JsonProperty()]
    public virtual bool IrmEnabled { get; set; }

    [JsonProperty()]
    public virtual bool IrmExpire { get; set; }

    [JsonProperty()]
    public virtual bool IrmReject { get; set; }

    [JsonProperty()]
    public virtual bool IsApplicationList { get; set; }

    [JsonProperty()]
    public virtual bool IsCatalog { get; set; }

    [JsonProperty()]
    public virtual bool IsPrivate { get; set; }

    [JsonProperty()]
    public virtual bool IsSiteAssetsLibrary { get; set; }

    [JsonProperty()]
    public virtual int ItemCount { get; set; }

    [JsonProperty()]
    public virtual DateTime LastItemDeletedDate { get; set; }

    [JsonProperty()]
    public virtual DateTime LastItemModifiedDate { get; set; }

    [JsonProperty()]
    public virtual DateTime LastItemUserModifiedDate { get; set; }

    [JsonProperty()]
    public virtual ListExperience? ListExperienceOptions { get; set; }

    [JsonProperty()]
    public virtual string? ListItemEntityTypeFullName { get; set; }

    [JsonProperty()]
    public virtual int MajorVersionLimit { get; set; }

    [JsonProperty()]
    public virtual int MajorWithMinorVersionsLimit { get; set; }

    [JsonProperty()]
    public virtual bool MultipleDataList { get; set; }

    [JsonProperty()]
    public virtual bool NoCrawl { get; set; }

    [JsonProperty("ParentWebPath")]
    public virtual ResourcePath? ParentSitePath { get; set; }

    [JsonProperty("ParentWebUrl")]
    public virtual string? ParentSiteUrl { get; set; }

    [JsonProperty()]
    public virtual bool ParserDisabled { get; set; }

    [JsonProperty()]
    public virtual string? SchemaXml { get; set; }

    [JsonProperty()]
    public virtual bool ServerTemplateCanCreateFolders { get; set; }

    [JsonProperty()]
    public virtual Guid TemplateFeatureId { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual string? ValidationFormula { get; set; }

    [JsonProperty()]
    public virtual string? ValidationMessage { get; set; }

}
