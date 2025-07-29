//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IViewService
{

    View? AddObject(List listObject, IReadOnlyDictionary<string, object?> creationInfo);

    View? GetObject(View viewObject);

    string? CopyObject(
        List listObject,
        View viewObject,
        string newName,
        bool personalView,
        string? url
    );

    View? GetObject(List listObject, Guid viewId);

    View? GetObject(List listObject, string viewTitle);

    IEnumerable<View>? GetObjectEnumerable(List listObject);

    void RemoveObject(View viewObject);

    void SetObject(View viewObject, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class ViewService(ClientContext clientContext) : ClientService<View>(clientContext), IViewService
{

    public View? AddObject(List listObject, IReadOnlyDictionary<string, object?> creationInfo)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Views"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "Add",
                requestPayload.CreateParameter(ClientValueObject.Create<ViewCreationInfo>(creationInfo))
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(View)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public string? CopyObject(
        List listObject,
        View viewObject,
        string newName,
        bool personalView,
        string? url
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            objectPath1,
            objectPath => ClientActionMethod.Create(
                objectPath,
                "SaveAsNewView",
                requestPayload.CreateParameter(viewObject.Id),
                requestPayload.CreateParameter(newName),
                requestPayload.CreateParameter(personalView),
                requestPayload.CreateParameter(url)
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<string>(requestPayload.GetActionId<ClientActionMethod>());
    }

    public View? GetObject(List listObject, Guid viewId)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Views"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetById",
                requestPayload.CreateParameter(viewId)
            ),
            ClientActionInstantiateObjectPath.Create
        );
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(View))));
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public View? GetObject(List listObject, string viewTitle)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Views"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "GetByTitle",
                requestPayload.CreateParameter(viewTitle)
            ),
            ClientActionInstantiateObjectPath.Create
        );
        var objectPath4 = requestPayload.Add(objectPath3, objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(View))));
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<View>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public IEnumerable<View>? GetObjectEnumerable(List listObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "Views"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(
                objectPathId,
                ClientQuery.Empty,
                ClientQuery.Create(true, typeof(View))
            )
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ViewEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
    }

}
