//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface ISiteCollectionAppService
{

    App AddObject(System.IO.Stream appContent, string appName, bool overwrite);

    App GetObject(App appObject);

    App GetObject(Guid? appId);

    IEnumerable<App> GetObjectEnumerable();

    void InstallObject(App appObject);

    void PublishObject(App appObject);

    void RemoveObject(App appObject);

    void UninstallObject(App appObject);

    void UnpublishObject(App appObject);

}

public class SiteCollectionAppService : ClientService, ISiteCollectionAppService
{

    public SiteCollectionAppService(ClientContext clientContext) : base(clientContext)
    {
    }

    public App AddObject(System.IO.Stream appContent, string appName, bool overwrite)
    {
        _ = appContent ?? throw new ArgumentNullException(nameof(appContent));
        _ = appName ?? throw new ArgumentNullException(nameof(appName));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/sitecollectionappcatalog/add(url='{0}',overwrite={1})",
                appName,
                overwrite)
            .ConcatQuery("$expand=ListItemAllFields&$select=ListItemAllFields/UniqueId");
        var file = this.ClientContext.PostStream<ODataV1Object>(requestUrl, appContent);
        var item = file["ListItemAllFields"] as JToken;
        return this.GetObject(new Guid(item["UniqueId"].ToString()));
    }

    public App GetObject(App appObject)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        return this.GetObject(appObject.Id);
    }

    public App GetObject(Guid? appId)
    {
        _ = appId ?? throw new ArgumentNullException(nameof(appId));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')",
                appId)
            .ConcatQuery(ODataQuery.CreateSelect<App>());
        return this.ClientContext.GetObject<App>(requestUrl);
    }

    public IEnumerable<App> GetObjectEnumerable()
    {
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath("_api/web/sitecollectionappcatalog/availableapps")
            .ConcatQuery(ODataQuery.CreateSelect<App>());
        return this.ClientContext.GetObject<ODataV1ObjectEnumerable<App>>(requestUrl);
    }

    public void InstallObject(App appObject)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/install",
                appObject.Id);
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void PublishObject(App appObject)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/deploy",
                appObject.Id);
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void RemoveObject(App appObject)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/remove",
                appObject.Id);
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void UninstallObject(App appObject)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/uninstall",
                appObject.Id);
        this.ClientContext.PostObject(requestUrl, null);
    }

    public void UnpublishObject(App appObject)
    {
        _ = appObject ?? throw new ArgumentNullException(nameof(appObject));
        var requestUrl = this.ClientContext.BaseAddress
            .ConcatPath(
                "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/deploy",
                appObject.Id);
        this.ClientContext.PostObject(requestUrl, null);
    }

}
