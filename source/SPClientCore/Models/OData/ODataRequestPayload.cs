//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.OData
{

    [JsonObject()]
    public class ODataRequestPayload<T> where T : ClientObject
    {

        public ODataRequestPayload(IDictionary<string, object> parameters)
        {
            this.Entity = Activator.CreateInstance<T>();
            foreach (var property in this.Entity.GetType().GetProperties().Select(property => property.GetDeclaringProperty()))
            {
                if (parameters.TryGetValue(property.Name, out var value))
                {
                    if (property.PropertyType.IsGenericSubclassOf(typeof(ClientObjectCollection<>)))
                    {
                        property.SetValue(this.Entity, Activator.CreateInstance(property.PropertyType, value));
                    }
                    else
                    {
                        property.SetValue(this.Entity, value);
                    }
                }
            }
        }

        [JsonProperty("parameters")]
        public T Entity { get; private set; }

    }

}
