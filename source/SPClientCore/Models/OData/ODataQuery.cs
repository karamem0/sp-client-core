//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.OData
{

    public static class ODataQuery
    {

        public static string Create<T>(IDictionary<string, object> parameters) where T : ClientObject
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            var select = Enumerable.Repeat("*", 1).Union(typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(property => Attribute.IsDefined(property, typeof(JsonPropertyAttribute)))
                .Where(property =>
                {
                    if (property.PropertyType.IsSubclassOf(typeof(ODataObject)))
                    {
                        return false;
                    }
                    if (property.PropertyType.IsSubclassOf(typeof(ClientObject)))
                    {
                        return false;
                    }
                    return true;
                })
                .Select(property => property.Name));
            var queries = new Dictionary<string, object>();
            var value = default(object);
            if (parameters.TryGetValue("Includes", out value))
            {
                if (value is IEnumerable<string> typed)
                {
                    queries.Add("$select", string.Join(",", select.Union(typed)));
                    queries.Add("$expand", string.Join(",", typed));
                }
            }
            if (parameters.TryGetValue("OrderBy", out value))
            {
                if (value is IEnumerable<string> typed)
                {
                    queries.Add("$orderby", string.Join(",", typed));
                }
            }
            if (parameters.TryGetValue("Top", out value))
            {
                if (value is int typed)
                {
                    queries.Add("$top", typed);
                }
            }
            if (parameters.TryGetValue("Skip", out value))
            {
                if (value is int typed)
                {
                    queries.Add("$skip", typed);
                }
            }
            if (parameters.TryGetValue("SkipToken", out value))
            {
                if (value is int typed)
                {
                    queries.Add("$skiptoken", $"Paged=TRUE&p_ID={typed}");
                }
            }
            if (parameters.TryGetValue("Filter", out value))
            {
                if (value is string typed)
                {
                    queries.Add("$filter", typed);
                }
            }
            if (!queries.ContainsKey("$select"))
            {
                queries.Add("$select", string.Join(",", select));
            }
            return UriQuery.Create(queries);
        }

    }

}
