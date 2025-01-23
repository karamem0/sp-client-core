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

    public ListItem()
    {
    }

    [JsonIgnore()]
    public PSObject FieldValues => new(
        this.ExtensionProperties
            .Select(ClientResultValue.Create)
            .ToDictionary(item => item.Key, item => item.Value)
    );

    [JsonProperty()]
    public virtual string AccessPolicy { get; protected set; }

    [JsonProperty()]
    public virtual ColumnLookupValue AppAuthor { get; protected set; }

    [JsonProperty()]
    public virtual ColumnLookupValue AppEditor { get; protected set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual bool Attachments { get; protected set; }

    [JsonProperty()]
    public virtual ColumnUserValue Author { get; protected set; }

    [ClientQueryIgnore()]
    [JsonProperty("CheckedOutTitle")]
    public virtual ColumnLookupValue CheckOutTitle { get; protected set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual ColumnUserValue CheckOutUser { get; protected set; }

    [ClientQueryIgnore()]
    [JsonProperty("CheckedOutUserId")]
    public virtual ColumnLookupValue CheckOutUserId { get; protected set; }

    [JsonProperty()]
    public virtual DateTime Created { get; protected set; }

    [JsonProperty()]
    public virtual bool CommentsDisabled { get; protected set; }

    [JsonProperty()]
    public virtual CommentsDisabledScope CommentsDisabledScope { get; protected set; }

    [JsonProperty()]
    public virtual ContentTypeId ContentTypeId { get; protected set; }

    [JsonProperty()]
    public virtual string ContentVersion { get; protected set; }

    [JsonProperty()]
    public virtual string DisplayName { get; protected set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual string DocConcurrencyNumber { get; protected set; }

    [JsonProperty()]
    public virtual string FileDirRef { get; protected set; }

    [JsonProperty()]
    public virtual string FileLeafRef { get; protected set; }

    [JsonProperty()]
    public virtual string FileRef { get; protected set; }

    [JsonProperty()]
    public virtual ColumnUserValue Editor { get; protected set; }

    [JsonProperty()]
    public virtual FileSystemObjectType FileSystemObjectType { get; protected set; }

    [JsonProperty()]
    public virtual int FolderChildCount { get; protected set; }

    [JsonProperty()]
    public override bool HasUniqueRoleAssignments { get; protected set; }

    [JsonProperty()]
    public virtual int Id { get; protected set; }

    [JsonProperty("InstanceID")]
    public virtual string InstanceId { get; protected set; }

    [JsonProperty()]
    public virtual int ItemChildCount { get; protected set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual string IsCheckedoutToLocal { get; protected set; }

    [JsonProperty()]
    public virtual string MetaInfo { get; protected set; }

    [JsonProperty()]
    public virtual DateTime Modified { get; protected set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual ColumnLookupValue ParentLeafName { get; protected set; }

    [JsonProperty()]
    public virtual string ParentUniqueId { get; protected set; }

    [JsonProperty()]
    public virtual string ProgId { get; protected set; }

    [JsonProperty()]
    public virtual string Restricted { get; protected set; }

    [JsonProperty()]
    public virtual string OriginatorId { get; protected set; }

    [JsonProperty()]
    public virtual string ScopeId { get; protected set; }

    [JsonProperty()]
    public virtual string ServerRedirectedEmbedUrl { get; protected set; }

    [JsonProperty()]
    public virtual ColumnLookupValue SortBehavior { get; protected set; }

    [JsonProperty()]
    public virtual ColumnLookupValue SyncClientId { get; protected set; }

    [JsonProperty()]
    public virtual string Title { get; protected set; }

    [JsonProperty()]
    public virtual Guid UniqueId { get; protected set; }

    [ClientQueryIgnore()]
    [JsonProperty()]
    public virtual ColumnLookupValue VirusStatus { get; protected set; }

    [JsonProperty("WorkflowInstanceID")]
    public virtual string WorkflowInstanceId { get; protected set; }

}
