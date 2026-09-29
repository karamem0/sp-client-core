//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISiteChromeOptionsService
{

    Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo);

}

public class SiteChromeOptionsService(ClientContext clientContext) : ClientService(clientContext), ISiteChromeOptionsService
{

    public async Task SetObjectAsync(IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath("_api/web/setchromeoptions");
        var requestPayload = ClientValueObject.Create<ChromeOptionsRequestPayload>(modificationInfo);
        _ = await this.ClientContext.PostObjectAsync<ODataV1Object>(requestUrl, requestPayload);
    }

}
