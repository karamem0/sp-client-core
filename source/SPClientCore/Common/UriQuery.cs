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

    public static class UriQuery
    {

        public static string Create(IDictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
            }
            return string.Join("&", parameters.Select(pair =>
                Uri.EscapeDataString(pair.Key) + "=" +
                Uri.EscapeDataString(pair.Value.ToString())));
        }

    }

}
