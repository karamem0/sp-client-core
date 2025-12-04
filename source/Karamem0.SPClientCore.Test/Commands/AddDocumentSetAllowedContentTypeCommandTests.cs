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
public class AddDocumentSetAllowedContentTypeCommandTests
{

    [Test()]
    public void InvokeCommand_AddItem_ShouldSucceed()
    {
        using var context = new PSCmdletContext();
        _ = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                ["Url"] = context.AppSettings["BaseUrl"],
                ["ClientId"] = context.AppSettings["ClientId"],
                ["CertificatePath"] = context.AppSettings["CertificatePath"],
                ["PrivateKeyPath"] = context.AppSettings["PrivateKeyPath"]
            }
        );
        var result1 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                ["ContentTypeId"] = "0x0120D520"
            }
        );
        var result2 = context.Runspace.InvokeCommand<ContentType>(
            "Add-KshContentType",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result1[0],
                ["Description"] = "Test Content Type 0 Description",
                ["Group"] = "Test Content Type 0 Group",
                ["Name"] = "Test Content Type 0"
            }
        );
        var result3 = context.Runspace.InvokeCommand<ContentType>(
            "Get-KshContentType",
            new Dictionary<string, object>()
            {
                ["ContentTypeId"] = "0x0101009D1CB255DA76424F860D91F20E6C4118"
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Add-KshDocumentSetAllowedContentType",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0],
                ["AllowedContentType"] = result3[0],
                ["PushChanges"] = true
            }
        );
        var result4 = context.Runspace.InvokeCommand<ContentTypeId>(
            "Get-KshDocumentSetAllowedContentType",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshDocumentSetAllowedContentType",
            new Dictionary<string, object>()
            {
                ["ContentType"] = result2[0],
                ["AllowedContentType"] = result3[0]
            }
        );
        _ = context.Runspace.InvokeCommand(
            "Remove-KshContentType",
            new Dictionary<string, object>()
            {
                ["Identity"] = result2[0]
            }
        );
        var actual = result4.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

}
