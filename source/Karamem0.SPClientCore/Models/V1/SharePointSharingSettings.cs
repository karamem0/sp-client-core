//
// Copyright (c) 2018-2024 karamem0
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

[ClientObject(Name = "SP.SharePointSharingSettings", Id = "{07dbebdf-94bc-4a22-843a-323551f64fab}")]
[JsonObject()]
public class SharePointSharingSettings : ClientObject
{

    public SharePointSharingSettings()
    {
    }

    [JsonProperty()]
    public virtual string AddToGroupModeName { get; protected set; }

    [JsonProperty("txtEmailSubjectText")]
    public virtual string EmailSubjectText { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string> GroupNameLines { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string> GroupRoleDefinitionNamesLines { get; protected set; }

    [JsonProperty()]
    public virtual bool IsMobileView { get; protected set; }

    [JsonProperty()]
    public virtual bool PanelGivePermissionsVisible { get; protected set; }

    [JsonProperty()]
    public virtual bool PanelShowHideMoreOptionsVisible { get; protected set; }

    [JsonProperty()]
    public virtual bool PanelSimplifiedRoleSelectorVisible { get; protected set; }

    [JsonProperty()]
    public virtual PickerSettings PickerProperties { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string> RequiredScriptFileLinks { get; protected set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string> RoleDefinitionNameLines { get; protected set; }

    [JsonProperty()]
    public virtual string SelectedGroup { get; protected set; }

    [JsonProperty()]
    public virtual bool SharedWithEnabled { get; protected set; }

    [JsonProperty()]
    public virtual string SharingCssLink { get; protected set; }

    [JsonProperty()]
    public virtual bool TabbedDialogEnabled { get; protected set; }

    [JsonProperty()]
    public virtual int TabToShow { get; protected set; }

    [JsonProperty()]
    public virtual string UserDisplayUrl { get; protected set; }

}
