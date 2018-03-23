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

    public interface IContentTypeService
    {

        ContentType CreateContentType(Guid? listId, IDictionary<string, object> contentTypeParameters, string contentTypeQuery = null);

        ContentType CreateContentType(IDictionary<string, object> contentTypeParameters, string contentTypeQuery = null);

        IEnumerable<ContentType> FindContentTypes(string contentTypeQuery = null);

        IEnumerable<ContentType> FindContentTypes(Guid? listId, string contentTypeQuery = null);

        ContentType GetContentType(ContentTypePipeBind contentTypePipeBind, string contentTypeQuery = null);

        ContentType GetContentType(Guid? listId, ContentTypePipeBind contentTypePipeBind, string contentTypeQuery = null);

        void RemoveContentType(Guid? listId, string contentTypeId);

        void RemoveContentType(string contentTypeId);

        void UpdateContentType(Guid? listId, string contentTypeId, IDictionary<string, object> contentTypeParameters);

        void UpdateContentType(string contentTypeId, IDictionary<string, object> contentTypeParameters);

    }

    public class ContentTypeService : ClientObjectService, IContentTypeService
    {

        public ContentTypeService(ClientContext clientContext) : base(clientContext)
        {
        }

        public ContentType CreateContentType(IDictionary<string, object> contentTypeParameters, string contentTypeQuery = null)
        {
            if (contentTypeParameters == null)
            {
                throw new ArgumentNullException(nameof(contentTypeParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/contenttypes")
                .ConcatQuery(contentTypeQuery);
            var requestPayload = new ODataRequestPayload<ContentType>(contentTypeParameters);
            return this.ClientContext.PostObject<ContentType>(requestUrl, requestPayload.Entity);
        }

        public ContentType CreateContentType(Guid? listId, IDictionary<string, object> contentTypeParameters, string contentTypeQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (contentTypeParameters == null)
            {
                throw new ArgumentNullException(nameof(contentTypeParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/contenttypes", listId)
                .ConcatQuery(contentTypeQuery);
            var requestPayload = new ODataRequestPayload<ContentType>(contentTypeParameters);
            return this.ClientContext.PostObject<ContentType>(requestUrl, requestPayload.Entity);
        }

        public IEnumerable<ContentType> FindContentTypes(string contentTypeQuery = null)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/contenttypes")
                .ConcatQuery(contentTypeQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<ContentType>>(requestUrl);
        }

        public IEnumerable<ContentType> FindContentTypes(Guid? listId, string contentTypeQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/contenttypes", listId)
                .ConcatQuery(contentTypeQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<ContentType>>(requestUrl);
        }

        public ContentType GetContentType(ContentTypePipeBind contentTypePipeBind, string contentTypeQuery = null)
        {
            if (contentTypePipeBind == null)
            {
                throw new ArgumentNullException(nameof(contentTypePipeBind));
            }
            if (contentTypePipeBind.ClientObject != null)
            {
                if (contentTypePipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = contentTypePipeBind.ClientObject.Metadata.Uri.ConcatQuery(contentTypeQuery);
                    return this.ClientContext.GetObject<ContentType>(requestUrl);
                }
                else
                {
                    var requestUrl = contentTypePipeBind.ClientObject.Deferred.Uri.ConcatQuery(contentTypeQuery);
                    return this.ClientContext.GetObject<ContentType>(requestUrl);
                }
            }
            if (contentTypePipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/contenttypes/getbyid('{0}')", contentTypePipeBind.Id)
                    .ConcatQuery(contentTypeQuery);
                return this.ClientContext.GetObject<ContentType>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(FieldPipeBind)), nameof(contentTypePipeBind));
        }

        public ContentType GetContentType(Guid? listId, ContentTypePipeBind contentTypePipeBind, string contentTypeQuery = null)
        {
            if (contentTypePipeBind == null)
            {
                throw new ArgumentNullException(nameof(contentTypePipeBind));
            }
            if (contentTypePipeBind.ClientObject != null)
            {
                if (contentTypePipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = contentTypePipeBind.ClientObject.Metadata.Uri.ConcatQuery(contentTypeQuery);
                    return this.ClientContext.GetObject<ContentType>(requestUrl);
                }
                else
                {
                    var requestUrl = contentTypePipeBind.ClientObject.Deferred.Uri.ConcatQuery(contentTypeQuery);
                    return this.ClientContext.GetObject<ContentType>(requestUrl);
                }
            }
            if (contentTypePipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists('{0}')/contenttypes/getbyid('{1}')", listId, contentTypePipeBind.Id)
                    .ConcatQuery(contentTypeQuery);
                return this.ClientContext.GetObject<ContentType>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(ContentTypePipeBind)), nameof(contentTypePipeBind));
        }

        public void RemoveContentType(string contentTypeId)
        {
            if (contentTypeId == null)
            {
                throw new ArgumentNullException(nameof(contentTypeId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/contenttypes('{0}')", contentTypeId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void RemoveContentType(Guid? listId, string contentTypeId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (contentTypeId == null)
            {
                throw new ArgumentNullException(nameof(contentTypeId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/contenttypes('{1}')", listId, contentTypeId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void UpdateContentType(string contentTypeId, IDictionary<string, object> contentTypeParameters)
        {
            if (contentTypeId == null)
            {
                throw new ArgumentNullException(nameof(contentTypeId));
            }
            if (contentTypeParameters == null)
            {
                throw new ArgumentNullException(nameof(contentTypeParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/contenttypes('{0}')", contentTypeId);
            var requestPayload = new ODataRequestPayload<Field>(contentTypeParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

        public void UpdateContentType(Guid? listId, string contentTypeId, IDictionary<string, object> contentTypeParameters)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (contentTypeId == null)
            {
                throw new ArgumentNullException(nameof(contentTypeId));
            }
            if (contentTypeParameters == null)
            {
                throw new ArgumentNullException(nameof(contentTypeParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/contenttypes('{1}')", listId, contentTypeId);
            var requestPayload = new ODataRequestPayload<Field>(contentTypeParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

    }

}
