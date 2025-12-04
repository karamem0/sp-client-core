//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Test.Utility;
using NUnit.Framework;

namespace Karamem0.SharePoint.PowerShell.Commands.Test;

[Category("Karamem0.SharePoint.PowerShell.Commands")]
public class SaveAttachmentFileCommandTests
{

    [Test()]
    public void InvokeCommand_SaveItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<List>(
            "Get-KshList",
            new Dictionary<string, object>()
            {
                ["ListId"] = context.AppSettings["List1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<ListItem>(
            "Get-KshListItem",
            new Dictionary<string, object>()
            {
                ["List"] = result1[0],
                ["ItemId"] = context.AppSettings["ListItem1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<AttachmentFile>(
            "Save-KshAttachmentFile",
            new Dictionary<string, object>()
            {
                ["ListItem"] = result2[0],
                ["Content"] = new System.IO.MemoryStream(Encoding.UTF8.GetBytes("TestFile0")),
                ["FileName"] = "TestFile0.txt",
                ["PassThru"] = true
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshAttachmentFile",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
    }

}
