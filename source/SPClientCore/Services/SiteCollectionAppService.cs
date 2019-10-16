//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface ISiteCollectionAppService
    {

        App CreateObject(System.IO.Stream appContent, string appName, bool overwrite);

        App GetObject(Guid appId);

        IEnumerable<App> GetObjectEnumerable();

        void InstallObject(Guid appId);

        void PublishObject(Guid appId);

        void RemoveObject(Guid appId);

        void UninstallObject(Guid appId);

        void UnpublishObject(Guid appId);

    }

    public class SiteCollectionAppService : ClientService, ISiteCollectionAppService
    {

        public SiteCollectionAppService(ClientContext clientContext) : base(clientContext)
        {
        }

        public App CreateObject(System.IO.Stream appContent, string appName, bool overwrite)
        {
            if (appContent == null)
            {
                throw new ArgumentNullException(nameof(appContent));
            }
            if (appName == null)
            {
                throw new ArgumentNullException(nameof(appName));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/sitecollectionappcatalog/add(url='{0}',overwrite={1})",
                    appName,
                    overwrite)
                .ConcatQuery("$expand=ListItemAllFields&$select=ListItemAllFields/UniqueId");
            var file = this.ClientContext.PostStream<ODataObject>(requestUrl, appContent);
            var item = file["ListItemAllFields"] as JToken;
            return this.GetObject(new Guid(item["UniqueId"].ToString()));
        }

        public App GetObject(Guid appId)
        {
            if (appId == default(Guid))
            {
                throw new ArgumentNullException(nameof(appId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')",
                    appId)
                .ConcatQuery(ODataQuery.Create<App>());
            return this.ClientContext.GetObject<App>(requestUrl);
        }

        public IEnumerable<App> GetObjectEnumerable()
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps")
                .ConcatQuery(ODataQuery.Create<App>());
            return this.ClientContext.GetObject<ODataObjectEnumerable<App>>(requestUrl);
        }

        public void InstallObject(Guid appId)
        {
            if (appId == default(Guid))
            {
                throw new ArgumentNullException(nameof(appId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/install",
                    appId);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void PublishObject(Guid appId)
        {
            if (appId == default(Guid))
            {
                throw new ArgumentNullException(nameof(appId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/deploy",
                    appId);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveObject(Guid appId)
        {
            if (appId == default(Guid))
            {
                throw new ArgumentNullException(nameof(appId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/remove",
                    appId);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UninstallObject(Guid appId)
        {
            if (appId == default(Guid))
            {
                throw new ArgumentNullException(nameof(appId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/uninstall",
                    appId);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UnpublishObject(Guid appId)
        {
            if (appId == default(Guid))
            {
                throw new ArgumentNullException(nameof(appId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath(
                    "_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')/deploy",
                    appId);
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
