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

    public interface IFieldService
    {

        Field CreateField(Guid? listId, IDictionary<string, object> fieldParameters, string fieldQuery = null);

        Field CreateField(IDictionary<string, object> fieldParameters, string fieldQuery = null);

        Field CreateFieldAsXml(Guid? listId, IDictionary<string, object> fieldParameters, string fieldQuery = null);

        Field CreateFieldAsXml(IDictionary<string, object> fieldParameters, string fieldQuery = null);

        IEnumerable<Field> FindFields(Guid? listId, string fieldQuery = null);

        IEnumerable<Field> FindFields(string fieldQuery = null);

        Field GetField(FieldPipeBind fieldPipeBind, string fieldQuery = null);

        Field GetField(Guid? listId, FieldPipeBind fieldPipeBind, string fieldQuery = null);

        void RemoveField(Guid? fieldId);

        void RemoveField(Guid? listId, Guid? fieldId);

        void UpdateField(Guid? listId, Guid? fieldId, IDictionary<string, object> fieldParameters);

        void UpdateField(Guid? fieldId, IDictionary<string, object> fieldParameters);

    }

    public class FieldService : ClientObjectService, IFieldService
    {

        public FieldService(ClientContext clientContext) : base(clientContext)
        {
        }

        public Field CreateField(IDictionary<string, object> fieldParameters, string fieldQuery = null)
        {
            if (fieldParameters == null)
            {
                throw new ArgumentNullException(nameof(fieldParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/fields")
                .ConcatQuery(fieldQuery);
            var requestPayload = new ODataRequestPayload<Field>(fieldParameters);
            return this.ClientContext.PostObject<Field>(requestUrl, requestPayload.Entity);
        }

        public Field CreateField(Guid? listId, IDictionary<string, object> fieldParameters, string fieldQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (fieldParameters == null)
            {
                throw new ArgumentNullException(nameof(fieldParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/fields", listId)
                .ConcatQuery(fieldQuery);
            var requestPayload = new ODataRequestPayload<Field>(fieldParameters);
            return this.ClientContext.PostObject<Field>(requestUrl, requestPayload.Entity);
        }

        public Field CreateFieldAsXml(IDictionary<string, object> fieldParameters, string fieldQuery = null)
        {
            if (fieldParameters == null)
            {
                throw new ArgumentNullException(nameof(fieldParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/fields/createfieldasxml")
                .ConcatQuery(fieldQuery);
            var requestPayload = new ODataRequestPayload<XmlSchemaFieldCreationInformation>(fieldParameters);
            return this.ClientContext.PostObject<Field>(requestUrl, requestPayload);
        }

        public Field CreateFieldAsXml(Guid? listId, IDictionary<string, object> fieldParameters, string fieldQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (fieldParameters == null)
            {
                throw new ArgumentNullException(nameof(fieldParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/fields/createfieldasxml", listId)
                .ConcatQuery(fieldQuery);
            var requestPayload = new ODataRequestPayload<XmlSchemaFieldCreationInformation>(fieldParameters);
            return this.ClientContext.PostObject<Field>(requestUrl, requestPayload);
        }

        public IEnumerable<Field> FindFields(string fieldQuery)
        {
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/fields")
                .ConcatQuery(fieldQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<Field>>(requestUrl);
        }

        public IEnumerable<Field> FindFields(Guid? listId, string fieldQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/fields", listId)
                .ConcatQuery(fieldQuery);
            return this.ClientContext.GetObject<ClientObjectCollection<Field>>(requestUrl);
        }

        public Field GetField(FieldPipeBind fieldPipeBind, string fieldQuery = null)
        {
            if (fieldPipeBind == null)
            {
                throw new ArgumentNullException(nameof(fieldPipeBind));
            }
            if (fieldPipeBind.ClientObject != null)
            {
                if (fieldPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = fieldPipeBind.ClientObject.Metadata.Uri.ConcatQuery(fieldQuery);
                    return this.ClientContext.GetObject<Field>(requestUrl);
                }
                else
                {
                    var requestUrl = fieldPipeBind.ClientObject.Deferred.Uri.ConcatQuery(fieldQuery);
                    return this.ClientContext.GetObject<Field>(requestUrl);
                }
            }
            if (fieldPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/fields/getbyid('{0}')", fieldPipeBind.Id)
                    .ConcatQuery(fieldQuery);
                return this.ClientContext.GetObject<Field>(requestUrl);
            }
            if (fieldPipeBind.Title != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/fields/getbyinternalnameortitle('{0}')", fieldPipeBind.Title)
                    .ConcatQuery(fieldQuery);
                return this.ClientContext.GetObject<Field>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(FieldPipeBind)), nameof(fieldPipeBind));
        }

        public Field GetField(Guid? listId, FieldPipeBind fieldPipeBind, string fieldQuery = null)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (fieldPipeBind == null)
            {
                throw new ArgumentNullException(nameof(fieldPipeBind));
            }
            if (fieldPipeBind.ClientObject != null)
            {
                if (fieldPipeBind.ClientObject.Deferred == null)
                {
                    var requestUrl = fieldPipeBind.ClientObject.Metadata.Uri.ConcatQuery(fieldQuery);
                    return this.ClientContext.GetObject<Field>(requestUrl);
                }
                else
                {
                    var requestUrl = fieldPipeBind.ClientObject.Deferred.Uri.ConcatQuery(fieldQuery);
                    return this.ClientContext.GetObject<Field>(requestUrl);
                }
            }
            if (fieldPipeBind.Id != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists('{0}')/fields/getbyid('{1}')", listId, fieldPipeBind.Id)
                    .ConcatQuery(fieldQuery);
                return this.ClientContext.GetObject<Field>(requestUrl);
            }
            if (fieldPipeBind.Title != null)
            {
                var requestUrl = this.ClientContext.BaseAddress
                    .ConcatPath("_api/web/lists('{0}')/fields/getbyinternalnameortitle('{1}')", listId, fieldPipeBind.Title)
                    .ConcatQuery(fieldQuery);
                return this.ClientContext.GetObject<Field>(requestUrl);
            }
            throw new ArgumentException(string.Format(StringResources.ErrorValueIsInvalid, nameof(FieldPipeBind)), nameof(fieldPipeBind));
        }

        public void RemoveField(Guid? fieldId)
        {
            if (fieldId == null)
            {
                throw new ArgumentNullException(nameof(fieldId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/fields('{0}')", fieldId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void RemoveField(Guid? listId, Guid? fieldId)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (fieldId == null)
            {
                throw new ArgumentNullException(nameof(fieldId));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/fields('{1}')", listId, fieldId);
            this.ClientContext.DeleteObject(requestUrl);
        }

        public void UpdateField(Guid? fieldId, IDictionary<string, object> fieldParameters)
        {
            if (fieldId == null)
            {
                throw new ArgumentNullException(nameof(fieldId));
            }
            if (fieldParameters == null)
            {
                throw new ArgumentNullException(nameof(fieldParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/fields('{0}')", fieldId);
            var requestPayload = new ODataRequestPayload<Field>(fieldParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

        public void UpdateField(Guid? listId, Guid? fieldId, IDictionary<string, object> fieldParameters)
        {
            if (listId == null)
            {
                throw new ArgumentNullException(nameof(listId));
            }
            if (fieldId == null)
            {
                throw new ArgumentNullException(nameof(fieldId));
            }
            if (fieldParameters == null)
            {
                throw new ArgumentNullException(nameof(fieldParameters));
            }
            var requestUrl = this.ClientContext.BaseAddress
                .ConcatPath("_api/web/lists('{0}')/fields('{1}')", listId, fieldId);
            var requestPayload = new ODataRequestPayload<Field>(fieldParameters);
            this.ClientContext.MergeObject(requestUrl, requestPayload.Entity);
        }

    }

}
