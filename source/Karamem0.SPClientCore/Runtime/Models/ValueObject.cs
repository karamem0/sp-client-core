//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public abstract class ValueObject
{

    protected virtual Lazy<IReadOnlyCollection<PropertyInfo>> EqualityProperties => new(
        () => this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
    );

    public override bool Equals(object value)
    {
        if (value is null)
        {
            return false;
        }
        if (this.GetType() != value.GetType())
        {
            return false;
        }
        return this.GetHashCode() == value.GetHashCode();
    }

    public override int GetHashCode()
    {
        var hashCode = 0;
        foreach (var property in this.EqualityProperties.Value)
        {
            var value = property.GetValue(this);
            if (value is not null)
            {
                hashCode ^= value.GetHashCode();
            }
        }
        return hashCode;
    }

}
