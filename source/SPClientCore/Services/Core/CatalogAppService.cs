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


    public interface ICatalogAppService
    {

        File CreateTenantCatalogApp(string catalogAppName, System.IO.Stream catalogAppContent, bool overwrite, string catalogAppQuery = null);

        void DeployTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        IEnumerable<CatalogApp> FindTenantCatalogApps(string catalogAppQuery = null);

        CatalogApp GetTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind, string catalogAppQuery = null);

        void InstallTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        void RemoveTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        void RetractTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        void UninstallTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        void UpgradeTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        File CreateSiteCatalogApp(string catalogAppName, System.IO.Stream catalogAppContent, bool overwrite, string catalogAppQuery = null);

        void DeploySiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        IEnumerable<CatalogApp> FindSiteCatalogApps(string catalogAppQuery = null);

        CatalogApp GetSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind, string catalogAppQuery = null);

        void InstallSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        void RemoveSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        void RetractSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        void UpgradeSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

        void UninstallSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind);

    }

    public class CatalogAppService : ClientObjectService, ICatalogAppService
    {

        public CatalogAppService(ClientContext clientContext) : base(clientContext)
        {
        }

        public File CreateTenantCatalogApp(string catalogAppName, System.IO.Stream catalogAppContent, bool overwrite, string catalogAppQuery = null)
        {
            if (catalogAppName == null)
            {
                throw new ArgumentNullException(nameof(catalogAppName));
            }
            if (catalogAppContent == null)
            {
                throw new ArgumentNullException(nameof(catalogAppContent));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/add(url='{0}',overwrite={1})", catalogAppName, overwrite)
                .ConcatQuery(catalogAppQuery);
            return this.ClientContext.PostStream<File>(requestUrl, catalogAppContent);
        }

        public void DeployTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/deploy", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public IEnumerable<CatalogApp> FindTenantCatalogApps(string catalogAppQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps")
                .ConcatQuery(catalogAppQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<CatalogApp>>(requestUrl);
        }

        public CatalogApp GetTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind, string catalogAppQuery = null)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            if (catalogAppPipeBind.ClientObject != null)
            {
                if (catalogAppPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = catalogAppPipeBind.ClientObject.Metadata.Uri.ConcatQuery(catalogAppQuery);
                    return this.ClientContext.GetObject<CatalogApp>(requestUrl);
                }
                else
                {
                    var requestUrl = catalogAppPipeBind.ClientObject.Deferred.Uri.ConcatQuery(catalogAppQuery);
                    return this.ClientContext.GetObject<CatalogApp>(requestUrl);
                }
            }
            if (catalogAppPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/tenantappcatalog/availableapps/getbyid('{0}')", catalogAppPipeBind.Id)
                    .ConcatQuery(catalogAppQuery);
                return this.ClientContext.GetObject<CatalogApp>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(CatalogAppPipeBind)), nameof(catalogAppPipeBind));
        }

        public void InstallTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/install", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/remove", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RetractTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/retract", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UninstallTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/uninstall", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UpgradeTenantCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/tenantappcatalog/availableapps('{0}')/upgrade", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public File CreateSiteCatalogApp(string catalogAppName, System.IO.Stream catalogAppContent, bool overwrite, string catalogAppQuery = null)
        {
            if (catalogAppName == null)
            {
                throw new ArgumentNullException(nameof(catalogAppName));
            }
            if (catalogAppContent == null)
            {
                throw new ArgumentNullException(nameof(catalogAppContent));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/add(url='{0}',overwrite={1})", catalogAppName, overwrite)
                .ConcatQuery(catalogAppQuery);
            return this.ClientContext.PostStream<File>(requestUrl, catalogAppContent);
        }

        public void DeploySiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/deploy", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public IEnumerable<CatalogApp> FindSiteCatalogApps(string catalogAppQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps")
                .ConcatQuery(catalogAppQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<CatalogApp>>(requestUrl);
        }

        public CatalogApp GetSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind, string catalogAppQuery = null)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            if (catalogAppPipeBind.ClientObject != null)
            {
                if (catalogAppPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = catalogAppPipeBind.ClientObject.Metadata.Uri.ConcatQuery(catalogAppQuery);
                    return this.ClientContext.GetObject<CatalogApp>(requestUrl);
                }
                else
                {
                    var requestUrl = catalogAppPipeBind.ClientObject.Deferred.Uri.ConcatQuery(catalogAppQuery);
                    return this.ClientContext.GetObject<CatalogApp>(requestUrl);
                }
            }
            if (catalogAppPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/sitecollectionappcatalog/availableapps/getbyid('{0}')", catalogAppPipeBind.Id)
                    .ConcatQuery(catalogAppQuery);
                return this.ClientContext.GetObject<CatalogApp>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(CatalogAppPipeBind)), nameof(catalogAppPipeBind));
        }

        public void InstallSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/install", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/remove", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RetractSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/retract", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UninstallSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/uninstall", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void UpgradeSiteCatalogApp(CatalogAppPipeBind catalogAppPipeBind)
        {
            if (catalogAppPipeBind == null)
            {
                throw new ArgumentNullException(nameof(catalogAppPipeBind));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/sitecollectionappcatalog/availableapps('{0}')/upgrade", catalogAppPipeBind.Id);
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
