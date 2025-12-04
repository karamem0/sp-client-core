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
public class GetTermCommandTests
{

    [Test()]
    public void InvokeCommand_GetAllFromTermSet_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0]
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByIdentityFromTermSet_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermId"] = context.AppSettings["Term1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["Identity"] = result3[0]
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByTermLabelFromTermSet_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermId"] = context.AppSettings["Term1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<TermLabel>(
            "Get-KshTermLabel",
            new Dictionary<string, object>()
            {
                ["Term"] = result3[0],
                ["LabelName"] = context.AppSettings["Term1Name"]
            }
        );
        var result5 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermLabel"] = result4[0]
            }
        );
        var actual = result5[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByTermIdFromTermSet_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermId"] = context.AppSettings["Term1Id"],
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByTermNameFromTermSet_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermName"] = context.AppSettings["Term1Name"],
            }
        );
        var actual = result3[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetAllFromTerm_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0]
            }
        );
        var actual = result3.ToArray();
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByIdentityFromTerm_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermId"] = context.AppSettings["Term1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["Term"] = result3[0],
                ["TermId"] = context.AppSettings["Term2Id"]
            }
        );
        var result5 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["Identity"] = result4[0]
            }
        );
        var actual = result5[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByTermLabelFromTerm_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermId"] = context.AppSettings["Term1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["Term"] = result3[0],
                ["TermId"] = context.AppSettings["Term2Id"]
            }
        );
        var result5 = context.Runspace.InvokeCommand<TermLabel>(
            "Get-KshTermLabel",
            new Dictionary<string, object>()
            {
                ["Term"] = result4[0],
                ["LabelName"] = context.AppSettings["Term2Name"]
            }
        );
        var result6 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermLabel"] = result5[0]
            }
        );
        var actual = result6[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByTermIdFromTerm_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermId"] = context.AppSettings["Term1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["Term"] = result3[0],
                ["TermId"] = context.AppSettings["Term2Id"],
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

    [Test()]
    public void InvokeCommand_GetByTermNameFromTerm_ShouldSucceed()
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
        var result1 = context.Runspace.InvokeCommand<TermGroup>(
            "Get-KshTermGroup",
            new Dictionary<string, object>()
            {
                ["TermGroupId"] = context.AppSettings["TermGroup1Id"]
            }
        );
        var result2 = context.Runspace.InvokeCommand<TermSet>(
            "Get-KshTermSet",
            new Dictionary<string, object>()
            {
                ["TermGroup"] = result1[0],
                ["TermSetId"] = context.AppSettings["TermSet1Id"]
            }
        );
        var result3 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["TermSet"] = result2[0],
                ["TermId"] = context.AppSettings["Term1Id"]
            }
        );
        var result4 = context.Runspace.InvokeCommand<Term>(
            "Get-KshTerm",
            new Dictionary<string, object>()
            {
                ["Term"] = result3[0],
                ["TermName"] = context.AppSettings["Term2Name"],
            }
        );
        var actual = result4[0];
        Assert.That(actual, Is.Not.Null);
    }

}
