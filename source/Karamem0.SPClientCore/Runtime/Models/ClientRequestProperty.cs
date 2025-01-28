//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

public abstract class ClientRequestProperty : ClientRequestObject
{

    public static ClientRequestProperty Create(PropertyInfo propertyInfo, ClientRequestPayload payload, object value)
    {
        var propertyAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
        var propertyName = string.IsNullOrEmpty(propertyAttribute.PropertyName)
            ? propertyInfo.Name
            : propertyAttribute.PropertyName;
        var propertyValue = propertyInfo.GetValue(value);
        if (ClientRequestValue.TryCreate(propertyValue, out var valueObject))
        {
            return new ClientRequestPropertyValue(propertyName, valueObject);
        }
        else if (propertyValue is IDictionary dictionaryObject)
        {
            return new ClientRequestPropertyDictionary(propertyName, dictionaryObject);
        }
        else if (propertyValue is IEnumerable arrayObject)
        {
            return new ClientRequestPropertyArray(propertyName, arrayObject.OfType<object>());
        }
        else if (propertyValue is ClientObject clientObject)
        {
            return new ClientRequestPropertyObjectPath(
                propertyName,
                payload.Add(new ObjectPathIdentity(clientObject.ObjectIdentity))
            );
        }
        else if (propertyValue is ClientValueObject clientValueObject)
        {
            return new ClientRequestPropertyClientValueObject(propertyName, clientValueObject);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

}
