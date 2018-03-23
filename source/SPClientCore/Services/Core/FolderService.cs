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
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds.Core;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Core
{

    public interface IFolderService
    {

        Folder CreateFolder(string folderUrl, string folderName, string folderQuery = null);

        IEnumerable<Folder> FindFolders(string folderUrl, string folderQuery = null);

        Folder GetFolder(FolderPipeBind folderPipeBind, string folderQuery = null);

        GuidResult RecycleFolder(string folderUrl);

        void RemoveFolder(string folderUrl);

        void UpdateFolder(string folderUrl, IDictionary<string, object> folderParameters);

    }

    public class FolderService : ClientObjectService, IFolderService
    {

        public FolderService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Folder CreateFolder(string folderUrl, string folderName, string folderQuery = null)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            if (folderName == null)
            {
                throw new ArgumentNullException(nameof(folderName));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfolderbyserverrelativeurl('{0}')/folders/add('{1}')", folderUrl, folderName)
                .ConcatQuery(folderQuery);
            return this.ClientContext.PostObject<Folder>(requestUrl, null);
        }

        public IEnumerable<Folder> FindFolders(string folderUrl, string folderQuery = null)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfolderbyserverrelativeurl('{0}')/folders", folderUrl)
                .ConcatQuery(folderQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<Folder>>(requestUrl);
        }

        public Folder GetFolder(FolderPipeBind folderPipeBind, string folderQuery = null)
        {
            if (folderPipeBind == null)
            {
                throw new ArgumentNullException(nameof(folderPipeBind));
            }
            if (folderPipeBind.ClientObject != null)
            {
                if (folderPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = folderPipeBind.ClientObject.Metadata.Uri.ConcatQuery(folderQuery);
                    return this.ClientContext.GetObject<Folder>(requestUrl);
                }
                else
                {
                    var requestUrl = folderPipeBind.ClientObject.Deferred.Uri.ConcatQuery(folderQuery);
                    return this.ClientContext.GetObject<Folder>(requestUrl);
                }
            }
            if (folderPipeBind.ServerRelativeUrl != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/getfolderbyserverrelativeurl('{0}')", folderPipeBind.ServerRelativeUrl)
                    .ConcatQuery(folderQuery);
                return this.ClientContext.GetObject<Folder>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(FolderPipeBind)), nameof(folderPipeBind));
        }

        public GuidResult RecycleFolder(string folderUrl)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfolderbyserverrelativeurl('{0}')/recycle", folderUrl);
            return this.ClientContext.PostObject<GuidResult>(requestUrl, null);
        }

        public void RemoveFolder(string folderUrl)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfolderbyserverrelativeurl('{0}')", folderUrl);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void UpdateFolder(string folderUrl, IDictionary<string, object> folderParameters)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            if (folderParameters == null)
            {
                throw new ArgumentNullException(nameof(folderParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfolderbyserverrelativeurl('{0}')", folderUrl);
            var requestPayload = new ODataRequestPayload<Folder>(folderParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

    }

}
