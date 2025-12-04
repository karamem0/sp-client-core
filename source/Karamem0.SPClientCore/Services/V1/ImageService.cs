//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.Common;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IImageService
{

    ImageItem? UploadObject(
        List listObject,
        string fileName,
        System.IO.Stream fileContent
    );

    ImageItem? UploadObject(
        ListItem listItemObject,
        string fileName,
        System.IO.Stream fileContent
    );

}

public class ImageService(ClientContext clientContext) : ClientService(clientContext), IImageService
{

    public ImageItem? UploadObject(
        List listObject,
        string fileName,
        System.IO.Stream fileContent
    )
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/web/uploadimage(listtitle=@v1,imagename=@v2,listid=@v3,itemid=@v4)")
            .ConcatQuery(
                UriQuery.Create(
                    new Dictionary<string, object?>()
                    {
                        ["@v1"] = listObject.Title,
                        ["@v2"] = fileName,
                        ["@v3"] = listObject.Id,
                        ["@v4"] = 0
                    },
                    true
                )
            );
        var returnValue = this.ClientContext.PostStream<ODataV1MethodReturnValue>(requestUrl, fileContent);
        _ = returnValue ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return returnValue.GetValue<ImageItem>("UploadImage");
    }

    public ImageItem? UploadObject(
        ListItem listItemObject,
        string fileName,
        System.IO.Stream fileContent
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(
            ObjectPathProperty.Create(objectPath1.Id, "ParentList"),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(List)))
        );
        var listObject = this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<List>(requestPayload.GetActionId<ClientActionQuery>());
        _ = listObject ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/web/uploadimage(listtitle=@v1,imagename=@v2,listid=@v3,itemid=@v4)")
            .ConcatQuery(
                UriQuery.Create(
                    new Dictionary<string, object?>()
                    {
                        ["@v1"] = listObject.Title,
                        ["@v2"] = fileName,
                        ["@v3"] = listObject.Id,
                        ["@v4"] = listItemObject.Id
                    },
                    true
                )
            );
        var returnValue = this.ClientContext.PostStream<ODataV1MethodReturnValue>(requestUrl, fileContent);
        _ = returnValue ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        return returnValue.GetValue<ImageItem>("UploadImage");
    }

}
