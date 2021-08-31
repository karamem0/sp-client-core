//
// Copyright (c) 2021 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/spclientcore/blob/master/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Common
{

    public static class UriExtensions
    {

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
            var str1 = uri.ToString().TrimEnd('/');
            var str2 = path.Trim('/');
            var slash = uri.OriginalString.EndsWith("/") ? "/" : "";
            return new Uri(str1 + "/" + str2 + slash, UriKind.RelativeOrAbsolute);
        }

        public static Uri ConcatPath(this Uri uri, string path, params object[] args)
        {
            return uri.ConcatPath(string.Format(path, args
                .Select(obj => obj == null ? string.Empty : obj)
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
            var str1 = uri.ToString();
            var str2 = query.TrimStart('?');
            if (str1.Contains('?'))
            {
                return new Uri($"{str1}&{str2}", UriKind.RelativeOrAbsolute);
            }
            else
            {
                return new Uri($"{str1}?{str2}", UriKind.RelativeOrAbsolute);
            }
        }

        public static string GetAuthority(this Uri uri)
        {
            return uri.GetLeftPart(UriPartial.Authority);
        }

    }

}
