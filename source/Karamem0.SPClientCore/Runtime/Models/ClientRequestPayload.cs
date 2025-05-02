//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Xml.Serialization;

namespace Karamem0.SharePoint.PowerShell.Runtime.Models;

[XmlType("Request", Namespace = "http://schemas.microsoft.com/sharepoint/clientquery/2009")]
public class ClientRequestPayload : ClientRequestObject
{

    [XmlAttribute("AddExpandoFieldTypeSuffix")]
    public bool AddExpandoColumnTypeSuffix => true;

    [XmlAttribute()]
    public string SchemaVersion => "15.0.0.0";

    [XmlAttribute()]
    public string LibraryVersion => "16.0.0.0";

    [XmlAttribute()]
    public string ApplicationName => "SPClientCore";

    [XmlArray()]
    public ClientActionCollection Actions { get; private set; } = [];

    [XmlArray()]
    public ObjectPathCollection ObjectPaths { get; private set; } = [];

    public ObjectPath Add(ObjectPath objectPath, IEnumerable<ClientActionDelegate> delegates)
    {
        return this.Add(objectPath, [.. delegates]);
    }

    public ObjectPath Add(ObjectPath objectPath, params ClientActionDelegate[] delegates)
    {
        _ = objectPath ?? throw new ArgumentNullException(nameof(objectPath));
        if (this.ObjectPaths.Count(item => item.Id == objectPath.Id) == 0)
        {
            this.ObjectPaths.Add(objectPath);
        }
        this.Actions.AddRange(delegates.Select(item => item.Invoke(objectPath.Id)));
        return objectPath;
    }

    public ClientRequestParameter CreateParameter(object? value)
    {
        if (ClientRequestValue.TryCreate(value, out var clientRequestValue))
        {
            return ClientRequestParameterValue.Create(clientRequestValue);
        }
        else if (value is IEnumerable arrayObject)
        {
            return ClientRequestParameterArray.Create(this, arrayObject.OfType<object>());
        }
        else if (value is ObjectPath objectPath)
        {
            return ClientRequestParameterObjectPath.Create(objectPath);
        }
        else if (value is ClientObject clientObject)
        {
            return ClientRequestParameterObjectPath.Create(this.Add(ObjectPathIdentity.Create(clientObject.ObjectIdentity)));
        }
        else if (value is ClientValueObject clientValueObject)
        {
            return ClientRequestParameterClientObject.Create(this, clientValueObject);
        }
        else if (value is PSObject psObject)
        {
            return ClientRequestParameterClientObject.Create(this, psObject.BaseObject);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public IEnumerable<ClientActionDelegate> CreateSetPropertyDelegates(Type objectType, IReadOnlyDictionary<string, object?> parameters)
    {
        foreach (var parameter in parameters)
        {
            var propertyInfo = objectType.GetDeclaredProperty(parameter.Key);
            if (propertyInfo is not null)
            {
                var propertyAttribute = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                if (propertyAttribute is not null)
                {
                    if (parameter.Value is ClientObject value)
                    {
                        yield return new ClientActionDelegate(objectPathId => ClientActionSetProperty.Create(
                                objectPathId,
                                string.IsNullOrEmpty(propertyAttribute.PropertyName) ? parameter.Key : propertyAttribute.PropertyName,
                                ClientRequestParameterObjectPath.Create(this.Add(ObjectPathIdentity.Create(value.ObjectIdentity)))
                            )
                        );
                    }
                    else
                    {
                        yield return new ClientActionDelegate(objectPathId => ClientActionSetProperty.Create(
                                objectPathId,
                                string.IsNullOrEmpty(propertyAttribute.PropertyName) ? parameter.Key : propertyAttribute.PropertyName,
                                this.CreateParameter(parameter.Value)
                            )
                        );
                    }
                }
            }
        }
    }

    public IEnumerable<ClientActionDelegate> CreateSetPropertyDelegates<T>(T clientObject, IReadOnlyDictionary<string, object?> parameters)
        where T : ClientObject
    {
        var objectName = clientObject.ObjectType;
        _ = objectName ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var objectType = ClientObject.GetType(objectName);
        return this.CreateSetPropertyDelegates(objectType, parameters);
    }

    public long GetActionId<T>() where T : ClientAction
    {
        return this
            .Actions.OfType<T>()
            .Select(action => action.Id)
            .LastOrDefault();
    }

    public IEnumerable<long> GetActionIds<T>() where T : ClientAction
    {
        return this
            .Actions.OfType<T>()
            .Select(action => action.Id)
            .ToArray();
    }

}
