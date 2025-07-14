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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IFolderColoringService
{

    void AddObject(
        Uri folderUrl,
        string folderName,
        bool overwrite,
        IReadOnlyDictionary<string, object?> creationInfo
    );

    void SetObject(Uri folderUrl, IReadOnlyDictionary<string, object?> modificationInfo);

}

public class FolderColoringService(ClientContext clientContext) : ClientService(clientContext), IFolderColoringService
{

    public void AddObject(
        Uri folderUrl,
        string folderName,
        bool overwrite,
        IReadOnlyDictionary<string, object?> creationInfo
    )
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/foldercoloring/createfolder(decodedurl=@v1,overwrite=@v2)")
            .ConcatQuery(
                UriQuery.Create(
                    new Dictionary<string, object?>()
                    {
                        ["@v1"] = folderUrl.ConcatPath(folderName),
                        ["@v2"] = overwrite,
                    },
                    true
                )
            );
        var requestPayload = FolderColoringInfoRequestPayload.Create(creationInfo);
        this.ClientContext.PostObject(requestUrl, requestPayload);
    }

    public void SetObject(Uri folderUrl, IReadOnlyDictionary<string, object?> modificationInfo)
    {
        var requestUrl = this
            .ClientContext.BaseAddress.ConcatPath("_api/foldercoloring/stampcolor(decodedurl=@v1)")
            .ConcatQuery(
                UriQuery.Create(
                    new Dictionary<string, object?>()
                    {
                        ["@v1"] = folderUrl
                    },
                    true
                )
            );
        var requestPayload = FolderColoringInfoRequestPayload.Create(modificationInfo);
        this.ClientContext.PostObject(requestUrl, requestPayload);
    }

}
