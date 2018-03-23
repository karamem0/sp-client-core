//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.OData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.Core
{

    [JsonObject(Id = "SP.BasePermissions")]
    public class BasePermissions : ClientObject
    {

        public BasePermissions()
        {
        }

        public BasePermissions(PermissionKind permissionKind)
        {
            this.Set(permissionKind);
        }

        public BasePermissions(string permissionKind)
        {
            this.Set(Enum.Parse<PermissionKind>(permissionKind));
        }

        public BasePermissions(params PermissionKind[] permissionKinds)
        {
            foreach (var permissionKind in permissionKinds)
            {
                this.Set(permissionKind);
            }
        }

        public BasePermissions(params string[] permissionKinds)
        {
            foreach (var permissionKind in permissionKinds)
            {
                this.Set(Enum.Parse<PermissionKind>(permissionKind));
            }
        }

        [JsonProperty()]
        [JsonConverter(typeof(EdmInt64Converter))]
        public uint? High { get; private set; }

        [JsonProperty()]
        [JsonConverter(typeof(EdmInt64Converter))]
        public uint? Low { get; private set; }

        public void Clear(PermissionKind permissionKind)
        {
            var num1 = (int)(permissionKind - 1);
            var num2 = 1u;
            if (num1 >= 0 && num1 < 32)
            {
                num2 <<= num1;
                num2 = ~num2;
                this.Low &= this.Low.GetValueOrDefault() & num2;
            }
            else if (num1 >= 32 && num1 < 64)
            {
                num2 <<= num1 - 32;
                num2 = ~num2;
                this.High = this.High.GetValueOrDefault() & num2;
            }
        }

        public void ClearAll()
        {
            this.Low = null;
            this.High = null;
        }

        public void Set(PermissionKind permissionKind)
        {
            switch (permissionKind)
            {
                case PermissionKind.FullMask:
                    this.Low = 65535u;
                    this.High = 32767u;
                    break;
                case PermissionKind.EmptyMask:
                    this.Low = 0u;
                    this.High = 0u;
                    break;
                default:
                    var num1 = (int)(permissionKind - 1);
                    var num2 = 1u;
                    if (num1 >= 0 && num1 < 32)
                    {
                        num2 <<= num1;
                        this.Low = this.Low.GetValueOrDefault() | num2;
                    }
                    else if (num1 >= 32 && num1 < 64)
                    {
                        num2 <<= num1 - 32;
                        this.High = this.High.GetValueOrDefault() | num2;
                    }
                    break;
            }
        }

    }

}
