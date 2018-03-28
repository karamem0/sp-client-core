//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Common
{

    public static class UriExtensions
    {

        public static Uri MakeParentUri(this Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            var str = string.Join("/", uri.ToString().TrimEnd('/').Split('/').SkipLast(1));
            var slash = uri.ToString().EndsWith("/") ? "/" : "";
            return new Uri(str + slash, UriKind.RelativeOrAbsolute);
        }

        public static Uri ConcatPath(this Uri uri, string path)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            if (path == null)
            {
                return uri;
            }
            else
            {
                var str1 = uri.ToString().TrimEnd('/');
                var str2 = path.Trim('/');
                var slash = uri.ToString().EndsWith("/") ? "/" : "";
                return new Uri(str1 + "/" + str2 + slash, UriKind.RelativeOrAbsolute);
            }
        }

        public static Uri ConcatPath(this Uri uri, Uri path)
        {
            return uri.ConcatPath(path.ToString());
        }

        public static Uri ConcatPath(this Uri uri, string path, params object[] args)
        {
            return uri.ConcatPath(string.Format(path, args
                .Select(obj => obj is null ? string.Empty : obj)
                .Select(obj => obj is bool ? obj.ToString().ToLower() : obj.ToString())
                .Select(str => Uri.EscapeDataString(str)).ToArray()));
        }

        public static Uri ConcatQuery(this Uri uri, string query)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            if (query == null)
            {
                return uri;
            }
            else
            {
                var str1 = uri.ToString();
                var str2 = query.TrimStart('?');
                if (str1.Contains('?'))
                {
                    return new Uri(str1 + "&" + str2, UriKind.RelativeOrAbsolute);
                }
                else
                {
                    return new Uri(str1 + "?" + str2, UriKind.RelativeOrAbsolute);
                }
            }
        }

    }

}
