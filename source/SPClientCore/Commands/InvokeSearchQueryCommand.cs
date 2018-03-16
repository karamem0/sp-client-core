//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Search;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Commands
{

    [Cmdlet("Invoke", "SPSearchQuery")]
    public class InvokeSearchQueryCommand : PSCmdlet
    {

        public InvokeSearchQueryCommand()
        {
        }

        [Parameter(Mandatory = false)]
        public int? BlockDedupeMode { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? BypassResultTypes { get; private set; }

        [Parameter(Mandatory = false)]
        public string ClientType { get; private set; }

        [Parameter(Mandatory = false)]
        public string CollapseSpecification { get; private set; }

        [Parameter(Mandatory = false)]
        public uint? Culture { get; private set; }

        [Parameter(Mandatory = false)]
        public int? DesiredSnippetLength { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableFQL { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableInterleaving { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableNicknames { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableOrderingHitHighlightedProperty { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnablePhonetic { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableQueryRules { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableSorting { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? EnableStemming { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? GenerateBlockRankLog { get; private set; }

        [Parameter(Mandatory = false)]
        public string HiddenConstraints { get; private set; }

        [Parameter(Mandatory = false)]
        public int? HitHighlightedMultivaluePropertyLimit { get; private set; }

        [Parameter(Mandatory = false)]
        public string HitHighlightedProperties { get; private set; }

        [Parameter(Mandatory = false)]
        public int? MaxSnippetLength { get; private set; }

        [Parameter(Mandatory = false)]
        public Guid? PersonalizationData { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? ProcessBestBets { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? ProcessPersonalFavorites { get; private set; }

        [Parameter(Mandatory = false)]
        public string QueryTag { get; private set; }

        [Parameter(Mandatory = false)]
        public string QueryTemplate { get; private set; }

        [Parameter(Mandatory = false)]
        public string QueryTemplatePropertiesUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public string QueryText { get; private set; }

        [Parameter(Mandatory = false)]
        public string RankingModelId { get; private set; }

        [Parameter(Mandatory = false)]
        public string RefinementFilters { get; private set; }

        [Parameter(Mandatory = false)]
        public string Refiners { get; private set; }

        [Parameter(Mandatory = false)]
        public string ResultsUrl { get; private set; }

        [Parameter(Mandatory = false)]
        public int? RowLimit { get; private set; }

        [Parameter(Mandatory = false)]
        public int? RowsPerPage { get; private set; }

        [Parameter(Mandatory = false)]
        public string SelectProperties { get; private set; }

        [Parameter(Mandatory = false)]
        public string SortList { get; private set; }

        [Parameter(Mandatory = false)]
        public Guid? SourceId { get; private set; }

        [Parameter(Mandatory = false)]
        public int? StartRow { get; private set; }

        [Parameter(Mandatory = false)]
        public int? SummaryLength { get; private set; }

        [Parameter(Mandatory = false)]
        public int? Timeout { get; private set; }

        [Parameter(Mandatory = false)]
        public bool? TrimDuplicates { get; private set; }

        [Parameter(Mandatory = false)]
        public uint? UILanguage { get; private set; }

        protected override void ProcessRecord()
        {
            if (ClientObjectService.ServiceProvider == null)
            {
                throw new InvalidOperationException(StringResources.ErrorNotConnected);
            }
            var searchService = ClientObjectService.ServiceProvider.GetService<ISearchService>();
            this.WriteObject(searchService.ExecuteQuery(this.MyInvocation.BoundParameters));
        }

    }

}
