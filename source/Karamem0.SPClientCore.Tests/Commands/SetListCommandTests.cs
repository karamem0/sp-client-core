//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Commands;

public class SetListCommandTests
{

    [Test()]
    public void SetList()
    {
        using var context = new PSCmdletContext();
        var result1 = context.Runspace.InvokeCommand(
            "Connect-KshSite",
            new Dictionary<string, object>()
            {
                { "Url", context.AppSettings["AuthorityUrl"] + context.AppSettings["Site1Url"] },
                { "Credential", PSCredentialFactory.CreateCredential(
                    context.AppSettings["LoginUserName"],
                    context.AppSettings["LoginPassword"])
                }
            }
        );
        var result2 = context.Runspace.InvokeCommand<List>(
            "Add-KshList",
            new Dictionary<string, object>()
            {
                { "ServerRelativeUrl", "TestList0" },
                { "Template", "DocumentLibrary" },
                { "Title", "Test List 0" }
            }
        );
        var result3 = context.Runspace.InvokeCommand<List>(
            "Set-KshList",
            new Dictionary<string, object>()
            {
                { "Identity", result2.ElementAt(0) },
                { "ContentTypesEnabled", true },
                { "DefaultContentApprovalWorkflowId", null },
                { "DefaultDisplayFormUrl", context.AppSettings["Site1Url"] + "/TestList0/Forms/DispForm.aspx" },
                { "DefaultEditFormUrl", context.AppSettings["Site1Url"] + "/TestList0/Forms/EditForm.aspx" },
                { "DefaultNewFormUrl", context.AppSettings["Site1Url"] + "/TestList0/Forms/Upload.aspx" },
                { "Description", "Test List 9 Description" },
                { "Direction", "none" },
                { "DisableCommenting", true },
                { "DisableGridEditing", true },
                { "DocumentTemplateUrl", context.AppSettings["Site1Url"] + "/TestList0/Forms/template.dotx" },
                { "DraftVersionVisibility", "Author" },
                { "EnableAttachments", false },
                { "EnableFolderCreation", true },
                { "EnableMinorVersions", true },
                { "EnableModeration", true },
                { "EnableVersioning", true },
                { "ForceCheckOut", true },
                { "Hidden", true },
                { "IrmEnabled", true },
                { "IrmExpire", true },
                { "IrmReject", true },
                { "IsApplicationList", true },
                { "LastItemModifiedDate", new DateTime(2017, 4, 1) },
                { "MultipleDataList", false },
                { "NoCrawl", true },
                { "OnQuickLaunch", true },
                { "Title", "Test List 9" },
                { "ValidationFormula", "=TRUE" },
                { "ValidationMessage", "Test List 9 Validation" },
                { "PassThru", true }
            }
        );
        var result4 = context.Runspace.InvokeCommand(
            "Remove-KshList",
            new Dictionary<string, object>()
            {
                { "Identity", result3.ElementAt(0) }
            }
        );
        var actual = result3.ElementAt(0);
        Assert.That(actual, Is.Not.Null);
    }

}
