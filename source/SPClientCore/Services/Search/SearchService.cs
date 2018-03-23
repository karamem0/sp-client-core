//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Search
{

    public interface ISearchService
    {

        SearchResult ExecuteQuery(IDictionary<string, object> searchQueryParameters);

    }

    public class SearchService : ClientObjectService, ISearchService
    {

        public SearchService(ClientContext clientContext) : base(clientContext)
        {
        }

        public SearchResult ExecuteQuery(IDictionary<string, object> searchQueryParameters)
        {
            if (searchQueryParameters == null)
            {
                throw new ArgumentNullException(nameof(searchQueryParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/search/query")
                .ConcatQuery(UriQuery.Create(searchQueryParameters, true));
            return this.ClientContext.GetObject<SearchResultPayload>(requestUrl).SearchResult;
        }

    }

}
