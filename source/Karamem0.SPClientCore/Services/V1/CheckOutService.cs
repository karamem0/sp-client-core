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

public interface ICheckOutService
{

    void CheckInObject(
        File fileObject,
        string? comment,
        CheckInType? checkInType
    );

    void CheckOutObject(File fileObject);

    void UndoCheckOutObject(File fileObject);

}

public class CheckOutService(ClientContext clientContext) : ClientService(clientContext), ICheckOutService
{

    public void CheckInObject(
        File fileObject,
        string? comment,
        CheckInType? checkInType
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "CheckIn",
                requestPayload.CreateParameter(comment),
                requestPayload.CreateParameter(checkInType ?? CheckInType.MinorCheckIn)
            )
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void CheckOutObject(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "CheckOut")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

    public void UndoCheckOutObject(File fileObject)
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(
            ObjectPathIdentity.Create(fileObject.ObjectIdentity),
            objectPathId => ClientActionMethod.Create(objectPathId, "UndoCheckOut")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
