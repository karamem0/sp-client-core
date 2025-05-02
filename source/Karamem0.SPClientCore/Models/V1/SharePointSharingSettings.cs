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

[ClientObject(Name = "SP.SharePointSharingSettings", Id = "{07dbebdf-94bc-4a22-843a-323551f64fab}")]
[JsonObject()]
public class SharePointSharingSettings : ClientObject
{

    [JsonProperty()]
    public virtual string? AddToGroupModeName { get; set; }

    [JsonProperty("txtEmailSubjectText")]
    public virtual string? EmailSubjectText { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? GroupNameLines { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? GroupRoleDefinitionNamesLines { get; set; }

    [JsonProperty()]
    public virtual bool IsMobileView { get; set; }

    [JsonProperty()]
    public virtual bool PanelGivePermissionsVisible { get; set; }

    [JsonProperty()]
    public virtual bool PanelShowHideMoreOptionsVisible { get; set; }

    [JsonProperty()]
    public virtual bool PanelSimplifiedRoleSelectorVisible { get; set; }

    [JsonProperty()]
    public virtual PickerSettings? PickerProperties { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? RequiredScriptFileLinks { get; set; }

    [JsonProperty()]
    public virtual IReadOnlyCollection<string>? RoleDefinitionNameLines { get; set; }

    [JsonProperty()]
    public virtual string? SelectedGroup { get; set; }

    [JsonProperty()]
    public virtual bool SharedWithEnabled { get; set; }

    [JsonProperty()]
    public virtual string? SharingCssLink { get; set; }

    [JsonProperty()]
    public virtual bool TabbedDialogEnabled { get; set; }

    [JsonProperty()]
    public virtual int TabToShow { get; set; }

    [JsonProperty()]
    public virtual string? UserDisplayUrl { get; set; }

}
