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
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.ListItem", Id = "{53cc48c0-1777-47b7-99ca-729390f06602}")]
[JsonObject()]
public class ListItem : SecurableObject
{

    [JsonIgnore()]
    public PSObject FieldValues => new(
        this
            .ExtensionProperties.Select(ClientResultValue.Create)
            .ToDictionary(item => item.Key, item => item.Value)
    );

    [JsonProperty()]
    public virtual string? AccessPolicy { get; set; }

    [JsonProperty()]
    public virtual ColumnLookupValue? AppAuthor { get; set; }

    [JsonProperty()]
    public virtual ColumnLookupValue? AppEditor { get; set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual bool Attachments { get; set; }

    [JsonProperty()]
    public virtual ColumnUserValue? Author { get; set; }

    [ClientQueryIgnore()]
    [JsonProperty("CheckedOutTitle")]
    public virtual ColumnLookupValue? CheckOutTitle { get; set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual ColumnUserValue? CheckOutUser { get; set; }

    [ClientQueryIgnore()]
    [JsonProperty("CheckedOutUserId")]
    public virtual ColumnLookupValue? CheckOutUserId { get; set; }

    [JsonProperty()]
    public virtual DateTime Created { get; set; }

    [JsonProperty()]
    public virtual bool CommentsDisabled { get; set; }

    [JsonProperty()]
    public virtual CommentsDisabledScope? CommentsDisabledScope { get; set; }

    [JsonProperty()]
    public virtual ContentTypeId? ContentTypeId { get; set; }

    [JsonProperty()]
    public virtual string? ContentVersion { get; set; }

    [JsonProperty()]
    public virtual string? DisplayName { get; set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual string? DocConcurrencyNumber { get; set; }

    [JsonProperty()]
    public virtual string? FileDirRef { get; set; }

    [JsonProperty()]
    public virtual string? FileLeafRef { get; set; }

    [JsonProperty()]
    public virtual string? FileRef { get; set; }

    [JsonProperty()]
    public virtual ColumnUserValue? Editor { get; set; }

    [JsonProperty()]
    public virtual FileSystemObjectType? FileSystemObjectType { get; set; }

    [JsonProperty()]
    public virtual int FolderChildCount { get; set; }

    [JsonProperty()]
    public override bool HasUniqueRoleAssignments { get; set; }

    [JsonProperty()]
    public virtual int Id { get; set; }

    [JsonProperty("InstanceID")]
    public virtual string? InstanceId { get; set; }

    [JsonProperty()]
    public virtual int ItemChildCount { get; set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual string? IsCheckedoutToLocal { get; set; }

    [JsonProperty()]
    public virtual string? MetaInfo { get; set; }

    [JsonProperty()]
    public virtual DateTime Modified { get; set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual ColumnLookupValue? ParentLeafName { get; set; }

    [JsonProperty()]
    public virtual string? ParentUniqueId { get; set; }

    [JsonProperty()]
    public virtual string? ProgId { get; set; }

    [JsonProperty()]
    public virtual string? Restricted { get; set; }

    [JsonProperty()]
    public virtual string? OriginatorId { get; set; }

    [JsonProperty()]
    public virtual string? ScopeId { get; set; }

    [JsonProperty()]
    public virtual string? ServerRedirectedEmbedUrl { get; set; }

    [JsonProperty()]
    public virtual ColumnLookupValue? SortBehavior { get; set; }

    [JsonProperty()]
    public virtual ColumnLookupValue? SyncClientId { get; set; }

    [JsonProperty()]
    public virtual string? Title { get; set; }

    [JsonProperty()]
    public virtual Guid UniqueId { get; set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual ColumnLookupValue? VirusStatus { get; set; }

    [JsonProperty("WorkflowInstanceID")]
    public virtual string? WorkflowInstanceId { get; set; }

}
