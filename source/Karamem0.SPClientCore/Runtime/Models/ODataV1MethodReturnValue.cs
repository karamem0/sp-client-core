//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[JsonObject()]
public class ODataV1MethodReturnValue : ODataV1Object<ODataV1MethodReturnValue>
{

    public virtual T? GetValue<T>(string methodName) where T : ODataV1Object
    {
        return this
            .ExtensionProperties[methodName]
            .ToObject<T>(JsonSerializerManager.Instance);
    }

}
