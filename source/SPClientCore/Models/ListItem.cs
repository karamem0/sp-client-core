//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    [JsonObject(Id = "SP.ListItem")]
    public class ListItem : SecurableObject
    {

        public ListItem()
        {
        }

        public ListItem(IDictionary<string, object> properties)
        {
            foreach (var property in properties)
            {
                var valueType = property.Value.GetType();
                if (valueType.IsArray)
                {
                    var elementType = valueType.GetElementType();
                    var collectionType = typeof(ClientValueObjectCollection<>);
                    var genericType = collectionType.MakeGenericType(elementType);
                    this.ExtendedProperties.Add(property.Key, JToken.FromObject(Activator.CreateInstance(genericType, property.Value)));
                }
                else
                {
                    this.ExtendedProperties.Add(property.Key, JToken.FromObject(property.Value));
                }
            }
        }

        [JsonProperty()]
        public ClientObjectCollection<Attachment> AttachmentFiles { get; private set; }

        [JsonProperty()]
        public ContentType ContentType { get; private set; }

        //[JsonProperty()]
        //public BasePermissions EffectiveBasePermissions { get; private set; }

        //[JsonProperty()]
        //public BasePermissions EffectiveBasePermissionsForUI { get; private set; }

        [JsonProperty()]
        public FieldStringValues FieldValuesAsHtml { get; private set; }

        [JsonProperty()]
        public FieldStringValues FieldValuesAsText { get; private set; }

        [JsonProperty()]
        public FieldStringValues FieldValuesForEdit { get; private set; }

        [JsonProperty()]
        public File File { get; private set; }

        [JsonProperty()]
        public FileSystemObjectType? FileSystemObjectType { get; private set; }

        [JsonProperty()]
        public SecurableObject FirstUniqueAncestorSecurableObject { get; private set; }

        [JsonProperty()]
        public Folder Folder { get; private set; }

        [JsonProperty()]
        public int? Id { get; private set; }

        [JsonProperty()]
        public List ParentList { get; private set; }

    }

}
