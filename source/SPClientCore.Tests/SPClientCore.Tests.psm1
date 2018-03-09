#
# Copyright (c) 2018 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/SPClientCore/blob/master/LICENSE
#

function Install-TestSite
{

    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory = $true)]
        [ValidateSet("Server", "Online")]
        [string]
        $ServiceType,
        [Parameter(Mandatory = $true)]
        [string]
        $Url,
        [Parameter(Mandatory = $true)]
        [string]
        $UserName,
        [Parameter(Mandatory = $true)]
        [string]
        $Password,
        [Parameter(Mandatory = $true)]
        [string]
        $DomainName
    )

    process
    {
        $appSettings = [ordered]@{}

        $context = New-Object Microsoft.SharePoint.Client.ClientContext($Url)
        $credential = New-Object System.Net.NetworkCredential(($UserName + '@' + $DomainName), $Password)
        if ($ServiceType -eq 'Server')
        {
            $context.Credentials = $credential
        }
        if ($ServiceType -eq 'Online')
        {
            $context.Credentials = New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($credential.UserName, $credential.SecurePassword)
            $context.add_ExecutingWebRequest({ $_.WebRequestExecutor.WebRequest.UserAgent = "NONISV|karamem0|SPClientCore/1.0" })
        }
        $appSettings.ServiceType = $ServiceType
        $appSettings.LoginUrl = $Url
        $appSettings.LoginDomainName = $DomainName
        $appSettings.LoginUserName = $credential.UserName
        $appSettings.LoginPassword = $credential.Password

        $site = $context.Site
        $context.Load($site)
        $context.ExecuteQuery()
        $appSettings.SiteGuid = $site.Id
        $appSettings.SiteUrl = $site.ServerRelativeUrl

        $group1 = New-Object Microsoft.SharePoint.Client.GroupCreationInformation
        $group1.Title = 'Test Group 1'
        $group1.Description = 'Test Group 1'
        $group1 = $context.Web.SiteGroups.Add($group1)
        $group1.Owner = $group1
        $group1.Update()
        $context.Load($group1)
        $context.ExecuteQuery()
        $appSettings.Group1Id = $group1.Id
        $appSettings.Group1Name = $group1.Title

        $group2 = New-Object Microsoft.SharePoint.Client.GroupCreationInformation
        $group2.Title = 'Test Group 2'
        $group2.Description = 'Test Group 2'
        $group2 = $context.Web.SiteGroups.Add($group2)
        $group2.Owner = $group2
        $group2.Update()
        $context.Load($group2)
        $context.ExecuteQuery()
        $appSettings.Group2Id = $group2.Id
        $appSettings.Group2Name = $group2.Title

        $group3 = New-Object Microsoft.SharePoint.Client.GroupCreationInformation
        $group3.Title = 'Test Group 3'
        $group3.Description = 'Test Group 3'
        $group3 = $context.Web.SiteGroups.Add($group3)
        $group3.Owner = $group3
        $group3.Update()
        $context.Load($group3)
        $context.ExecuteQuery()
        $appSettings.Group3Id = $group3.Id
        $appSettings.Group3Name = $group3.Title

        if ($ServiceType -eq 'Server')
        {
            $user1 = New-Object Microsoft.SharePoint.Client.UserCreationInformation
            $user1.LoginName = 'i:0#.w|' + $DomainName.Split('.')[0].ToUpper() + '\testuser1'
            $user1.Title = 'Test User 1'
            $user1.Email = 'testuser1@' + $DomainName
            $user1 = $group1.Users.Add($user1)
            $user1.Update()
            $context.Load($user1)
            $context.ExecuteQuery()
            $appSettings.User1Id = $user1.Id
            $appSettings.User1LoginName = $user1.LoginName
            $appSettings.User1Title = $user1.Title
            $appSettings.User1Email = $user1.Email

            $user2 = New-Object Microsoft.SharePoint.Client.UserCreationInformation
            $user2.LoginName = 'i:0#.w|' + $DomainName.Split('.')[0].ToUpper() + '\testuser2'
            $user2.Title = 'Test User 2'
            $user2.Email = 'testuser2@' + $DomainName
            $user2 = $group1.Users.Add($user2)
            $user2.Update()
            $context.Load($user2)
            $context.ExecuteQuery()
            $appSettings.User2Id = $user2.Id
            $appSettings.User2LoginName = $user2.LoginName
            $appSettings.User2Title = $user2.Title
            $appSettings.User2Email = $user2.Email

            $user3 = New-Object Microsoft.SharePoint.Client.UserCreationInformation
            $user3.LoginName = 'i:0#.w|' + $DomainName.Split('.')[0].ToUpper() + '\testuser3'
            $user3.Title = 'Test User 3'
            $user3.Email = 'testuser3@' + $DomainName
            $user3 = $group1.Users.Add($user3)
            $user3.Update()
            $context.Load($user3)
            $context.ExecuteQuery()
            $appSettings.User3Id = $user3.Id
            $appSettings.User3LoginName = $user3.LoginName
            $appSettings.User3Title = $user3.Title
            $appSettings.User3Email = $user3.Email
        }

        if ($ServiceType -eq 'Online')
        {
            $user1 = New-Object Microsoft.SharePoint.Client.UserCreationInformation
            $user1.LoginName = 'i:0#.f|membership|testuser1@' + $DomainName
            $user1.Title = 'Test User 1'
            $user1.Email = 'testuser1@' + $DomainName
            $user1 = $group1.Users.Add($user1)
            $user1.Update()
            $context.Load($user1)
            $context.ExecuteQuery()
            $appSettings.User1Id = $user1.Id
            $appSettings.User1LoginName = $user1.LoginName
            $appSettings.User1Title = $user1.Title
            $appSettings.User1Email = $user1.Email

            $user2 = New-Object Microsoft.SharePoint.Client.UserCreationInformation
            $user2.LoginName = 'i:0#.f|membership|testuser2@' + $DomainName
            $user2.Title = 'Test User 2'
            $user2.Email = 'testuser2@' + $DomainName
            $user2 = $group1.Users.Add($user2)
            $user2.Update()
            $context.Load($user2)
            $context.ExecuteQuery()
            $appSettings.User2Id = $user2.Id
            $appSettings.User2LoginName = $user2.LoginName
            $appSettings.User2Title = $user2.Title
            $appSettings.User2Email = $user2.Email

            $user3 = New-Object Microsoft.SharePoint.Client.UserCreationInformation
            $user3.LoginName = 'i:0#.f|membership|testuser3@' + $DomainName
            $user3.Title = 'Test User 3'
            $user3.Email = 'testuser3@' + $DomainName
            $user3 = $group1.Users.Add($user3)
            $user3.Update()
            $context.Load($user3)
            $context.ExecuteQuery()
            $appSettings.User3Id = $user3.Id
            $appSettings.User3LoginName = $user3.LoginName
            $appSettings.User3Title = $user3.Title
            $appSettings.User3Email = $user3.Email
        }

        $roleDefinition1 = New-Object Microsoft.SharePoint.Client.RoleDefinitionCreationInformation
        $roleDefinition1.Name = 'Test Role Definition 1'
        $roleDefinition1.Description = ''
        $roleDefinition1.BasePermissions = New-Object Microsoft.SharePoint.Client.BasePermissions
        $roleDefinition1 = $context.Web.RoleDefinitions.Add($roleDefinition1)
        $context.Load($roleDefinition1)
        $context.ExecuteQuery()
        $appSettings.RoleDefinition1Id = $RoleDefinition1.Id
        $appSettings.RoleDefinition1Name = $RoleDefinition1.Name

        $roleDefinition2 = New-Object Microsoft.SharePoint.Client.RoleDefinitionCreationInformation
        $roleDefinition2.Name = 'Test Role Definition 2'
        $roleDefinition2.Description = ''
        $roleDefinition2.BasePermissions = New-Object Microsoft.SharePoint.Client.BasePermissions
        $roleDefinition2 = $context.Web.RoleDefinitions.Add($roleDefinition2)
        $context.Load($roleDefinition2)
        $context.ExecuteQuery()
        $appSettings.RoleDefinition2Id = $RoleDefinition2.Id
        $appSettings.RoleDefinition2Name = $RoleDefinition2.Name

        $roleDefinition3 = New-Object Microsoft.SharePoint.Client.RoleDefinitionCreationInformation
        $roleDefinition3.Name = 'Test Role Definition 3'
        $roleDefinition3.Description = ''
        $roleDefinition3.BasePermissions = New-Object Microsoft.SharePoint.Client.BasePermissions
        $roleDefinition3 = $context.Web.RoleDefinitions.Add($roleDefinition3)
        $context.Load($roleDefinition3)
        $context.ExecuteQuery()
        $appSettings.RoleDefinition3Id = $RoleDefinition3.Id
        $appSettings.RoleDefinition3Name = $RoleDefinition3.Name

        $web1 = New-Object Microsoft.SharePoint.Client.WebCreationInformation
        $web1.Url = 'TestWeb1'
        $web1.Language = '1033'
        $web1.WebTemplate = 'STS#0'
        $web1.Title = 'Test Web 1'
        $web1.Description = 'Test Web 1 Description'
        $web1.UseSamePermissionsAsParentSite = $false
        $web1 = $context.Web.Webs.Add($web1)
        $web1.Update()
        $web1.BreakRoleInheritance($false, $false)
        $context.Load($web1)
        $context.ExecuteQuery()
        $appSettings.Web1Id = $web1.Id
        $appSettings.Web1Url = $web1.ServerRelativeUrl
        $appSettings.Web1Title = $web1.Title

        $webRoleDefinition1 = $web1.RoleDefinitions.GetByName('Test Role Definition 1')
        $webRoleDefinitionBindings1 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $webRoleDefinitionBindings1.Add($webRoleDefinition1)
        $webRoleAssignment1 = $web1.RoleAssignments.Add($group1, $webRoleDefinitionBindings1)
        $context.Load($webRoleAssignment1)
        $context.ExecuteQuery()
        $appSettings.WebRoleAssignment1Id = $webRoleAssignment1.PrincipalId

        $webRoleDefinition2 = $web1.RoleDefinitions.GetByName('Test Role Definition 2')
        $webRoleDefinitionBindings2 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $webRoleDefinitionBindings2.Add($webRoleDefinition2)
        $webRoleAssignment2 = $web1.RoleAssignments.Add($group2, $webRoleDefinitionBindings2)
        $context.Load($webRoleAssignment2)
        $context.ExecuteQuery()
        $appSettings.WebRoleAssignment2Id = $webRoleAssignment2.PrincipalId

        $webRoleDefinition3 = $web1.RoleDefinitions.GetByName('Test Role Definition 3')
        $webRoleDefinitionBindings3 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $webRoleDefinitionBindings3.Add($webRoleDefinition3)
        $webRoleAssignment3 = $web1.RoleAssignments.Add($group3, $webRoleDefinitionBindings3)
        $context.Load($webRoleAssignment3)
        $context.ExecuteQuery()
        $appSettings.WebRoleAssignment3Id = $webRoleAssignment3.PrincipalId

        $web2 = New-Object Microsoft.SharePoint.Client.WebCreationInformation
        $web2.Url = 'TestWeb2'
        $web2.Language = '1033'
        $web2.WebTemplate = 'STS#0'
        $web2.Title = 'Test Web 2'
        $web2.Description = 'Test Web 2 Description'
        $web2.UseSamePermissionsAsParentSite = $false
        $web2 = $web1.Webs.Add($web2)
        $web2.Update()
        $web2.BreakRoleInheritance($false, $false)
        $context.Load($web2)
        $context.ExecuteQuery()
        $appSettings.Web2Id = $web2.Id
        $appSettings.Web2Url = $web2.ServerRelativeUrl
        $appSettings.Web2Title = $web2.Title

        $web3 = New-Object Microsoft.SharePoint.Client.WebCreationInformation
        $web3.Url = 'TestWeb3'
        $web3.Language = '1033'
        $web3.WebTemplate = 'STS#0'
        $web3.Title = 'Test Web 3'
        $web3.Description = 'Test Web 3 Description'
        $web3.UseSamePermissionsAsParentSite = $false
        $web3 = $web2.Webs.Add($web3)
        $web3.Update()
        $web3.BreakRoleInheritance($false, $false)
        $context.Load($web3)
        $context.ExecuteQuery()
        $appSettings.Web3Id = $web3.Id
        $appSettings.Web3Url = $web3.ServerRelativeUrl
        $appSettings.Web3Title = $web3.Title

        $web4 = New-Object Microsoft.SharePoint.Client.WebCreationInformation
        $web4.Url = 'TestWeb4'
        $web4.Language = '1033'
        $web4.WebTemplate = 'STS#0'
        $web4.Title = 'Test Web 4'
        $web4.Description = 'Test Web 4 Description'
        $web4.UseSamePermissionsAsParentSite = $false
        $web4 = $web1.Webs.Add($web4)
        $web4.Update()
        $web4.BreakRoleInheritance($false, $false)
        $context.Load($web4)
        $context.ExecuteQuery()
        $appSettings.Web4Id = $web4.Id
        $appSettings.Web4Url = $web4.ServerRelativeUrl
        $appSettings.Web4Title = $web4.Title

        $list1 = New-Object Microsoft.SharePoint.Client.ListCreationInformation
        $list1.Title = 'TestList1'
        $list1.Description = ''
        $list1.TemplateType = 100
        $list1 = $web1.Lists.Add($list1)
        $list1.ContentTypesEnabled = $true
        $list1.Title = 'Test List 1'
        $list1.BreakRoleInheritance($false, $false)
        $list1.Update()
        $context.Load($list1)
        $context.Load($list1.RootFolder)
        $context.ExecuteQuery()
        $appSettings.List1Id = $list1.Id
        $appSettings.List1Url = $list1.RootFolder.ServerRelativeUrl
        $appSettings.List1Title = $list1.Title

        $listRoleDefinition1 = $web1.RoleDefinitions.GetByName('Test Role Definition 1')
        $listRoleDefinitionBindings1 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $listRoleDefinitionBindings1.Add($listRoleDefinition1)
        $listRoleAssignment1 = $list1.RoleAssignments.Add($group1, $listRoleDefinitionBindings1)
        $context.Load($listRoleAssignment1)
        $context.ExecuteQuery()
        $appSettings.ListRoleAssignment1Id = $listRoleAssignment1.PrincipalId

        $listRoleDefinition2 = $web1.RoleDefinitions.GetByName('Test Role Definition 2')
        $listRoleDefinitionBindings2 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $listRoleDefinitionBindings2.Add($listRoleDefinition2)
        $listRoleAssignment2 = $list1.RoleAssignments.Add($group2, $listRoleDefinitionBindings2)
        $context.Load($listRoleAssignment2)
        $context.ExecuteQuery()
        $appSettings.ListRoleAssignment2Id = $listRoleAssignment2.PrincipalId

        $listRoleDefinition3 = $web1.RoleDefinitions.GetByName('Test Role Definition 3')
        $listRoleDefinitionBindings3 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $listRoleDefinitionBindings3.Add($listRoleDefinition3)
        $listRoleAssignment3 = $list1.RoleAssignments.Add($group3, $listRoleDefinitionBindings3)
        $context.Load($listRoleAssignment3)
        $context.ExecuteQuery()
        $appSettings.ListRoleAssignment3Id = $listRoleAssignment3.PrincipalId

        $list2 = New-Object Microsoft.SharePoint.Client.ListCreationInformation
        $list2.Title = 'TestList2'
        $list2.Description = ''
        $list2.TemplateType = 101
        $list2 = $web1.Lists.Add($list2)
        $list2.ContentTypesEnabled = $true
        $list2.EnableVersioning = $true
        $list2.Title = 'Test List 2'
        $list2.Update()
        $context.Load($list2)
        $context.Load($list2.RootFolder)
        $context.ExecuteQuery()
        $appSettings.List2Id = $list2.Id
        $appSettings.List2Url = $list2.RootFolder.ServerRelativeUrl
        $appSettings.List2Title = $list2.Title

        $contentType1 = New-Object Microsoft.SharePoint.Client.ContentTypeCreationInformation
        $contentType1.Name = 'Test Content Type 1'
        $contentType1 = $web1.ContentTypes.Add($contentType1)
        $contentType1.Update($false)
        $context.Load($contentType1)
        $context.ExecuteQuery()
        $appSettings.WebContentType1Id = $contentType1.StringId

        $contentType2 = New-Object Microsoft.SharePoint.Client.ContentTypeCreationInformation
        $contentType2.Name = 'Test Content Type 2'
        $contentType2 = $web1.ContentTypes.Add($contentType2)
        $contentType2.Update($false)
        $context.Load($contentType2)
        $context.ExecuteQuery()
        $appSettings.WebContentType2Id = $contentType2.StringId

        $xml = '<Field Name="TestField1" DisplayName="Test Field 1" Type="Text" />'
        $field1 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field1.Update()
        $context.Load($field1)
        $context.ExecuteQuery()
        $appSettings.Field1Id = $field1.Id
        $appSettings.Field1Name = $field1.InternalName
        $appSettings.Field1Title = $field1.Title

        $xml = '<Field Name="TestField2" DisplayName="Test Field 2" Type="Note" />'
        $field2 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field2.Update()
        $context.Load($field2)
        $context.ExecuteQuery()
        $appSettings.Field2Id = $field2.Id
        $appSettings.Field2Name = $field2.InternalName
        $appSettings.Field2Title = $field2.Title

        $xml = '<Field Name="TestField3" DisplayName="Test Field 3" Type="Choice">' + `
            '<CHOICES>' + `
            '<CHOICE>Test Value 1</CHOICE>' + `
            '<CHOICE>Test Value 2</CHOICE>' + `
            '<CHOICE>Test Value 3</CHOICE>' + `
            '</CHOICES>' + `
            '</Field>'
        $field3 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field3.Update()
        $context.Load($field3)
        $context.ExecuteQuery()
        $appSettings.Field3Id = $field3.Id
        $appSettings.Field3Name = $field3.InternalName
        $appSettings.Field3Title = $field3.Title
        
        $xml = '<Field Name="TestField4" DisplayName="Test Field 4" Type="MultiChoice" Mult="TRUE">' + `
            '<CHOICES>' + `
            '<CHOICE>Test Value 1</CHOICE>' + `
            '<CHOICE>Test Value 2</CHOICE>' + `
            '<CHOICE>Test Value 3</CHOICE>' + `
            '</CHOICES>' + `
            '</Field>'
        $field4 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field4.Update()
        $context.Load($field4)
        $context.ExecuteQuery()
        $appSettings.Field4Id = $field4.Id
        $appSettings.Field4Name = $field4.InternalName
        $appSettings.Field4Title = $field4.Title

        $xml = '<Field Name="TestField5" DisplayName="Test Field 5" Type="Number" />'
        $field5 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field5.Update()
        $context.Load($field5)
        $context.ExecuteQuery()
        $appSettings.Field5Id = $field5.Id
        $appSettings.Field5Name = $field5.InternalName
        $appSettings.FieldTitle = $field5.Title

        $xml = '<Field Name="TestField6" DisplayName="Test Field 6" Type="Currency" />'
        $field6 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field6.Update()
        $context.Load($field6)
        $context.ExecuteQuery()
        $appSettings.Field6Id = $field6.Id
        $appSettings.Field6Name = $field6.InternalName
        $appSettings.Field6Title = $field6.Title

        $xml = '<Field Name="TestField7" DisplayName="Test Field 7" Type="DateTime" />'
        $field7 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field7.Update()
        $context.Load($field7)
        $context.ExecuteQuery()
        $appSettings.Field7Id = $field7.Id
        $appSettings.Field7Name = $field7.InternalName
        $appSettings.Field7Title = $field7.Title

        $xml = '<Field Name="TestField8" DisplayName="Test Field 8" Type="Lookup" List="' + $list1.Id.ToString('B') + '" ShowField="Title" />'
        $field8 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field8.Update()
        $context.Load($field8)
        $context.ExecuteQuery()
        $appSettings.Field8Id = $field8.Id
        $appSettings.Field8Name = $field8.InternalName
        $appSettings.Field8Title = $field8.Title

        $xml = '<Field Name="TestField9" DisplayName="Test Field 9" Type="LookupMulti" Mult="TRUE" List="' + $list1.Id.ToString('B') + '" ShowField="Title" />'
        $field9 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field9.Update()
        $context.Load($field9)
        $context.ExecuteQuery()
        $appSettings.Field9Id = $field9.Id
        $appSettings.Field9Name = $field9.InternalName
        $appSettings.Field9Title = $field9.Title

        $xml = '<Field Name="TestField10" DisplayName="Test Field 10" Type="Boolean" />'
        $field10 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field10.Update()
        $context.Load($field10)
        $context.ExecuteQuery()
        $appSettings.Field10Id = $field10.Id
        $appSettings.Field10Name = $field10.InternalName
        $appSettings.Field10Title = $field10.Title

        $xml = '<Field Name="TestField11" DisplayName="Test Field 11" Type="User" />'
        $field11 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field11.Update()
        $context.Load($field11)
        $context.ExecuteQuery()
        $appSettings.Field11Id = $field11.Id
        $appSettings.Field11Name = $field11.InternalName
        $appSettings.Field11Title = $field11.Title

        $xml = '<Field Name="TestField12" DisplayName="Test Field 12" Type="UserMulti" Mult="TRUE" />'
        $field12 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field12.Update()
        $context.Load($field12)
        $context.ExecuteQuery()
        $appSettings.Field12Id = $field12.Id
        $appSettings.Field12Name = $field12.InternalName
        $appSettings.Field12Title = $field12.Title

        $xml = '<Field Name="TestField13" DisplayName="Test Field 13" Type="URL" />'
        $field13 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field13.Update()
        $context.Load($field13)
        $context.ExecuteQuery()
        $appSettings.Field13Id = $field13.Id
        $appSettings.Field13Name = $field13.InternalName
        $appSettings.Field13Title = $field13.Title

        $xml = '<Field Name="TestField14" DisplayName="Test Field 14" Type="Calculated" ResultType="Text">' + `
            '<Formula>=[Title]</Formula>' + `
            '<FieldRefs>' + `
            '<FieldRef Name="Title" />' + `
            '</FieldRefs>' + `
            '</Field>'
        $field14 = $web1.Fields.AddFieldAsXml($xml, $true, 8)
        $field14.Update()
        $context.Load($field14)
        $context.ExecuteQuery()
        $appSettings.Field14Id = $field14.Id
        $appSettings.Field14Name = $field14.InternalName
        $appSettings.Field14Title = $field14.Title

        $fieldLink1 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink1.Field = $field1
        $fieldLink1 = $contentType1.FieldLinks.Add($fieldLink1)
        $contentType1.Update($false)
        $context.Load($fieldLink1)
        $context.ExecuteQuery()

        $fieldLink2 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink2.Field = $field2
        $fieldLink2 = $contentType1.FieldLinks.Add($fieldLink2)
        $contentType1.Update($false)
        $context.Load($fieldLink2)
        $context.ExecuteQuery()

        $fieldLink3 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink3.Field = $field3
        $fieldLink3 = $contentType1.FieldLinks.Add($fieldLink3)
        $contentType1.Update($false)
        $context.Load($fieldLink3)
        $context.ExecuteQuery()
        
        $fieldLink4 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink4.Field = $field4
        $fieldLink4 = $contentType1.FieldLinks.Add($fieldLink4)
        $contentType1.Update($false)
        $context.Load($fieldLink4)
        $context.ExecuteQuery()

        $fieldLink5 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink5.Field = $field5
        $fieldLink5 = $contentType1.FieldLinks.Add($fieldLink5)
        $contentType1.Update($false)
        $context.Load($fieldLink5)
        $context.ExecuteQuery()

        $fieldLink6 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink6.Field = $field6
        $fieldLink6 = $contentType1.FieldLinks.Add($fieldLink6)
        $contentType1.Update($false)
        $context.Load($fieldLink6)
        $context.ExecuteQuery()

        $fieldLink7 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink7.Field = $field7
        $fieldLink7 = $contentType1.FieldLinks.Add($fieldLink7)
        $contentType1.Update($false)
        $context.Load($fieldLink7)
        $context.ExecuteQuery()

        $fieldLink8 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink8.Field = $field8
        $fieldLink8 = $contentType1.FieldLinks.Add($fieldLink8)
        $contentType1.Update($false)
        $context.Load($fieldLink8)
        $context.ExecuteQuery()

        $fieldLink9 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink9.Field = $field9
        $fieldLink9 = $contentType1.FieldLinks.Add($fieldLink9)
        $contentType1.Update($false)
        $context.Load($fieldLink9)
        $context.ExecuteQuery()

        $fieldLink10 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink10.Field = $field10
        $fieldLink10 = $contentType1.FieldLinks.Add($fieldLink10)
        $contentType1.Update($false)
        $context.Load($fieldLink10)
        $context.ExecuteQuery()

        $fieldLink11 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink11.Field = $field11
        $fieldLink11 = $contentType1.FieldLinks.Add($fieldLink11)
        $contentType1.Update($false)
        $context.Load($fieldLink11)
        $context.ExecuteQuery()

        $fieldLink12 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink12.Field = $field12
        $fieldLink12 = $contentType1.FieldLinks.Add($fieldLink12)
        $contentType1.Update($false)
        $context.Load($fieldLink12)
        $context.ExecuteQuery()

        $fieldLink13 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink13.Field = $field13
        $fieldLink13 = $contentType1.FieldLinks.Add($fieldLink13)
        $contentType1.Update($false)
        $context.Load($fieldLink13)
        $context.ExecuteQuery()

        $fieldLink14 = New-Object Microsoft.SharePoint.Client.FieldLinkCreationInformation
        $fieldLink14.Field = $field14
        $fieldLink14 = $contentType1.FieldLinks.Add($fieldLink14)
        $contentType1.Update($false)
        $context.Load($fieldLink14)
        $context.ExecuteQuery()

        $contentType1 = $list1.ContentTypes.AddExistingContentType($contentType1)
        $contentType1.Update($false)
        $context.Load($contentType1)
        $context.ExecuteQuery()
        $appSettings.ListContentType1Id = $contentType1.StringId

        $contentType2 = $list2.ContentTypes.AddExistingContentType($contentType2)
        $contentType2.Update($false)
        $context.Load($contentType2)
        $context.ExecuteQuery()
        $appSettings.ListContentType2Id = $contentType2.StringId

        $view1 = New-Object Microsoft.SharePoint.Client.ViewCreationInformation
        $view1.Title = 'TestView1'
        $view1.ViewFields = @(
            'Test Field 1'
            'Test Field 2'
            'Test Field 3'
            'Test Field 4'
            'Test Field 5'
            'Test Field 6'
            'Test Field 7'
            'Test Field 8'
            'Test Field 9'
            'Test Field 10'
            'Test Field 11'
            'Test Field 12'
            'Test Field 13'
            'Test Field 14'
        )
        $view1 = $list1.Views.Add($view1)
        $view1.Title = 'Test View 1'
        $view1.Update()
        $context.Load($view1)
        $context.ExecuteQuery()
        $appSettings.View1Id = $view1.Id
        $appSettings.View1Title = $view1.Title

        $view2 = New-Object Microsoft.SharePoint.Client.ViewCreationInformation
        $view2.Title = 'TestView2'
        $view2.ViewFields = @(
            'Test Field 1'
            'Test Field 2'
            'Test Field 3'
            'Test Field 4'
            'Test Field 5'
            'Test Field 6'
            'Test Field 7'
            'Test Field 8'
            'Test Field 9'
            'Test Field 10'
            'Test Field 11'
            'Test Field 12'
            'Test Field 13'
            'Test Field 14'
        )
        $view2 = $list1.Views.Add($view2)
        $view2.Title = 'Test View 2'
        $view2.Update()
        $context.Load($view2)
        $context.ExecuteQuery()
        $appSettings.View2Id = $view2.Id
        $appSettings.View2Title = $view2.Title

        $view3 = New-Object Microsoft.SharePoint.Client.ViewCreationInformation
        $view3.Title = 'TestView3'
        $view3.ViewFields = @(
            'Test Field 1'
            'Test Field 2'
            'Test Field 3'
            'Test Field 4'
            'Test Field 5'
            'Test Field 6'
            'Test Field 7'
            'Test Field 8'
            'Test Field 9'
            'Test Field 10'
            'Test Field 11'
            'Test Field 12'
            'Test Field 13'
            'Test Field 14'
        )
        $view3 = $list1.Views.Add($view3)
        $view3.Title = 'Test View 3'
        $view3.Update()
        $context.Load($view3)
        $context.ExecuteQuery()
        $appSettings.View3Id = $view3.Id
        $appSettings.View3Title = $view3.Title

        $userValue1 = New-Object Microsoft.SharePoint.Client.FieldUserValue
        $userValue1.LookupId = $user1.Id
        $userValue2 = New-Object Microsoft.SharePoint.Client.FieldUserValue
        $userValue2.LookupId = $user2.Id
        $userValue3 = New-Object Microsoft.SharePoint.Client.FieldUserValue
        $userValue3.LookupId = $user3.Id

        $item1 = New-Object Microsoft.SharePoint.Client.ListItemCreationInformation
        $item1 = $list1.AddItem($item1)
        $item1['Title'] = 'Test List Item 1'
        $item1['TestField1'] = 'Test Value 1'
        $item1['TestField2'] = 'Test Value 1'
        $item1['TestField3'] = 'Test Value 1'
        $item1['TestField4'] = 'Test Value 1'
        $item1['TestField5'] = 1
        $item1['TestField6'] = 1
        $item1['TestField7'] = [datetime]'10/10/2010'
        $item1['TestField10'] = $true
        $item1['TestField11'] = $user1.Id
        $item1['TestField12'] = [Microsoft.SharePoint.Client.FieldUserValue[]]@($userValue1)
        $item1['TestField13'] = 'http://www.example.com, Test Value 1'
        $item1.Update()
        $item1.BreakRoleInheritance($false, $false)
        $context.Load($item1)
        $context.ExecuteQuery()
        $appSettings.ListItem1Id = $item1.Id

        $itemRoleDefinition1 = $web1.RoleDefinitions.GetByName('Test Role Definition 1')
        $itemRoleDefinitionBindings1 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $itemRoleDefinitionBindings1.Add($itemRoleDefinition1)
        $itemRoleAssignment1 = $item1.RoleAssignments.Add($group1, $itemRoleDefinitionBindings1)
        $context.Load($itemRoleAssignment1)
        $context.ExecuteQuery()
        $appSettings.ListItemRoleAssignment1Id = $itemRoleAssignment1.PrincipalId

        $itemRoleDefinition2 = $web1.RoleDefinitions.GetByName('Test Role Definition 2')
        $itemRoleDefinitionBindings2 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $itemRoleDefinitionBindings2.Add($itemRoleDefinition2)
        $itemRoleAssignment2 = $item1.RoleAssignments.Add($group2, $itemRoleDefinitionBindings2)
        $context.Load($itemRoleAssignment2)
        $context.ExecuteQuery()
        $appSettings.ListItemRoleAssignment2Id = $itemRoleAssignment2.PrincipalId

        $itemRoleDefinition3 = $web1.RoleDefinitions.GetByName('Test Role Definition 3')
        $itemRoleDefinitionBindings3 = New-Object Microsoft.SharePoint.Client.RoleDefinitionBindingCollection($context)
        $itemRoleDefinitionBindings3.Add($itemRoleDefinition3)
        $itemRoleAssignment3 = $item1.RoleAssignments.Add($group3, $itemRoleDefinitionBindings3)
        $context.Load($itemRoleAssignment3)
        $context.ExecuteQuery()
        $appSettings.ListItemRoleAssignment3Id = $itemRoleAssignment3.PrincipalId

        $item2 = New-Object Microsoft.SharePoint.Client.ListItemCreationInformation
        $item2 = $list1.AddItem($item2)
        $item2['Title'] = 'Test List Item 2'
        $item2['TestField1'] = 'Test Value 2'
        $item2['TestField2'] = 'Test Value 2'
        $item2['TestField3'] = 'Test Value 2'
        $item2['TestField4'] = 'Test Value 2'
        $item2['TestField5'] = 2
        $item2['TestField6'] = 2
        $item2['TestField7'] = [datetime]'12/20/2016'
        $item2['TestField11'] = $user2.Id
        $item2['TestField12'] = [Microsoft.SharePoint.Client.FieldUserValue[]]@($userValue2)
        $item2['TestField10'] = $true
        $item2['TestField13'] = 'http://www.example.com, Test Value 2'
        $item2.Update()
        $context.Load($item2)
        $context.ExecuteQuery()
        $appSettings.ListItem2Id = $item2.Id

        $item3 = New-Object Microsoft.SharePoint.Client.ListItemCreationInformation
        $item3 = $list1.AddItem($item3)
        $item3['Title'] = 'Test List Item 3'
        $item3['TestField1'] = 'Test Value 3'
        $item3['TestField2'] = 'Test Value 3'
        $item3['TestField3'] = 'Test Value 3'
        $item3['TestField4'] = @('Test Value 1', 'Test Value 2', 'Test Value 3')
        $item3['TestField5'] = 3
        $item3['TestField6'] = 3
        $item3['TestField7'] = [datetime]'12/25/2017'
        $item3['TestField10'] = $true
        $item3['TestField11'] = $user3.Id
        $item3['TestField12'] = [Microsoft.SharePoint.Client.FieldUserValue[]]@($userValue1, $userValue2, $userValue3)
        $item3['TestField13'] = 'http://www.example.com, Test Value 3'
        $item3.Update()
        $context.Load($item3)
        $context.ExecuteQuery()
        $appSettings.ListItem3Id = $item3.Id

        $lookupValue1 = New-Object Microsoft.SharePoint.Client.FieldLookupValue
        $lookupValue1.LookupId = $item1.Id
        $lookupValue2 = New-Object Microsoft.SharePoint.Client.FieldLookupValue
        $lookupValue2.LookupId = $item2.Id
        $lookupValue3 = New-Object Microsoft.SharePoint.Client.FieldLookupValue
        $lookupValue3.LookupId = $item3.Id

        $item1['TestField8'] = $item1.Id
        $item1['TestField9'] = [Microsoft.SharePoint.Client.FieldLookupValue[]]@($lookupValue1)
        $item1.Update()
        $context.Load($item1)
        $context.ExecuteQuery()

        $item2['TestField8'] = $item2.Id
        $item2['TestField9'] = [Microsoft.SharePoint.Client.FieldLookupValue[]]@($lookupValue2)
        $item2.Update()
        $context.Load($item2)
        $context.ExecuteQuery()

        $item3['TestField8'] = $item3.Id
        $item3['TestField9'] = [Microsoft.SharePoint.Client.FieldLookupValue[]]@($lookupValue1, $lookupValue2, $lookupValue3)
        $item3.Update()
        $context.Load($item3)
        $context.ExecuteQuery()

        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile1')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachment1 = New-Object Microsoft.SharePoint.Client.AttachmentCreationInformation
        $attachment1.FileName = 'TestFile1.txt'
        $attachment1.ContentStream = $stream
        $attachment1 = $item1.AttachmentFiles.Add($attachment1)
        $context.Load($attachment1)
        $context.ExecuteQuery()
        $appSettings.Attachment1Name = $attachment1.FileName
        
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile2')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachment2 = New-Object Microsoft.SharePoint.Client.AttachmentCreationInformation
        $attachment2.FileName = 'TestFile2.txt'
        $attachment2.ContentStream = $stream
        $attachment2 = $item1.AttachmentFiles.Add($attachment2)
        $context.Load($attachment2)
        $context.ExecuteQuery()
        $appSettings.Attachment2Name = $attachment2.FileName

        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile3')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachment3 = New-Object Microsoft.SharePoint.Client.AttachmentCreationInformation
        $attachment3.FileName = 'TestFile3.txt'
        $attachment3.ContentStream = $stream
        $attachment3 = $item1.AttachmentFiles.Add($attachment3)
        $context.Load($attachment3)
        $context.ExecuteQuery()
        $appSettings.Attachment3Name = $attachment3.FileName

        $folder1 = $list2.RootFolder.Folders.Add('TestFolder1')
        $folder1.Update()
        $context.Load($folder1)
        $context.Load($folder1.ListItemAllFields)
        $context.ExecuteQuery()
        $appSettings.Folder1Url = $folder1.ServerRelativeUrl
        $appSettings.Folder1Id = $folder1.ListItemAllFields.Id

        $folder2 = $folder1.Folders.Add('TestFolder2')
        $folder2.Update()
        $context.Load($folder2)
        $context.Load($folder2.ListItemAllFields)
        $context.ExecuteQuery()
        $appSettings.Folder2Url = $folder2.ServerRelativeUrl
        $appSettings.Folder2Id = $folder2.ListItemAllFields.Id

        $folder3 = $folder1.Folders.Add('TestFolder3')
        $folder3.Update()
        $context.Load($folder3)
        $context.Load($folder3.ListItemAllFields)
        $context.ExecuteQuery()
        $appSettings.Folder3Url = $folder3.ServerRelativeUrl
        $appSettings.Folder3Id = $folder3.ListItemAllFields.Id

        $folder4 = $folder3.Folders.Add('TestFolder4')
        $folder4.Update()
        $context.Load($folder4)
        $context.Load($folder4.ListItemAllFields)
        $context.ExecuteQuery()
        $appSettings.Folder4Url = $folder4.ServerRelativeUrl
        $appSettings.Folder4Id = $folder4.ListItemAllFields.Id

        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile1')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file1 = New-Object Microsoft.SharePoint.Client.FileCreationInformation
        $file1.Url = 'TestFile1.txt'
        $file1.ContentStream = $stream
        $file1 = $folder1.Files.Add($file1)
        $context.Load($file1)
        $context.Load($file1.ListItemAllFields)
        $context.ExecuteQuery()
        $appSettings.File1Url = $file1.ServerRelativeUrl
        $appSettings.File1Id = $file1.ListItemAllFields.Id

        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile2')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file2 = New-Object Microsoft.SharePoint.Client.FileCreationInformation
        $file2.Url = 'TestFile2.txt'
        $file2.ContentStream = $stream
        $file2 = $folder1.Files.Add($file2)
        $context.Load($file2)
        $context.Load($file2.ListItemAllFields)
        $context.ExecuteQuery()
        $appSettings.File2Url = $file2.ServerRelativeUrl
        $appSettings.File2Id = $file2.ListItemAllFields.Id

        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile3')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file3 = New-Object Microsoft.SharePoint.Client.FileCreationInformation
        $file3.Url = 'TestFile3.txt'
        $file3.ContentStream = $stream
        $file3 = $folder1.Files.Add($file3)
        $context.Load($file3)
        $context.Load($file3.ListItemAllFields)
        $context.ExecuteQuery()
        $appSettings.File3Url = $file3.ServerRelativeUrl
        $appSettings.File3Id = $file3.ListItemAllFields.Id

        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile4')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file4 = New-Object Microsoft.SharePoint.Client.FileCreationInformation
        $file4.Url = 'TestFile4.txt'
        $file4.ContentStream = $stream
        $file4 = $folder4.Files.Add($file4)
        $context.Load($file4)
        $context.Load($file4.ListItemAllFields)
        $context.ExecuteQuery()
        $appSettings.File4Url = $file4.ServerRelativeUrl
        $appSettings.File4Id = $file4.ListItemAllFields.Id
        
        Write-Output $appSettings
    }

}

function Uninstall-TestSite
{

    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory = $true)]
        [ValidateSet("Server", "Online")]
        [string]
        $ServiceType,
        [Parameter(Mandatory = $true)]
        [string]
        $Url,
        [Parameter(Mandatory = $true)]
        [string]
        $UserName,
        [Parameter(Mandatory = $true)]
        [string]
        $Password,
        [Parameter(Mandatory = $true)]
        [string]
        $DomainName
    )

    process
    {
        trap { continue }

        $context = New-Object Microsoft.SharePoint.Client.ClientContext($Url)
        $credential = New-Object System.Net.NetworkCredential(($UserName + '@' + $DomainName), $Password)
        if ($ServiceType -eq 'Server')
        {
            $context.Credentials = $credential
        }
        if ($ServiceType -eq 'Online')
        {
            $context.Credentials = New-Object Microsoft.SharePoint.Client.SharePointOnlineCredentials($credential.UserName, $credential.SecurePassword)
            $context.add_ExecutingWebRequest({ $_.WebRequestExecutor.WebRequest.UserAgent = "NONISV|karamem0|SPClientCore/1.0" })
        }

        $site = $context.Site
        $context.Load($site)
        $context.ExecuteQuery()

        $web4 = $context.Site.OpenWeb($site.ServerRelativeUrl + '/TestWeb1/TestWeb4')
        $web4.DeleteObject()
        $context.ExecuteQuery()

        $web3 = $context.Site.OpenWeb($site.ServerRelativeUrl + '/TestWeb1/TestWeb2/TestWeb3')
        $web3.DeleteObject()
        $context.ExecuteQuery()

        $web2 = $context.Site.OpenWeb($site.ServerRelativeUrl + '/TestWeb1/TestWeb2')
        $web2.DeleteObject()
        $context.ExecuteQuery()

        $web1 = $context.Site.OpenWeb($site.ServerRelativeUrl + '/TestWeb1')
        $web1.DeleteObject()
        $context.ExecuteQuery()

        $groups = $context.Web.SiteGroups
        $context.Load($groups)
        $context.ExecuteQuery()
        while ($groups.Count -gt 0) 
        {
            $groups.Remove($groups[0])
        }
        $context.ExecuteQuery()

        $users = $context.Web.SiteUsers
        $context.Load($users)
        $context.ExecuteQuery()
        while ($users.Count -gt 0) 
        {
            $users.Remove($users[0])
        }
        $context.ExecuteQuery()

        $roleDefinitions = $context.Web.RoleDefinitions
        $context.Load($roleDefinitions)
        $context.ExecuteQuery()
        for ($i = $roleDefinitions.Count - 1; $i -ge 0; $i--) 
        {
            $roleDefinition = $roleDefinitions[$i]
            if ($roleDefinition.RoleTypeKind -eq [Microsoft.SharePoint.Client.RoleType]::None)
            {
                $roleDefinition.DeleteObject()
            }
        }
        $context.ExecuteQuery()

    }

}
