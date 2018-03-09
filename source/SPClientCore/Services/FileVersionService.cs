//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.PipeBinds;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IFileVersionService
    {

        IEnumerable<FileVersion> FindFileVersions(string fileUrl, string fileVersionQuer);

        FileVersion GetFileVersion(string fileUrl, FileVersionPipeBind fileVersionPipeBind, string fileVersionQuery = null);

        void RemoveAllFileVersions(string fileUrl);

        void RemoveFileVersion(string fileUrl, int? fileVersionId);

        void RestoreFileVersion(string fileUrl, string fileVersionLabel);

    }

    public class FileVersionService : ClientObjectService, IFileVersionService
    {

        public FileVersionService(ClientContext clientContext) : base(clientContext)
        {
        }

        public IEnumerable<FileVersion> FindFileVersions(string fileUrl, string fileVersionQuery = null)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/versions", fileUrl)
                .ConcatQuery(fileVersionQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<FileVersion>>(requestUrl);
        }

        public FileVersion GetFileVersion(string fileUrl, FileVersionPipeBind fileVersionPipeBind, string fileVersionQuery = null)
        {
            if (fileVersionPipeBind == null)
            {
                throw new ArgumentNullException(nameof(fileVersionPipeBind));
            }
            if (fileVersionPipeBind.ClientObject != null)
            {
                if (fileVersionPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = fileVersionPipeBind.ClientObject.Metadata.Uri.ConcatQuery(fileVersionQuery);
                    return this.ClientContext.GetObject<FileVersion>(requestUrl);
                }
                else
                {
                    var requestUrl = fileVersionPipeBind.ClientObject.Deferred.Uri.ConcatQuery(fileVersionQuery);
                    return this.ClientContext.GetObject<FileVersion>(requestUrl);
                }
            }
            if (fileVersionPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/versions/getbyid({1})", fileUrl, fileVersionPipeBind.Id)
                    .ConcatQuery(fileVersionQuery);
                return this.ClientContext.GetObject<FileVersion>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(FileVersionPipeBind)), nameof(fileVersionPipeBind));
        }

        public void RemoveAllFileVersions(string fileUrl)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/versions/deleteall", fileUrl);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveFileVersion(string fileUrl, int? fileVersionId)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            if (fileVersionId == null)
            {
                throw new ArgumentNullException(nameof(fileVersionId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/versions({1})", fileUrl, fileVersionId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void RestoreFileVersion(string fileUrl, string fileVersionLabel)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            if (fileVersionLabel == null)
            {
                throw new ArgumentNullException(nameof(fileVersionLabel));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/versions/restorebylabel(versionlabel='{1}')",
                    fileUrl, fileVersionLabel);
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
