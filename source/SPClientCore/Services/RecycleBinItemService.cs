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

    public interface IRecycleBinItemService
    {

        IEnumerable<RecycleBinItem> FindRecycleBinItems(string recycleBinItemQuery = null);

        RecycleBinItem GetRecycleBinItem(RecycleBinItemPipeBind recycleBinItemPipeBind, string recycleBinItemQuery = null);

        void RemoveAllRecycleBinItems();

        void RemoveRecycleBinItem(Guid? recycleBinItemId);

        void RestoreAllRecycleBinItems();

        void RestoreRecycleBinItem(Guid? recycleBinItemId);

    }

    public class RecycleBinItemService : ClientObjectService, IRecycleBinItemService
    {

        public RecycleBinItemService(ClientContext clientContext) : base(clientContext)
        {
        }

        public IEnumerable<RecycleBinItem> FindRecycleBinItems(string recycleBinItemQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/recyclebin")
                .ConcatQuery(recycleBinItemQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<RecycleBinItem>>(requestUrl);
        }

        public RecycleBinItem GetRecycleBinItem(RecycleBinItemPipeBind recycleBinItemPipeBind, string recycleBinItemQuery = null)
        {
            if (recycleBinItemPipeBind == null)
            {
                throw new ArgumentNullException(nameof(recycleBinItemPipeBind));
            }
            if (recycleBinItemPipeBind.ClientObject != null)
            {
                if (recycleBinItemPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = recycleBinItemPipeBind.ClientObject.Metadata.Uri.ConcatQuery(recycleBinItemQuery);
                    return this.ClientContext.GetObject<RecycleBinItem>(requestUrl);
                }
                else
                {
                    var requestUrl = recycleBinItemPipeBind.ClientObject.Deferred.Uri.ConcatQuery(recycleBinItemQuery);
                    return this.ClientContext.GetObject<RecycleBinItem>(requestUrl);
                }
            }
            if (recycleBinItemPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/recyclebin/getbyid('{0}')", recycleBinItemPipeBind.Id)
                    .ConcatQuery(recycleBinItemQuery);
                return this.ClientContext.GetObject<RecycleBinItem>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(RecycleBinItemPipeBind)), nameof(recycleBinItemPipeBind));
        }

        public void RemoveRecycleBinItem(Guid? recycleBinItemId)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/recyclebin('{0}')", recycleBinItemId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void RemoveAllRecycleBinItems()
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/recyclebin/deleteall");
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RestoreRecycleBinItem(Guid? recycleBinItemId)
        {
            if (recycleBinItemId == null)
            {
                throw new ArgumentNullException(nameof(recycleBinItemId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/recyclebin('{0}')/restore", recycleBinItemId);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RestoreAllRecycleBinItems()
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/recyclebin/restoreall");
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
