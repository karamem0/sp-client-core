//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.Search;
using Karamem0.SharePoint.PowerShell.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Search.Tests
{

    [TestClass()]
    [TestCategory("Search")]
    public class InvokeSearchQueryCommandTests
    {

        [TestMethod()]
        public void ExecuteSearchQuery()
        {
            using (var context = new PSCmdletContext())
            {
                var result1 = context.Runspace.InvokeCommand<SearchResult>(
                    "Invoke-SPSearchQuery",
                    new Dictionary<string, object>()
                    {
                        { "BlockDedupeMode", true },
                        { "BypassResultTypes", true },
                        { "ClientType", "Test Client 1" },
                        { "CollapseSpecification", "Author:1 ContentType:2" },
                        { "Culture", 1033 },
                        { "DesiredSnippetLength", 80 },
                        { "EnableFQL", true },
                        { "EnableInterleaving", true },
                        { "EnableNicknames", true },
                        { "EnableOrderingHitHighlightedProperty", true },
                        { "EnablePhonetic", true },
                        { "EnableQueryRules", true },
                        { "EnableSorting", true },
                        { "EnableStemming", true },
                        { "GenerateBlockRankLog", true },
                        { "HiddenConstraints", "Test" },
                        { "HitHighlightedMultivaluePropertyLimit", 2 },
                        { "HitHighlightedProperties", "Title" },
                        { "MaxSnippetLength", 100 },
                        { "PersonalizationData", null },
                        { "ProcessBestBets", true },
                        { "ProcessPersonalFavorites", true },
                        { "QueryTag", "Test" },
                        { "QueryTemplate", "{searchterms}" },
                        { "QueryTemplatePropertiesUrl", null },
                        { "QueryText", "Test" },
                        { "RankingModelId", null },
                        { "RefinementFilters", null },
                        { "Refiners", "Author,Size" },
                        { "ResultsUrl", null },
                        { "RowLimit", 30 },
                        { "RowsPerPage", 10 },
                        { "SelectProperties", "Title,Author" },
                        { "SortList", "Rank:descending,ModifiedBy:ascending" },
                        { "SourceId", null },
                        { "StartRow", 0 },
                        { "SummaryLength", 150 },
                        { "Timeout", 60000 },
                        { "TrimDuplicates", true },
                        { "UILanguage", 1033 }
                    }
                );
                var actual = result1.ElementAt(0);
            }
        }

    }

}
