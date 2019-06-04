//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models
{

    public static class FlagsParser
    {

        public static T Parse<T>(IReadOnlyDictionary<string, object> parameters) where T : Enum
        {
            var type = typeof(T);
            if (type.IsDefined(typeof(FlagsAttribute), false))
            {
                var values = parameters
                    .Where(parameter => parameter.Value is SwitchParameter)
                    .Where(parameter => (SwitchParameter)parameter.Value)
                    .Select(parameter =>
                    {
                        if (Enum.TryParse(type, parameter.Key, true, out var value))
                        {
                            return Enum.GetName(type, value);
                        }
                        else
                        {
                            return null;
                        }
                    })
                    .Where(value => value != null)
                    .ToList();
                if (values.Any())
                {
                    return (T)Enum.Parse(type, string.Join(",", values));
                }
                else
                {
                    return default(T);
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

    }

}
