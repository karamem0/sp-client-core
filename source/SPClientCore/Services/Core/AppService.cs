//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.Core;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Core
{

    public interface IAppService
    {

        File CreateTenantApp(string appName, System.IO.Stream appContent, bool overwrite, string appQuery = null);

        void DeployTenantApp(AppPipeBind appPipeBind);

        IEnumerable<CorporateCatalogAppMetadata> FindTenantApps(string appQuery = null);

        CorporateCatalogAppMetadata GetTenantApp(AppPipeBind appPipeBind, string appQuery = null);

        void InstallTenantApp(AppPipeBind appPipeBind);

        void RemoveTenantApp(AppPipeBind appPipeBind);

        void RetractTenantApp(AppPipeBind appPipeBind);

        void UninstallTenantApp(AppPipeBind appPipeBind);

        void UpgradeTenantApp(AppPipeBind appPipeBind);

        File CreateSiteCollectionApp(string appName, System.IO.Stream appContent, bool overwrite, string appQuery = null);

        void DeploySiteCollectionApp(AppPipeBind appPipeBind);

        IEnumerable<CorporateCatalogAppMetadata> FindSiteCollectionApps(string appQuery = null);

        CorporateCatalogAppMetadata GetSiteCollectionApp(AppPipeBind appPipeBind, string appQuery = null);

        void InstallSiteCollectionApp(AppPipeBind appPipeBind);

        void RemoveSiteCollectionApp(AppPipeBind appPipeBind);

        void RetractSiteCollectionApp(AppPipeBind appPipeBind);

        void UpgradeSiteCollectionApp(AppPipeBind appPipeBind);

        void UninstallSiteCollectionApp(AppPipeBind appPipeBind);

    }

    public class AppService : ClientObjectService, IAppService
    {

        public AppService(ClientContext clientContext) : base(clientContext)
        {
        }

        public File CreateTenantApp(string appName, System.IO.Stream appContent, bool overwrite, string appQuery = null)
        {
            if (appName == null)
            {
                throw new ArgumentNullException(nameof(appName));
            }
            if (appContent == null)
            {
                throw new ArgumentNullException(nameof(appContent));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/add(url='{0}',overwrite={1})", appName, overwrite)
                .ConcatQuery(appQuery);
            return this.ClientContext.PostStream<File>(requestUrl, appContent);
        }

        public void DeployTenantApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/deploy", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public IEnumerable<CorporateCatalogAppMetadata> FindTenantApps(string appQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps")
                .ConcatQuery(appQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<CorporateCatalogAppMetadata>>(requestUrl);
        }

        public CorporateCatalogAppMetadata GetTenantApp(AppPipeBind appPipeBind, string appQuery = null)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            if (appPipeBind.ClientObject != null)
            {
                if (appPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = appPipeBind.ClientObject.Metadata.Uri.ConcatQuery(appQuery);
                    return this.ClientContext.GetObject<CorporateCatalogAppMetadata>(requestUrl);
                }
                else
                {
                    var requestUrl = appPipeBind.ClientObject.Deferred.Uri.ConcatQuery(appQuery);
                    return this.ClientContext.GetObject<CorporateCatalogAppMetadata>(requestUrl);
                }
            }
            if (appPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/tenantappcatalog/availableapps/getbyid('{0}')", appPipeBind.Id)
                    .ConcatQuery(appQuery);
                return this.ClientContext.GetObject<CorporateCatalogAppMetadata>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(AppPipeBind)), nameof(appPipeBind));
        }

        public void InstallTenantApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/install", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveTenantApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/remove", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RetractTenantApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/retract", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UninstallTenantApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/uninstall", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UpgradeTenantApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/upgrade", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public File CreateSiteCollectionApp(string appName, System.IO.Stream appContent, bool overwrite, string appQuery = null)
        {
            if (appName == null)
            {
                throw new ArgumentNullException(nameof(appName));
            }
            if (appContent == null)
            {
                throw new ArgumentNullException(nameof(appContent));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/add(url='{0}',overwrite={1})", appName, overwrite)
                .ConcatQuery(appQuery);
            return this.ClientContext.PostStream<File>(requestUrl, appContent);
        }

        public void DeploySiteCollectionApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/deploy", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public IEnumerable<CorporateCatalogAppMetadata> FindSiteCollectionApps(string appQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps")
                .ConcatQuery(appQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<CorporateCatalogAppMetadata>>(requestUrl);
        }

        public CorporateCatalogAppMetadata GetSiteCollectionApp(AppPipeBind appPipeBind, string appQuery = null)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            if (appPipeBind.ClientObject != null)
            {
                if (appPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = appPipeBind.ClientObject.Metadata.Uri.ConcatQuery(appQuery);
                    return this.ClientContext.GetObject<CorporateCatalogAppMetadata>(requestUrl);
                }
                else
                {
                    var requestUrl = appPipeBind.ClientObject.Deferred.Uri.ConcatQuery(appQuery);
                    return this.ClientContext.GetObject<CorporateCatalogAppMetadata>(requestUrl);
                }
            }
            if (appPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')", appPipeBind.Id)
                    .ConcatQuery(appQuery);
                return this.ClientContext.GetObject<CorporateCatalogAppMetadata>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(AppPipeBind)), nameof(appPipeBind));
        }

        public void InstallSiteCollectionApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/install", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveSiteCollectionApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/remove", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RetractSiteCollectionApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/retract", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UninstallSiteCollectionApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/uninstall", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UpgradeSiteCollectionApp(AppPipeBind appPipeBind)
        {
            if (appPipeBind == null)
            {
                throw new ArgumentNullException(nameof(appPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/upgrade", appPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
