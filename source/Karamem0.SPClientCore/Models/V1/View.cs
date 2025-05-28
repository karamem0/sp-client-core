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

[ClientObject(Name = "SP.View", Id = "{2399f45d-1784-4965-9a5f-a3415790a0d0}")]
[JsonObject()]
public class View : ClientObject
{

    [JsonProperty()]
    public virtual string? Aggregations { get; private set; }

    [JsonProperty()]
    public virtual string? AggregationsStatus { get; private set; }

    [JsonProperty()]
    public virtual string? AssociatedContentTypeId { get; private set; }

    [JsonProperty()]
    public virtual string? BaseViewId { get; private set; }

    [JsonProperty()]
    public string? CalendarViewStyles { get; private set; }

    [JsonProperty()]
    public virtual string? ColumnWidth { get; private set; }

    [JsonProperty()]
    public virtual ContentTypeId? ContentTypeId { get; private set; }

    [JsonProperty()]
    public virtual string? CustomFormatter { get; private set; }

    [JsonProperty()]
    public virtual bool DefaultView { get; private set; }

    [JsonProperty()]
    public virtual bool DefaultViewForContentType { get; private set; }

    [JsonProperty()]
    public virtual bool EditorModified { get; private set; }

    [JsonProperty()]
    public virtual string? Formats { get; private set; }

    [JsonProperty()]
    public virtual string? GridLayout { get; private set; }

    [JsonProperty()]
    public virtual bool Hidden { get; private set; }

    [JsonProperty()]
    public virtual string? HtmlSchemaXml { get; private set; }

    [JsonProperty()]
    public virtual Guid Id { get; private set; }

    [JsonProperty()]
    public virtual Uri? ImageUrl { get; private set; }

    [JsonProperty()]
    public virtual bool IncludeRootFolder { get; private set; }

    [JsonProperty()]
    public virtual string? JSLink { get; private set; }

    [JsonProperty()]
    public virtual string? ListViewXml { get; private set; }

    [JsonProperty()]
    public virtual string? Method { get; private set; }

    [JsonProperty()]
    public virtual bool MobileDefaultView { get; private set; }

    [JsonProperty()]
    public virtual bool MobileView { get; private set; }

    [JsonProperty()]
    public virtual string? ModerationType { get; private set; }

    [JsonProperty()]
    public virtual string? NewDocumentTemplates { get; private set; }

    [JsonProperty()]
    public virtual bool OrderedView { get; private set; }

    [JsonProperty()]
    public virtual bool Paged { get; private set; }

    [JsonProperty()]
    public virtual ListPageRenderType? PageRenderType { get; private set; }

    [JsonProperty()]
    public virtual bool PersonalView { get; private set; }

    [JsonProperty()]
    public virtual bool ReadOnlyView { get; private set; }

    [JsonProperty()]
    public virtual bool RequiresClientIntegration { get; private set; }

    [JsonProperty()]
    public virtual int RowLimit { get; private set; }

    [JsonProperty()]
    public virtual ViewScope? Scope { get; private set; }

    [JsonProperty()]
    public virtual ResourcePath? ServerRelativePath { get; private set; }

    [JsonProperty()]
    public virtual Uri? ServerRelativeUrl { get; private set; }

    [JsonProperty()]
    public virtual string? StyleId { get; private set; }

    [JsonProperty()]
    public virtual bool TabularView { get; private set; }

    [JsonProperty()]
    public virtual bool Threaded { get; private set; }

    [JsonProperty()]
    public virtual string? Title { get; private set; }

    [JsonProperty()]
    public virtual string? Toolbar { get; private set; }

    [JsonProperty()]
    public virtual string? ToolbarTemplateName { get; private set; }

    [JsonProperty()]
    public virtual string? ViewData { get; private set; }

    [JsonProperty()]
    public virtual string? ViewJoins { get; private set; }

    [JsonProperty("ViewProjectedFields")]
    public virtual string? ViewProjectedColumns { get; private set; }

    [JsonProperty()]
    public virtual string? ViewQuery { get; private set; }

    [JsonProperty()]
    public virtual string? ViewType { get; private set; }

    [JsonProperty()]
    public virtual string? ViewType2 { get; private set; }

    [JsonProperty()]
    public virtual string? VisualizationInfo { get; private set; }

}
