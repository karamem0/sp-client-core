//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject(Id = "SP.List")]
    public class List : SecurableObject
    {

        public List()
        {
        }

        [JsonProperty()]
        public bool? AllowContentTypes { get; private set; }

        [JsonProperty()]
        public int? BaseTemplate { get; private set; }

        [JsonProperty()]
        public int? BaseType { get; private set; }

        [JsonProperty()]
        public int? BrowserFileHandling { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<ContentType> ContentTypes { get; private set; }

        [JsonProperty()]
        public bool? ContentTypesEnabled { get; private set; }

        [JsonProperty()]
        public DateTime? Created { get; private set; }

        [JsonProperty()]
        public ListDataSource DataSource { get; private set; }

        [JsonProperty()]
        public Guid? DefaultContentApprovalWorkflowId { get; private set; }

        [JsonProperty()]
        public string DefaultDisplayFormUrl { get; private set; }

        [JsonProperty()]
        public string DefaultEditFormUrl { get; private set; }

        [JsonProperty()]
        public string DefaultNewFormUrl { get; private set; }

        [JsonProperty()]
        public View DefaultView { get; private set; }

        [JsonProperty()]
        public string DefaultViewUrl { get; private set; }

        [JsonProperty()]
        public string Description { get; private set; }

        [JsonProperty()]
        public string Direction { get; private set; }

        [JsonProperty()]
        public string DocumentTemplateUrl { get; private set; }

        [JsonProperty()]
        public DraftVisibilityType? DraftVersionVisibility { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<BasePermissions> EffectiveBasePermissions { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<BasePermissions> EffectiveBasePermissionsForUI { get; private set; }

        [JsonProperty()]
        public bool? EnableAttachments { get; private set; }

        [JsonProperty()]
        public bool? EnableFolderCreation { get; private set; }

        [JsonProperty()]
        public bool? EnableMinorVersions { get; private set; }

        [JsonProperty()]
        public bool? EnableModeration { get; private set; }

        [JsonProperty()]
        public bool? EnableVersioning { get; private set; }

        [JsonProperty()]
        public string EntityTypeName { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<EventReceiverDefinition> EventReceivers { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Field> Fields { get; private set; }

        [JsonProperty()]
        public SecurableObject FirstUniqueAncestorSecurableObject { get; private set; }

        [JsonProperty()]
        public bool? ForceCheckout { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<Form> Forms { get; private set; }

        [JsonProperty()]
        public bool? HasExternalDataSource { get; private set; }

        [JsonProperty()]
        public bool? Hidden { get; private set; }

        [JsonProperty()]
        public Guid? Id { get; private set; }

        [JsonProperty()]
        public string ImageUrl { get; private set; }

        [JsonProperty()]
        public InformationRightsManagementSettings InformationRightsManagementSettings { get; private set; }

        [JsonProperty()]
        public bool? IrmEnabled { get; private set; }

        [JsonProperty()]
        public bool? IrmExpire { get; private set; }

        [JsonProperty()]
        public bool? IrmReject { get; private set; }

        [JsonProperty()]
        public bool? IsApplicationList { get; private set; }

        [JsonProperty()]
        public bool? IsCatalog { get; private set; }

        [JsonProperty()]
        public bool? IsPrivate { get; private set; }

        [JsonProperty()]
        public bool? IsSiteAssetsLibrary { get; private set; }

        [JsonProperty()]
        public int? ItemCount { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<ListItem> Items { get; private set; }

        [JsonProperty()]
        public DateTime? LastItemDeletedDate { get; private set; }

        [JsonProperty()]
        public DateTime? LastItemModifiedDate { get; private set; }

        [JsonProperty()]
        public string ListItemEntityTypeFullName { get; private set; }

        [JsonProperty()]
        public bool? MultipleDataList { get; private set; }

        [JsonProperty()]
        public bool? NoCrawl { get; private set; }

        [JsonProperty()]
        public bool? OnQuickLaunch { get; private set; }

        [JsonProperty()]
        public Web ParentWeb { get; private set; }

        [JsonProperty()]
        public string ParentWebUrl { get; private set; }

        [JsonProperty()]
        public Folder RootFolder { get; private set; }

        [JsonProperty()]
        public string SchemaXml { get; private set; }

        [JsonProperty()]
        public bool? ServerTemplateCanCreateFolders { get; private set; }

        [JsonProperty()]
        public Guid? TemplateFeatureId { get; private set; }

        [JsonProperty()]
        public string Title { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<UserCustomAction> UserCustomActions { get; private set; }

        [JsonProperty()]
        public string ValidationFormula { get; private set; }

        [JsonProperty()]
        public string ValidationMessage { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<View> Views { get; private set; }

        [JsonProperty()]
        public ClientObjectCollection<WorkflowAssociation> WorkflowAssociations { get; private set; }

    }

}
