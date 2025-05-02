//
// Copyright (c) 2018-2025 karamem0
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IAppService
{

    App? AddObject(
        System.IO.Stream appContent,
        string appName,
        bool overwrite,
        bool isTenant
    );

    App? GetObject(App appObject, bool isTenant);

    App? GetObject(Guid appId, bool isTenant);

    IEnumerable<App>? GetObjectEnumerable(bool isTenant);

    void InstallObject(App appObject, bool isTenant);

    void PublishObject(App appObject, bool isTenant);

    void RemoveObject(App appObject, bool isTenant);

    void UninstallObject(App appObject, bool isTenant);

    void UnpublishObject(App appObject, bool isTenant);

    void UpdateObject(App appObject, bool isTenant);

}

public class AppService(ClientContext clientContext) : ClientService(clientContext), IAppService
{

    public App? AddObject(
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
        var file = this.ClientContext.PostStream<ODataV1Object>(requestUrl, appContent);
        var item = (JToken?)file?["ListItemAllFields"];
        var uniqueId = item?["UniqueId"];
        var appId = uniqueId?.ToObject<Guid>();
        _ = appId ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return this.GetObject(appId.Value, isTenant);
    }

    public App? GetObject(App appObject, bool isTenant)
    {
        return this.GetObject(appObject.Id, isTenant);
    }

    public App? GetObject(Guid appId, bool isTenant)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath(
                "_api/web/{0}/availableapps/getbyid('{1}')",
                isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
                appId
            )
            .ConcatQuery(ODataQuery.CreateSelect<App>());
        return this.ClientContext.GetObject<App>(requestUrl);
    }

    public IEnumerable<App>? GetObjectEnumerable(bool isTenant)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/web/{0}/availableapps", isTenant ? "tenantappcatalog" : "sitecollectionappcatalog")
            .ConcatQuery(ODataQuery.CreateSelect<App>());
        return this.ClientContext.GetObject<ODataV1ObjectEnumerable<App>>(requestUrl);
    }

    public void InstallObject(App appObject, bool isTenant)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/install",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void PublishObject(App appObject, bool isTenant)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/deploy",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void RemoveObject(App appObject, bool isTenant)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/remove",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void UninstallObject(App appObject, bool isTenant)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/uninstall",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void UnpublishObject(App appObject, bool isTenant)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/retract",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void UpdateObject(App appObject, bool isTenant)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress.ConcatPath(
            "_api/web/{0}/availableapps/getbyid('{1}')/upgrade",
            isTenant ? "tenantappcatalog" : "sitecollectionappcatalog",
            appObject.Id
        );
        this.ClientContext.PostObject(requestUrl, null);
    }

}
