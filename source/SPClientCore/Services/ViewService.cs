//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Karamem0.SharePoint.PowerShell.Models;
using Karamem0.SharePoint.PowerShell.Models.OData;
using Karamem0.SharePoint.PowerShell.PipeBinds;
using Karamem0.SharePoint.PowerShell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public interface IViewService
    {

        View CreateView(Guid? listId, IDictionary<string, object> viewParameters, string viewQuery = null);

        IEnumerable<View> FindViews(Guid? listId, string viewQuery = null);

        View GetView(Guid? listId, ViewPipeBind viewPipeBind, string viewQuery = null);

        void RemoveView(Guid? listId, Guid? viewId);

        void UpdateView(Guid? listId, Guid? viewId, IDictionary<string, object> viewParameters);

        void AddViewField(Guid? listId, Guid? viewId, string viewFieldName);

        void MoveViewField(Guid? listId, Guid? viewId, string viewFieldName, int? viewFieldIndex);

        void RemoveAllViewFields(Guid? listId, Guid? viewId);

        void RemoveViewField(Guid? listId, Guid? viewId, string viewFieldName);

    }

    public class ViewService : ClientObjectService, IViewService
    {

        public ViewService(ClientContext clientContext) : base(clientContext)
        {
        }

        public View CreateView(Guid? listId, IDictionary<string, object> viewParameters, string viewQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (viewParameters == null)
            {
                throw new ArgumentNullException(nameof(viewParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/views", listId)
                .ConcatQuery(viewQuery);
            var requestPayload = new ODataRequestPayload<View>(viewParameters);
            return this.ClientContext.PostObject<View>(requestUrl, requestPayload.Entity);
        }

        public IEnumerable<View> FindViews(Guid? listId, string viewQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/views", listId)
                .ConcatQuery(viewQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<View>>(requestUrl);
        }

        public View GetView(Guid? listId, ViewPipeBind viewPipeBind, string viewQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (viewPipeBind == null)
            {
                throw new ArgumentNullException(nameof(viewPipeBind));
            }
            if (viewPipeBind.ClientObject != null)
            {
                if (viewPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = viewPipeBind.ClientObject.Metadata.Uri.ConcatQuery(viewQuery);
                    return this.ClientContext.GetObject<View>(requestUrl);
                }
                else
                {
                    var requestUrl = viewPipeBind.ClientObject.Deferred.Uri.ConcatQuery(viewQuery);
                    return this.ClientContext.GetObject<View>(requestUrl);
                }
            }
            if (viewPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists('{0}')/views/getbyid('{1}')", listId, viewPipeBind.Id)
                    .ConcatQuery(viewQuery);
                return this.ClientContext.GetObject<View>(requestUrl);
            }
            if (viewPipeBind.Title != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists('{0}')/views/getbytitle('{1}')", listId, viewPipeBind.Title)
                    .ConcatQuery(viewQuery);
                return this.ClientContext.GetObject<View>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(ViewPipeBind)), nameof(viewPipeBind));
        }

        public void RemoveView(Guid? listId, Guid? viewId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (viewId == null)
            {
                throw new ArgumentNullException(nameof(viewId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/views('{1}')", listId, viewId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void UpdateView(Guid? listId, Guid? viewId, IDictionary<string, object> viewParameters)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (viewId == null)
            {
                throw new ArgumentNullException(nameof(viewId));
            }
            if (viewParameters == null)
            {
                throw new ArgumentNullException(nameof(viewParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/views('{1}')", listId, viewId);
            var requestPayload = new ODataRequestPayload<View>(viewParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

        public void AddViewField(Guid? listId, Guid? viewId, string viewFieldName)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (viewId == null)
            {
                throw new ArgumentNullException(nameof(viewId));
            }
            if (viewFieldName == null)
            {
                throw new ArgumentNullException(nameof(viewFieldName));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/views('{1}')/viewfields/addviewfield('{2}')", listId, viewId, viewFieldName);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void MoveViewField(Guid? listId, Guid? viewId, string viewFieldName, int? viewFieldIndex)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (viewId == null)
            {
                throw new ArgumentNullException(nameof(viewId));
            }
            if (viewFieldName == null)
            {
                throw new ArgumentNullException(nameof(viewFieldName));
            }
            if (viewFieldIndex == null)
            {
                throw new ArgumentNullException(nameof(viewFieldIndex));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/views('{1}')/viewfields/moveviewfieldto(field='{2}',index={3})",
                    listId, viewId, viewFieldName, viewFieldIndex);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveAllViewFields(Guid? listId, Guid? viewId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (viewId == null)
            {
                throw new ArgumentNullException(nameof(viewId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/views('{1}')/viewfields/removeallviewfields", listId, viewId);
            this.ClientContext.PostObject(requestUrl, null);
        }

        public void RemoveViewField(Guid? listId, Guid? viewId, string viewFieldName)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (viewId == null)
            {
                throw new ArgumentNullException(nameof(viewId));
            }
            if (viewFieldName == null)
            {
                throw new ArgumentNullException(nameof(viewFieldName));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/views('{1}')/viewfields/removeviewfield('{2}')", listId, viewId, viewFieldName);
            this.ClientContext.PostObject(requestUrl, null);
        }

    }

}
