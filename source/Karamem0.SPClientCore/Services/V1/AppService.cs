//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Newtonsoft.Json.Linq;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IAppService
{

    Task<App?> AddObjectAsync(
        System.IO.Stream appContent,
        string appName,
        bool overwrite,
        bool isTenant
    );

    Task<App?> GetObjectAsync(App appObject, bool isTenant);

    Task<App?> GetObjectAsync(Guid appId, bool isTenant);

    Task<IEnumerable<App>?> GetObjectEnumerableAsync(bool isTenant);

    Task InstallObjectAsync(App appObject, bool isTenant);

    Task PublishObjectAsync(App appObject, bool isTenant);

    Task RemoveObjectAsync(App appObject, bool isTenant);

    Task UninstallObjectAsync(App appObject, bool isTenant);

    Task UnpublishObjectAsync(App appObject, bool isTenant);

    Task UpdateObjectAsync(App appObject, bool isTenant);

}

public class AppService(ClientContext clientContext) : ClientService(clientContext), IAppService
{

    public async Task<App?> AddObjectAsync(
        System.IO.Stream appContent,
        string appName,
        bool overwrite,
        bool isTenant
    )
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/{0}/add(url='{1}',overwrite={2})",
                isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
                appName,
                overwrite
            )
            .ConcatQuery("$expand=ListItemAllFields&$select=ListItemAllFields/UniqueId");
        var file = await this.ClientContext.PostStreamAsync<ODataV1Object>(requestUrl, appContent);
        var item = (JToken?)file?["ListItemAllFields"];
        var uniqueId = item?["UniqueId"];
        var appId = uniqueId?.ToObject<Guid>();
        _ = appId ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return await this.GetObjectAsync(appId.Value, isTenant);
    }

    public async Task<App?> GetObjectAsync(App appObject, bool isTenant)
    {
        return await this.GetObjectAsync(appObject.Id, isTenant);
    }

    public async Task<App?> GetObjectAsync(Guid appId, bool isTenant)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/{0}/availableapps/getbyid('{1}')",
                isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
                appId
            )
            .ConcatQuery(ODataQuery.CreateSelect<App>());
        return await this.ClientContext.GetObjectAsync<App>(requestUrl);
    }

    public async Task<IEnumerable<App>?> GetObjectEnumerableAsync(bool isTenant)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/web/{0}/availableapps", isTenant ? "tenantappcatalog" : "sitecollectionappcatalog")
            .ConcatQuery(ODataQuery.CreateSelect<App>());
        return await this.ClientContext.GetObjectAsync<ODataV1ObjectEnumerable<App>>(requestUrl);
    }

    public async Task InstallObjectAsync(App appObject, bool isTenant)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/install",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

    public async Task PublishObjectAsync(App appObject, bool isTenant)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/deploy",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

    public async Task RemoveObjectAsync(App appObject, bool isTenant)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/remove",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

    public async Task UninstallObjectAsync(App appObject, bool isTenant)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/uninstall",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

    public async Task UnpublishObjectAsync(App appObject, bool isTenant)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/retract",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

    public async Task UpdateObjectAsync(App appObject, bool isTenant)
    {
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/upgrade",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        await this.ClientContext.PostObjectAsync(requestUrl, null);
    }

}
