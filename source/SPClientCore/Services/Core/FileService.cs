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
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.Core
{

    public interface IFileService
    {

        void CheckInFile(string fileUrl, string checkInComment, int? checkInType);

        void CheckOutFile(string fileUrl);

        void CopyFileTo(string fileUrl, string newUrl, bool overwrite);

        File CreateFile(string folderUrl, string fileName, System.IO.Stream fileContent, bool overwrite, string fileQuery = null);

        IEnumerable<File> FindFiles(string folderUrl, string folderQuery = null);

        File GetFile(FilePipeBind filePipeBind, string fileQuery = null);

        void MoveFileTo(string fileUrl, string newUrl, int moveOperations);

        System.IO.Stream OpenFile(string fileUrl);

        GuidResult RecycleFile(string fileUrl);

        void RemoveFile(string fileUrl);

        void UndoCheckOutFile(string fileUrl);

    }

    public class FileService : ClientObjectService, IFileService
    {

        public FileService(ClientContext clientContext) : base(clientContext)
        {
        }

        public void CheckInFile(string fileUrl, string checkInComment, int? checkInType)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/checkin(comment='{1}',checkintype={2})", fileUrl, checkInComment, checkInType);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void CheckOutFile(string fileUrl)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/checkout", fileUrl);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void CopyFileTo(string fileUrl, string newUrl, bool overwrite)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            if (newUrl == null)
            {
                throw new ArgumentNullException(nameof(newUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/copyto(strnewurl='{1}',boverwrite={2})", fileUrl, newUrl, overwrite);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public File CreateFile(string folderUrl, string fileName, System.IO.Stream fileContent, bool overwrite, string fileQuery = null)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            if (fileContent == null)
            {
                throw new ArgumentNullException(nameof(fileContent));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfolderbyserverrelativeurl('{0}')/files/add(url='{1}',overwrite={2})", folderUrl, fileName, overwrite)
                .ConcatQuery(fileQuery);
            return this.ClientContext.PostStream<File>(requestUrl, fileContent);
        }

        public IEnumerable<File> FindFiles(string folderUrl, string folderQuery = null)
        {
            if (folderUrl == null)
            {
                throw new ArgumentNullException(nameof(folderUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfolderbyserverrelativeurl('{0}')/files", folderUrl)
                .ConcatQuery(folderQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<File>>(requestUrl);
        }

        public File GetFile(FilePipeBind filePipeBind, string fileQuery = null)
        {
            if (filePipeBind == null)
            {
                throw new ArgumentNullException(nameof(filePipeBind));
            }
            if (filePipeBind.ClientObject != null)
            {
                if (filePipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = filePipeBind.ClientObject.Metadata.Uri.ConcatQuery(fileQuery);
                    return this.ClientContext.GetObject<File>(requestUrl);
                }
                else
                {
                    var requestUrl = filePipeBind.ClientObject.Deferred.Uri.ConcatQuery(fileQuery);
                    return this.ClientContext.GetObject<File>(requestUrl);
                }
            }
            if (filePipeBind.ServerRelativeUrl != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')", filePipeBind.ServerRelativeUrl)
                    .ConcatQuery(fileQuery);
                return this.ClientContext.GetObject<File>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(FilePipeBind)), nameof(filePipeBind));
        }

        public System.IO.Stream OpenFile(string fileUrl)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/openbinarystream", fileUrl);
            return this.ClientContext.GetStream(requestUrl);
        }

        public void MoveFileTo(string fileUrl, string newUrl, int moveOperations)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            if (newUrl == null)
            {
                throw new ArgumentNullException(nameof(newUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/moveto(newurl='{1}',flags={2})", fileUrl, newUrl, moveOperations);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public GuidResult RecycleFile(string fileUrl)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/recycle", fileUrl);
            return this.ClientContext.PostObject<GuidResult>(requestUrl, null);
        }

        public void RemoveFile(string fileUrl)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')", fileUrl);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void UndoCheckOutFile(string fileUrl)
        {
            if (fileUrl == null)
            {
                throw new ArgumentNullException(nameof(fileUrl));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/getfilebyserverrelativeurl('{0}')/undocheckout", fileUrl);
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
