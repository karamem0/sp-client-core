#
# Copyright (c) 2018-2025 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/sp-client-core/blob/main/LICENSE
#

function Install-TestSite {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $TenantName,
        [Parameter(Mandatory = $true)]
        [string]
        $ClientId,
        [Parameter(Mandatory = $true)]
        [string]
        $CertificatePath,
        [Parameter(Mandatory = $true)]
        [string]
        $PrivateKeyPath,
        [Parameter(Mandatory = $true)]
        [string]
        $OwnerUserName,
        [Parameter(Mandatory = $true)]
        [string]
        $ExternalUserName
    )

    process {

        $global:ConfirmPreference = 'None'

        $appSettings = [ordered]@{ }

        $domainName = "${TenantName}.onmicrosoft.com"
        $baseUrl = "https://${TenantName}.sharepoint.com/sites/sp-client-core"
        $authorityUrl = "https://${TenantName}.sharepoint.com"
        $adminUrl = "https://${TenantName}-admin.sharepoint.com"

        $appSettings.LoginDomainName = $domainName
        $appSettings.ClientId = $ClientId
        $appSettings.CertificatePath = $CertificatePath
        $appSettings.PrivateKeyPath = $PrivateKeyPath
        $appSettings.OwnerUserName = $OwnerUserName
        $appSettings.ExternalUserName = $ExternalUserName
        $appSettings.BaseUrl = $baseUrl
        $appSettings.AuthorityUrl = $authorityUrl
        $appSettings.AdminUrl = $adminUrl

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        Connect-KshSite `
            -Url $adminUrl `
            -ClientId $ClientId `
            -CertificatePath $CertificatePath `
            -PrivateKeyPath $PrivateKeyPath

        $tenantAppCatalogUrl = Get-KshTenantAppCatalog
        $appSettings.TenantAppCatalogUrl = $tenantAppCatalogUrl

        Write-Progress -Activity 'Creating term groups...' -Status 'Test Term Group 1'
        $termGroup1 = Add-KshTermGroup -Name 'Test Term Group 1'
        $appSettings.TermGroup1Id = $termGroup1.Id
        $appSettings.TermGroup1Name = $termGroup1.Name

        Write-Progress -Activity 'Creating term groups...' -Status 'Test Term Group 2'
        $termGroup2 = Add-KshTermGroup -Name 'Test Term Group 2'
        $appSettings.TermGroup2Id = $termGroup2.Id
        $appSettings.TermGroup2Name = $termGroup2.Name

        Write-Progress -Activity 'Creating term groups...' -Status 'Test Term Group 3'
        $termGroup3 = Add-KshTermGroup -Name 'Test Term Group 3'
        $appSettings.TermGroup3Id = $termGroup3.Id
        $appSettings.TermGroup3Name = $termGroup3.Name

        Write-Progress -Activity 'Creating term sets...' -Status 'Waiting'
        Start-Sleep -Seconds 15

        Write-Progress -Activity 'Creating term sets...' -Status 'Test Term Set 1'
        $termSet1 = Add-KshTermSet `
            -TermGroup $termGroup1 `
            -Name 'Test Term Set 1' `
            -Lcid 1033
        $appSettings.TermSet1Id = $termSet1.Id
        $appSettings.TermSet1Name = $termSet1.Name

        Write-Progress -Activity 'Creating term sets...' -Status 'Test Term Set 2'
        $termSet2 = Add-KshTermSet `
            -TermGroup $termGroup1 `
            -Name 'Test Term Set 2' `
            -Lcid 1033
        $appSettings.TermSet2Id = $termSet2.Id
        $appSettings.TermSet2Name = $termSet2.Name

        Write-Progress -Activity 'Creating term sets...' -Status 'Test Term Set 3'
        $termSet3 = Add-KshTermSet `
            -TermGroup $termGroup1 `
            -Name 'Test Term Set 3' `
            -Lcid 1033
        $appSettings.TermSet3Id = $termSet3.Id
        $appSettings.TermSet3Name = $termSet3.Name

        Write-Progress -Activity 'Creating terms...' -Status 'Waiting'
        Start-Sleep -Seconds 15

        Write-Progress -Activity 'Creating terms...' -Status 'Test Term 1'
        $term1 = Add-KshTerm `
            -TermSet $termSet1 `
            -Name 'Test Term 1' `
            -Lcid 1033
        $appSettings.Term1Id = $term1.Id
        $appSettings.Term1Name = $term1.Name

        Write-Progress -Activity 'Creating terms...' -Status 'Test Term 2'
        $term2 = Add-KshTerm `
            -Term $term1 `
            -Name 'Test Term 2' `
            -Lcid 1033
        $appSettings.Term2Id = $term2.Id
        $appSettings.Term2Name = $term2.Name

        Write-Progress -Activity 'Creating terms...' -Status 'Test Term 3'
        $term3 = Add-KshTerm `
            -Term $term1 `
            -Name 'Test Term 3' `
            -Lcid 1033
        $appSettings.Term3Id = $term3.Id
        $appSettings.Term3Name = $term3.Name

        Write-Progress -Activity 'Creating terms...' -Status 'Test Term 4'
        $term4 = Add-KshTerm `
            -Term $term2 `
            -Name 'Test Term 4' `
            -Lcid 1033
        $appSettings.Term4Id = $term4.Id
        $appSettings.Term4Name = $term4.Name

        Write-Progress -Activity 'Creating a site collection...' -Status 'Processing'
        $siteCollection = Add-KshTenantSiteCollection `
            -Lcid 1033 `
            -Owner $OwnerUserName `
            -Title 'SPClientCore' `
            -Url $baseUrl

        Write-Progress -Activity 'Updating a site collection...' -Status 'Waiting'
        Start-Sleep -Seconds 60

        Write-Progress -Activity 'Updating a site collection...' -Status 'Processing'
        $siteCollection = Set-KshTenantSiteCollection `
            -Identity $siteCollection `
            -SharingCapability ExternalUserAndGuestSharing `
            -PassThru

        Write-Progress -Activity 'Retrieving a site collection...' -Status 'Waiting'
        Start-Sleep -Seconds 60

        Write-Progress -Activity 'Retrieving a site collection....' -Status 'Processing'
        $siteCollection = Get-KshSiteCollection -SiteCollectionUrl $siteCollection.Url
        $appSettings.SiteCollectionId = $siteCollection.Id
        $appSettings.SiteCollectionUrl = $siteCollection.ServerRelativeUrl

        Write-Progress -Activity 'Adding a site collection app catalog...' -Status 'Processing'
        Add-KshSiteCollectionAppCatalog -SiteCollection $siteCollection

        Write-Progress -Activity 'Adding list scripts...' -Status 'Test List Script 1'
        $listScript1 = Add-KshTenantSiteScript `
            -Content '{"actions":[{"verb":"createSPList","listName":"Test List 1","templateType":101,"subactions":[]}]}' `
            -Title 'Test List Script 1'
        $appSettings.ListScript1Id = $listScript1.Id

        Write-Progress -Activity 'Adding list scripts...' -Status 'Test List Script 2'
        $listScript2 = Add-KshTenantSiteScript `
            -Content '{"actions":[{"verb":"createSPList","listName":"Test List 2","templateType":101,"subactions":[]}]}' `
            -Title 'Test List Script 2'
        $appSettings.ListScript2Id = $listScript2.Id

        Write-Progress -Activity 'Adding list scripts...' -Status 'Test List Script 3'
        $listScript3 = Add-KshTenantSiteScript `
            -Content '{"actions":[{"verb":"createSPList","listName":"Test List 3","templateType":101,"subactions":[]}]}' `
            -Title 'Test List Script 3'
        $appSettings.ListScript3Id = $listScript3.Id

        Write-Progress -Activity 'Adding site scripts...' -Status 'Test Site Script 1'
        $siteScript1 = Add-KshTenantSiteScript `
            -Content '{"actions":[{"verb":"setSiteBranding"}]}' `
            -Title 'Test Site Script 1'
        $appSettings.SiteScript1Id = $siteScript1.Id

        Write-Progress -Activity 'Adding site scripts...' -Status 'Test Site Script 2'
        $siteScript2 = Add-KshTenantSiteScript `
            -Content '{"actions":[{"verb":"setSiteBranding"}]}' `
            -Title 'Test Site Script 2'
        $appSettings.SiteScript5Id = $siteScript2.Id

        Write-Progress -Activity 'Adding site scripts...' -Status 'Test Site Script 3'
        $siteScript3 = Add-KshTenantSiteScript `
            -Content '{"actions":[{"verb":"setSiteBranding"}]}' `
            -Title 'Test Site Script 3'
        $appSettings.SiteScript6Id = $siteScript3.Id

        Write-Progress -Activity 'Adding list designs...' -Status 'Test List Design 1'
        $listDesign1 = Add-KshTenantListDesign `
            -SiteScriptIds @($listScript1.Id) `
            -Title 'Test List Design 1'
        $appSettings.ListDesign1Id = $listDesign1.Id

        Write-Progress -Activity 'Adding list designs...' -Status 'Test List Design 2'
        $listDesign2 = Add-KshTenantListDesign `
            -SiteScriptIds @($listScript2.Id) `
            -Title 'Test List Design 2'
        $appSettings.ListDesign2Id = $listDesign2.Id

        Write-Progress -Activity 'Adding list designs...' -Status 'Test List Design 3'
        $listDesign3 = Add-KshTenantListDesign `
            -SiteScriptIds @($listScript3.Id) `
            -Title 'Test List Design 3'
        $appSettings.ListDesign3Id = $listDesign3.Id

        Write-Progress -Activity 'Adding site designs...' -Status 'Test Site Design 1'
        $siteDesign1 = Add-KshTenantSiteDesign `
            -SiteScriptIds @($siteScript1.Id) `
            -Title 'Test Site Design 1'
        $appSettings.SiteDesign1Id = $siteDesign1.Id

        Write-Progress -Activity 'Adding site designs...' -Status 'Test Site Design 2'
        $siteDesign2 = Add-KshTenantSiteDesign `
            -SiteScriptIds @($siteScript2.Id) `
            -Title 'Test Site Design 2'
        $appSettings.SiteDesign2Id = $siteDesign2.Id

        Write-Progress -Activity 'Adding site designs...' -Status 'Test Site Design 3'
        $siteDesign3 = Add-KshTenantSiteDesign `
            -SiteScriptIds @($siteScript3.Id) `
            -Title 'Test Site Design 3'
        $appSettings.SiteDesign3Id = $siteDesign3.Id

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        Connect-KshSite `
            -Url $baseUrl `
            -ClientId $ClientId `
            -CertificatePath $CertificatePath `
            -PrivateKeyPath $PrivateKeyPath

        Write-Progress -Activity 'Removing site groups...' -Status 'Processing'
        Get-KshGroup | Remove-KshGroup

        Write-Progress -Activity 'Creating site groups...' -Status 'Test Group 1'
        $group1 = Add-KshGroup `
            -Description 'Test Group 1' `
            -Title 'Test Group 1'

        Write-Progress -Activity 'Creating site groups...' -Status 'Test Group 2'
        $group2 = Add-KshGroup `
            -Description 'Test Group 2' `
            -Title 'Test Group 2'

        Write-Progress -Activity 'Creating site groups...' -Status 'Test Group 3'
        $group3 = Add-KshGroup `
            -Description 'Test Group 3' `
            -Title 'Test Group 3'

        Write-Progress -Activity 'Retrieving site groups...' -Status 'Waiting'
        Start-Sleep -Seconds 15

        Write-Progress -Activity 'Retrieving site groups...' -Status 'Processing'
        $group1 = Get-KshGroup -GroupTitle 'Test Group 1'
        $group2 = Get-KshGroup -GroupTitle 'Test Group 2'
        $group3 = Get-KshGroup -GroupTitle 'Test Group 3'

        Write-Progress -Activity 'Updating site groups...' -Status 'Test Group 1'
        Set-KshGroupOwner `
            -Group $group1 `
            -Owner $group1
        $appSettings.Group1Id = $group1.Id
        $appSettings.Group1Name = $group1.Title

        Write-Progress -Activity 'Updating site groups...' -Status 'Test Group 2'
        Set-KshGroupOwner `
            -Group $group2 `
            -Owner $group2
        $appSettings.Group2Id = $group2.Id
        $appSettings.Group2Name = $group2.Title

        Write-Progress -Activity 'Updating site groups...' -Status 'Test Group 3'
        Set-KshGroupOwner `
            -Group $group3 `
            -Owner $group3
        $appSettings.Group3Id = $group3.Id
        $appSettings.Group3Name = $group3.Title

        Write-Progress -Activity 'Creating site users...' -Status 'Test User 1'
        $user1 = Add-KshUser `
            -Email "testuser1@${domainName}" `
            -LoginName "i:0#.f|membership|testuser1@${domainName}" `
            -Title 'Test User 1'
        $appSettings.User1Id = $user1.Id
        $appSettings.User1LoginName = $user1.LoginName
        $appSettings.User1Title = $user1.Title
        $appSettings.User1Email = $user1.Email

        Write-Progress -Activity 'Creating site users...' -Status 'Test User 2'
        $user2 = Add-KshUser `
            -Email "testuser2@${domainName}" `
            -LoginName "i:0#.f|membership|testuser2@${domainName}" `
            -Title 'Test User 2'
        $appSettings.User2Id = $user2.Id
        $appSettings.User2LoginName = $user2.LoginName
        $appSettings.User2Title = $user2.Title
        $appSettings.User2Email = $user2.Email

        Write-Progress -Activity 'Creating site users...' -Status 'Test User 3'
        $user3 = Add-KshUser `
            -Email "testuser3@${domainName}" `
            -LoginName "i:0#.f|membership|testuser3@${domainName}" `
            -Title 'Test User 3'
        $appSettings.User3Id = $user3.Id
        $appSettings.User3LoginName = $user3.LoginName
        $appSettings.User3Title = $user3.Title
        $appSettings.User3Email = $user3.Email

        Write-Progress -Activity 'Adding site group members...' -Status 'Test User 1'
        Add-KshGroupMember `
            -Group $group1 `
            -Member $user1

        Write-Progress -Activity 'Adding site group members...' -Status 'Test User 2'
        Add-KshGroupMember `
            -Group $group1 `
            -Member $user2

        Write-Progress -Activity 'Adding site group members...' -Status 'Test User 3'
        Add-KshGroupMember `
            -Group $group1 `
            -Member $user3

        Write-Progress -Activity 'Creating role definitions...' -Status 'Test Role Definition 1'
        $basePermission1 = New-KshBasePermission -Permission 'EmptyMask'
        $roleDefinition1 = Add-KshRoleDefinition `
            -BasePermission $basePermission1 `
            -Name 'Test Role Definition 1'
        $appSettings.RoleDefinition1Id = $RoleDefinition1.Id
        $appSettings.RoleDefinition1Name = $RoleDefinition1.Name

        Write-Progress -Activity 'Creating role definitions...' -Status 'Test Role Definition 2'
        $basePermission2 = New-KshBasePermission -Permission 'EmptyMask'
        $roleDefinition2 = Add-KshRoleDefinition `
            -BasePermission $basePermission2 `
            -Name 'Test Role Definition 2'
        $appSettings.RoleDefinition2Id = $RoleDefinition2.Id
        $appSettings.RoleDefinition2Name = $RoleDefinition2.Name

        Write-Progress -Activity 'Creating role definitions...' -Status 'Test Role Definition 3'
        $basePermission3 = New-KshBasePermission -Permission 'EmptyMask'
        $roleDefinition3 = Add-KshRoleDefinition `
            -BasePermission $basePermission3 `
            -Name 'Test Role Definition 3'
        $appSettings.RoleDefinition3Id = $RoleDefinition3.Id
        $appSettings.RoleDefinition3Name = $RoleDefinition3.Name

        Write-Progress -Activity 'Creating sites...' -Status 'Test Site 1'
        $site1 = Add-KshSite `
            -Description 'Test Site 1' `
            -Lcid 1033 `
            -ServerRelativeUrl 'TestSite1' `
            -Template 'STS#0' `
            -Title 'Test Site 1'
        $appSettings.Site1Id = $site1.Id
        $appSettings.Site1Url = $site1.ServerRelativeUrl
        $appSettings.Site1Title = $site1.Title

        Write-Progress -Activity 'Updating sites...' -Status 'Test Site 1'
        $site1 = Set-KshSite `
            -Identity $site1 `
            -NavAudienceTargetingEnabled $true `
            -PassThru

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 1'
        Select-KshSite -Identity $site1

        Write-Progress -Activity 'Breaking role inheritance...' -Status 'Test Site 1'
        Set-KshUniqueRoleAssignmentEnabled -Site -Enabled

        Write-Progress -Activity 'Creating site role assignments...' -Status 'Test Role Definition 1'
        $siteRoleAssignment1 = Add-KshRoleAssignment `
            -Site `
            -Principal $group1 `
            -RoleDefinition $roleDefinition1
        $appSettings.SiteRoleAssignment1Id = $siteRoleAssignment1.PrincipalId

        Write-Progress -Activity 'Creating site role assignments...' -Status 'Test Role Definition 2'
        $siteRoleAssignment2 = Add-KshRoleAssignment `
            -Site `
            -Principal $group2 `
            -RoleDefinition $roleDefinition2
        $appSettings.SiteRoleAssignment2Id = $siteRoleAssignment2.PrincipalId

        Write-Progress -Activity 'Creating site role assignments...' -Status 'Test Role Definition 3'
        $siteRoleAssignment3 = Add-KshRoleAssignment `
            -Site `
            -Principal $group3 `
            -RoleDefinition $roleDefinition3
        $appSettings.SiteRoleAssignment3Id = $siteRoleAssignment3.PrincipalId

        Write-Progress -Activity 'Creating sites...' -Status 'Test Site 2'
        $site2 = Add-KshSite `
            -Description 'Test Site 2' `
            -Lcid 1033 `
            -ServerRelativeUrl 'TestSite2' `
            -Template 'STS#0' `
            -Title 'Test Site 2'
        $appSettings.Site2Id = $site2.Id
        $appSettings.Site2Url = $site2.ServerRelativeUrl
        $appSettings.Site2Title = $site2.Title

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 2'
        Select-KshSite -Identity $site2

        Write-Progress -Activity 'Breaking role inheritance...' -Status 'Test Site 2'
        Set-KshUniqueRoleAssignmentEnabled -Site -Enabled

        Write-Progress -Activity 'Creating sites...' -Status 'Test Site 3'
        $site3 = Add-KshSite `
            -Description 'Test Site 3' `
            -Lcid 1033 `
            -ServerRelativeUrl 'TestSite3' `
            -Template 'STS#0' `
            -Title 'Test Site 3'
        $appSettings.Site3Id = $site3.Id
        $appSettings.Site3Url = $site3.ServerRelativeUrl
        $appSettings.Site3Title = $site3.Title

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 3'
        Select-KshSite -Identity $site3

        Write-Progress -Activity 'Breaking role inheritance...' -Status 'Test Site 3'
        Set-KshUniqueRoleAssignmentEnabled -Site -Enabled

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 2'
        Select-KshSite -Identity $site2

        Write-Progress -Activity 'Creating sites...' -Status 'Test Site 4'
        $site4 = Add-KshSite `
            -Description 'Test Site 4' `
            -Lcid 1033 `
            -ServerRelativeUrl 'TestSite4' `
            -Template 'STS#0' `
            -Title 'Test Site 4'
        $appSettings.Site4Id = $site4.Id
        $appSettings.Site4Url = $site4.ServerRelativeUrl
        $appSettings.Site4Title = $site4.Title

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 4'
        Select-KshSite -Identity $site4

        Write-Progress -Activity 'Breaking role inheritance...' -Status 'Test Site 4'
        Set-KshUniqueRoleAssignmentEnabled -Site -Enabled

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 1'
        Select-KshSite -Identity $site1

        Write-Progress -Activity 'Removing navigation nodes...' -Status 'Processing'
        $navigation = Get-KshNavigation
        $navigation.QuickLaunch | Remove-KshNavigationNode
        $navigation.TopNavigationBar | Remove-KshNavigationNode

        Write-Progress -Activity 'Creating navigation nodes...' -Status 'Test Navigation Node 1'
        $navigationNode1 = Add-KshNavigationNode `
            -TopNavigationBar `
            -AsLastNode $true `
            -Title 'Test Navigation Node 1' `
            -Url 'http://www.example.com'
        $appSettings.NavigationNode1Id = $navigationNode1.Id

        Write-Progress -Activity 'Creating navigation nodes...' -Status 'Test Navigation Node 2'
        $navigationNode2 = Add-KshNavigationNode `
            -TopNavigationBar `
            -AsLastNode $true `
            -Title 'Test Navigation Node 2' `
            -Url 'http://www.example.com'
        $appSettings.NavigationNode2Id = $navigationNode2.Id

        Write-Progress -Activity 'Creating navigation nodes...' -Status 'Test Navigation Node 3'
        $navigationNode3 = Add-KshNavigationNode `
            -TopNavigationBar `
            -AsLastNode $true `
            -Title 'Test Navigation Node 3' `
            -Url 'http://www.example.com'
        $appSettings.NavigationNode3Id = $navigationNode3.Id

        Write-Progress -Activity 'Creating navigation nodes...' -Status 'Test Navigation Node 4'
        $navigationNode4 = Add-KshNavigationNode `
            -NavigationNode $navigationNode1 `
            -AsLastNode $true `
            -Title 'Test Navigation Node 4' `
            -Url 'http://www.example.com'
        $appSettings.NavigationNode4Id = $navigationNode4.Id

        Write-Progress -Activity 'Creating navigation nodes...' -Status 'Test Navigation Node 5'
        $navigationNode5 = Add-KshNavigationNode `
            -NavigationNode $navigationNode1 `
            -AsLastNode $true `
            -Title 'Test Navigation Node 5' `
            -Url 'http://www.example.com'
        $appSettings.NavigationNode5Id = $navigationNode5.Id

        Write-Progress -Activity 'Creating navigation nodes...' -Status 'Test Navigation Node 6'
        $navigationNode6 = Add-KshNavigationNode `
            -NavigationNode $navigationNode1 `
            -AsLastNode $true `
            -Title 'Test Navigation Node 6' `
            -Url 'http://www.example.com'
        $appSettings.NavigationNode6Id = $navigationNode6.Id

        Write-Progress -Activity 'Creating lists...' -Status 'Test List 1'
        $list1 = Add-KshList `
            -Description 'Test List 1' `
            -ServerRelativeUrl 'Lists/TestList1' `
            -Template 100 `
            -Title 'Test List 1'
        $list1 = Set-KshList `
            -Identity $list1 `
            -ContentTypesEnabled $true `
            -DraftVersionVisibility 1 `
            -EnableModeration $true `
            -EnableVersioning $true `
            -PassThru
        $list1Folder = Get-KshFolder -List $list1
        $appSettings.List1Id = $list1.Id
        $appSettings.List1Title = $list1.Title
        $appSettings.List1Url = $list1Folder.ServerRelativeUrl

        Write-Progress -Activity 'Breaking role inheritance...' -Status 'Test List 1'
        Set-KshUniqueRoleAssignmentEnabled -List $list1 -Enabled

        Write-Progress -Activity 'Creating list role assignments...' -Status 'Test Role Definition 1'
        $listRoleAssignment1 = Add-KshRoleAssignment `
            -List $list1 `
            -Principal $group1 `
            -RoleDefinition $roleDefinition1
        $appSettings.ListRoleAssignment1Id = $listRoleAssignment1.PrincipalId

        Write-Progress -Activity 'Creating list role assignments...' -Status 'Test Role Definition 2'
        $listRoleAssignment2 = Add-KshRoleAssignment `
            -List $list1 `
            -Principal $group2 `
            -RoleDefinition $roleDefinition2
        $appSettings.ListRoleAssignment2Id = $listRoleAssignment2.PrincipalId

        Write-Progress -Activity 'Creating list role assignments...' -Status 'Test Role Definition 3'
        $listRoleAssignment3 = Add-KshRoleAssignment `
            -List $list1 `
            -Principal $group3 `
            -RoleDefinition $roleDefinition3
        $appSettings.ListRoleAssignment3Id = $listRoleAssignment3.PrincipalId

        Write-Progress -Activity 'Creating lists...' -Status 'Test List 2'
        $list2 = Add-KshList `
            -Description 'Test List 2' `
            -ServerRelativeUrl 'TestList2' `
            -Template 101 `
            -Title 'Test List 2'
        $list2 = Set-KshList `
            -Identity $list2 `
            -ContentTypesEnabled $true `
            -DraftVersionVisibility 1 `
            -EnableMinorVersions $true `
            -EnableModeration $true `
            -EnableVersioning $true `
            -PassThru
        $list2Folder = Get-KshFolder -List $list2
        $list2Drive = Get-KshDrive -List $list2
        $appSettings.List2Id = $list2.Id
        $appSettings.List2Title = $list2.Title
        $appSettings.List2Url = $list2Folder.ServerRelativeUrl
        $appSettings.List2DriveId = $list2Drive.Id

        Write-Progress -Activity 'Creating lists...' -Status 'Test List 3'
        $list3 = Add-KshList `
            -Description 'Test List 3' `
            -ServerRelativeUrl 'TestList3' `
            -Template 101 `
            -Title 'Test List 3'
        $list3 = Set-KshList `
            -Identity $list3 `
            -ContentTypesEnabled $true `
            -PassThru
        $list3Folder = Get-KshFolder -List $list3
        $list3Drive = Get-KshDrive -List $list3
        $appSettings.List3Id = $list3.Id
        $appSettings.List3Title = $list3.Title
        $appSettings.List3Url = $list3Folder.ServerRelativeUrl
        $appSettings.List3DriveId = $list3Drive.Id

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 1'
        $siteContentType1 = Add-KshContentType `
            -Description 'Test Content Type 1' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 1'
        $appSettings.SiteContentType1Id = $siteContentType1.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 2'
        $siteContentType2 = Add-KshContentType `
            -Description 'Test Content Type 2' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 2'
        $appSettings.SiteContentType2Id = $siteContentType2.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 3'
        $siteContentType3 = Add-KshContentType `
            -Description 'Test Content Type 3' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 3'
        $appSettings.SiteContentType3Id = $siteContentType3.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 4'
        $siteContentType4 = Add-KshContentType `
            -Description 'Test Content Type 4' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 4'
        $appSettings.SiteContentType4Id = $siteContentType4.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 5'
        $siteContentType5 = Add-KshContentType `
            -Description 'Test Content Type 5' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 5'
        $appSettings.SiteContentType5Id = $siteContentType5.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 6'
        $siteContentType6 = Add-KshContentType `
            -Description 'Test Content Type 6' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 6'
        $appSettings.SiteContentType6Id = $siteContentType6.StringId

        Write-Progress -Activity 'Changing current site...' -Status 'Root Site'
        Get-KshSite -SiteUrl $baseUrl | Select-KshSite

        Write-Progress -Activity 'Retrieving content types....' -Status 'Processing'
        $docsetContentType = Get-KshContentType -ContentTypeId '0x0120D520'

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 1'
        Select-KshSite -Identity $site1

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 7'
        $siteContentType7 = Add-KshContentType `
            -ContentType $docsetContentType `
            -Description 'Test Content Type 7' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 7'
        $appSettings.SiteContentType7Id = $siteContentType7.StringId

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 1'
        $column1 = Add-KshColumnText `
            -AddColumnInternalNameHint `
            -Name 'TestColumn1' `
            -Title 'Test Column 1'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column1
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column1
        $appSettings.Column1Id = $column1.Id
        $appSettings.Column1Name = $column1.Name
        $appSettings.Column1Title = $column1.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 2'
        $column2 = Add-KshColumnMultiLineText `
            -AddColumnInternalNameHint `
            -Name 'TestColumn2' `
            -Title 'Test Column 2'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column2
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column2
        $appSettings.Column2Id = $column2.Id
        $appSettings.Column2Name = $column2.Name
        $appSettings.Column2Title = $column2.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 3'
        $column3 = Add-KshColumnChoice `
            -AddColumnInternalNameHint `
            -Choices @('Test Value 1', 'Test Value 2', 'Test Value 3') `
            -Name 'TestColumn3' `
            -Title 'Test Column 3'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column3
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column3
        $appSettings.Column3Id = $column3.Id
        $appSettings.Column3Name = $column3.Name
        $appSettings.Column3Title = $column3.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 4'
        $column4 = Add-KshColumnMultiChoice `
            -AddColumnInternalNameHint `
            -Choices @('Test Value 1', 'Test Value 2', 'Test Value 3') `
            -Name 'TestColumn4' `
            -Title 'Test Column 4'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column4
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column4
        $appSettings.Column4Id = $column4.Id
        $appSettings.Column4Name = $column4.Name
        $appSettings.Column4Title = $column4.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 5'
        $column5 = Add-KshColumnNumber `
            -AddColumnInternalNameHint `
            -Name 'TestColumn5' `
            -Title 'Test Column 5'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column5
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column5
        $appSettings.Column5Id = $column5.Id
        $appSettings.Column5Name = $column5.Name
        $appSettings.Column5Title = $column5.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 6'
        $column6 = Add-KshColumnCurrency `
            -AddColumnInternalNameHint `
            -Name 'TestColumn6' `
            -Title 'Test Column 6'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column6
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column6
        $appSettings.Column6Id = $column6.Id
        $appSettings.Column6Name = $column6.Name
        $appSettings.Column6Title = $column6.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 7'
        $column7 = Add-KshColumnDateTime `
            -AddColumnInternalNameHint `
            -Name 'TestColumn7' `
            -Title 'Test Column 7'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column7
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column7
        $appSettings.Column7Id = $column7.Id
        $appSettings.Column7Name = $column7.Name
        $appSettings.Column7Title = $column7.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 8'
        $column8 = Add-KshColumnLookup `
            -AddColumnInternalNameHint `
            -LookupColumnName 'Title' `
            -LookupListId $list1.Id `
            -Name 'TestColumn8' `
            -Title 'Test Column 8'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column8
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column8
        $appSettings.Column8Id = $column8.Id
        $appSettings.Column8Name = $column8.Name
        $appSettings.Column8Title = $column8.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 9'
        $column9 = Add-KshColumnLookup `
            -AddColumnInternalNameHint `
            -AllowMultipleValues $true `
            -LookupColumnName 'Title' `
            -LookupListId $list1.Id `
            -Name 'TestColumn9' `
            -Title 'Test Column 9'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column9
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column9
        $appSettings.Column9Id = $column9.Id
        $appSettings.Column9Name = $column9.Name
        $appSettings.Column9Title = $column9.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 10'
        $column10 = Add-KshColumnBoolean `
            -AddColumnInternalNameHint `
            -Name 'TestColumn10' `
            -Title 'Test Column 10'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column10
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column10
        $appSettings.Column10Id = $column10.Id
        $appSettings.Column10Name = $column10.Name
        $appSettings.Column10Title = $column10.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 11'
        $column11 = Add-KshColumnUser `
            -AddColumnInternalNameHint `
            -Name 'TestColumn11' `
            -Title 'Test Column 11'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column11
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column11
        $appSettings.Column11Id = $column11.Id
        $appSettings.Column11Name = $column11.Name
        $appSettings.Column11Title = $column11.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 12'
        $column12 = Add-KshColumnUser `
            -AddColumnInternalNameHint `
            -AllowMultipleValues $true `
            -Name 'TestColumn12' `
            -Title 'Test Column 12'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column12
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column12
        $appSettings.Column12Id = $column12.Id
        $appSettings.Column12Name = $column12.Name
        $appSettings.Column12Title = $column12.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 13'
        $column13 = Add-KshColumnUrl `
            -AddColumnInternalNameHint `
            -Name 'TestColumn13' `
            -Title 'Test Column 13'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column13
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column13
        $appSettings.Column13Id = $column13.Id
        $appSettings.Column13Name = $column13.Name
        $appSettings.Column13Title = $column13.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 14'
        $column14 = Add-KshColumnCalculated `
            -AddColumnInternalNameHint `
            -Columns @($column1) `
            -Formula '=TestColumn1' `
            -Name 'TestColumn14' `
            -OutputType 'Text' `
            -Title 'Test Column 14'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column14
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column14
        $appSettings.Column14Id = $column14.Id
        $appSettings.Column14Name = $column14.Name
        $appSettings.Column14Title = $column14.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 15'
        $column15 = Add-KshColumnGuid `
            -AddColumnInternalNameHint `
            -Name 'TestColumn15' `
            -Title 'Test Column 15'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column15
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column15
        $appSettings.Column15Id = $column15.Id
        $appSettings.Column15Name = $column15.Name
        $appSettings.Column15Title = $column15.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 16'
        $column16 = Add-KshColumnGeolocation `
            -AddColumnInternalNameHint `
            -Name 'TestColumn16' `
            -Title 'Test Column 16'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column16
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column16
        $appSettings.Column16Id = $column16.Id
        $appSettings.Column16Name = $column16.Name
        $appSettings.Column16Title = $column16.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 17'
        $column17 = Add-KshColumnTaxonomy `
            -AddColumnInternalNameHint `
            -Name 'TestColumn17' `
            -TermSet $termSet1 `
            -Title 'Test Column 17'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column17
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column17
        $appSettings.Column17Id = $column17.Id
        $appSettings.Column17Name = $column17.Name
        $appSettings.Column17Title = $column17.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 18'
        $column18 = Add-KshColumnImage `
            -AddColumnInternalNameHint `
            -Name 'TestColumn18' `
            -Title 'Test Column 18'
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column18
        $null = Add-KshContentTypeColumn `
            -ContentType $siteContentType7 `
            -Column $column18
        $appSettings.Column18Id = $column18.Id
        $appSettings.Column18Name = $column18.Name
        $appSettings.Column18Title = $column18.Title

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 1'
        $listContentType1 = Add-KshContentType `
            -List $list1 `
            -ContentType $siteContentType1
        $appSettings.ListContentType1Id = $listContentType1.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 2'
        $listContentType2 = Add-KshContentType `
            -List $list1 `
            -ContentType $siteContentType2
        $appSettings.ListContentType2Id = $listContentType2.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 3'
        $listContentType3 = Add-KshContentType `
            -List $list1 `
            -ContentType $siteContentType3
        $appSettings.ListContentType3Id = $listContentType3.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 4'
        $listContentType4 = Add-KshContentType `
            -List $list2 `
            -ContentType $siteContentType4
        $appSettings.ListContentType4Id = $listContentType4.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 5'
        $listContentType5 = Add-KshContentType `
            -List $list2 `
            -ContentType $siteContentType5
        $appSettings.ListContentType5Id = $listContentType5.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 6'
        $listContentType6 = Add-KshContentType `
            -List $list2 `
            -ContentType $siteContentType6
        $appSettings.ListContentType6Id = $listContentType6.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 7'
        $listContentType7 = Add-KshContentType `
            -List $list3 `
            -ContentType $siteContentType7
        $appSettings.ListContentType7Id = $listContentType7.StringId

        Write-Progress -Activity 'Creating views...' -Status 'Test View 1'
        $view1 = Add-KshView `
            -List $list1 `
            -Title 'TestView1' `
            -ViewColumns @(
                'Test Column 1'
                'Test Column 2'
                'Test Column 3'
                'Test Column 4'
                'Test Column 5'
                'Test Column 6'
                'Test Column 7'
                'Test Column 8'
                'Test Column 9'
                'Test Column 10'
                'Test Column 11'
                'Test Column 12'
                'Test Column 13'
                'Test Column 14'
                'Test Column 15'
                'Test Column 16'
                'Test Column 17'
                'Test Column 18'
            )
        $view1 = Set-KshView `
            -Identity $view1 `
            -Title 'Test View 1' `
            -PassThru
        $appSettings.View1Id = $view1.Id
        $appSettings.View1Title = $view1.Title

        Write-Progress -Activity 'Creating views...' -Status 'Test View 2'
        $view2 = Add-KshView `
            -List $list1 `
            -Title 'TestView2' `
            -ViewColumns @(
                'Test Column 1'
                'Test Column 2'
                'Test Column 3'
                'Test Column 4'
                'Test Column 5'
                'Test Column 6'
                'Test Column 7'
                'Test Column 8'
                'Test Column 9'
                'Test Column 10'
                'Test Column 11'
                'Test Column 12'
                'Test Column 13'
                'Test Column 14'
                'Test Column 15'
                'Test Column 16'
                'Test Column 17'
                'Test Column 18'
            )
        $view2 = Set-KshView `
            -Identity $view2 `
            -Title 'Test View 2' `
            -PassThru
        $appSettings.View2Id = $view2.Id
        $appSettings.View2Title = $view2.Title

        Write-Progress -Activity 'Creating views...' -Status 'Test View 3'
        $view3 = Add-KshView `
            -List $list1 `
            -Title 'TestView3' `
            -ViewColumns @(
                'Test Column 1'
                'Test Column 2'
                'Test Column 3'
                'Test Column 4'
                'Test Column 5'
                'Test Column 6'
                'Test Column 7'
                'Test Column 8'
                'Test Column 9'
                'Test Column 10'
                'Test Column 11'
                'Test Column 12'
                'Test Column 13'
                'Test Column 14'
                'Test Column 15'
                'Test Column 16'
                'Test Column 17'
                'Test Column 18'
            )
        $view3 = Set-KshView `
            -Identity $view3 `
            -Title 'Test View 3' `
            -PassThru
        $appSettings.View3Id = $view3.Id
        $appSettings.View3Title = $view3.Title

        Write-Progress -Activity 'Creating list items...' -Status 'Preparing'
        $userValue1 = New-KshColumnUserValue -LookupId $user1.Id
        $userValue2 = New-KshColumnUserValue -LookupId $user2.Id
        $userValue3 = New-KshColumnUserValue -LookupId $user3.Id

        Write-Progress -Activity 'Creating list items...' -Status 'Preparing'
        $urlValue1 = New-KshColumnUrlValue `
            -Description 'Test Value 1' `
            -Url 'http://www.example.com'
        $urlValue2 = New-KshColumnUrlValue `
            -Description 'Test Value 2' `
            -Url 'http://www.example.com'
        $urlValue3 = New-KshColumnUrlValue `
            -Description 'Test Value 3' `
            -Url 'http://www.example.com'

        Write-Progress -Activity 'Creating list items...' -Status 'Preparing'
        $geolocationValue1 = New-KshColumnGeolocationValue `
            -Latitude 35.689488 `
            -Longitude 139.691706
        $geolocationValue2 = New-KshColumnGeolocationValue `
            -Latitude 34.686297 `
            -Longitude 135.519661
        $geolocationValue3 = New-KshColumnGeolocationValue `
            -Latitude 35.180188 `
            -Longitude 136.906565

        Write-Progress -Activity 'Creating list items...' -Status 'Preparing'
        $taxonomyValue1 = New-KshColumnTaxonomyValue -Term $term1
        $taxonomyValue2 = New-KshColumnTaxonomyValue -Term $term1
        $taxonomyValue3 = New-KshColumnTaxonomyValue -Term $term1

        Write-Progress -Activity 'Creating list items...' -Status 'Test List Item 1'
        $item1 = Add-KshListItem `
            -List $list1 `
            -Value @{
                ContentTypeId = $listContentType1.StringId
                Title = 'Test List Item 1'
                TestColumn1 = 'Test Value 1'
                TestColumn2 = 'Test Value 1'
                TestColumn3 = 'Test Value 1'
                TestColumn4 = @('Test Value 1')
                TestColumn5 = 1
                TestColumn6 = 1
                TestColumn7 = [datetime]'10/10/2010'
                TestColumn10 = $true
                TestColumn11 = $userValue1
                TestColumn12 = @($userValue1)
                TestColumn13 = $urlValue1
                TestColumn15 = 'e4ff6b12-0639-4107-a99a-eaa61c8670bb'
                TestColumn16 = $geolocationValue1
                TestColumn17 = $taxonomyValue1
            }
        $appSettings.ListItem1Id = $item1.Id

        Write-Progress -Activity 'Breaking role inheritance...' -Status 'Test List Item 1'
        Set-KshUniqueRoleAssignmentEnabled -ListItem $item1 -Enabled

        Write-Progress -Activity 'Creating list item role assignments...' -Status 'Test Role Definition 1'
        $itemRoleAssignment1 = Add-KshRoleAssignment `
            -ListItem $item1 `
            -Principal $group1 `
            -RoleDefinition $roleDefinition1
        $appSettings.ListItemRoleAssignment1Id = $itemRoleAssignment1.PrincipalId

        Write-Progress -Activity 'Creating list item role assignments...' -Status 'Test Role Definition 2'
        $itemRoleAssignment2 = Add-KshRoleAssignment `
            -ListItem $item1 `
            -Principal $group2 `
            -RoleDefinition $roleDefinition2
        $appSettings.ListItemRoleAssignment2Id = $itemRoleAssignment2.PrincipalId

        Write-Progress -Activity 'Creating list item role assignments...' -Status 'Test Role Definition 3'
        $itemRoleAssignment3 = Add-KshRoleAssignment `
            -ListItem $item1 `
            -Principal $group3 `
            -RoleDefinition $roleDefinition3
        $appSettings.ListItemRoleAssignment3Id = $itemRoleAssignment3.PrincipalId

        Write-Progress -Activity 'Creating list items...' -Status 'Test List Item 2'
        $item2 = Add-KshListItem `
            -List $list1 `
            -Value @{
                ContentTypeId = $listContentType1.StringId
                Title = 'Test List Item 2'
                TestColumn1 = 'Test Value 2'
                TestColumn2 = 'Test Value 2'
                TestColumn3 = 'Test Value 2'
                TestColumn4 = @('Test Value 2')
                TestColumn5 = 2
                TestColumn6 = 2
                TestColumn7 = [datetime]'12/20/2016'
                TestColumn10 = $true
                TestColumn11 = $userValue2
                TestColumn12 = @($userValue2)
                TestColumn13 = $urlValue2
                TestColumn15 = '55477a54-c686-42ae-9c43-c70bf388915f'
                TestColumn16 = $geolocationValue2
                TestColumn17 = $taxonomyValue2
            }
        $appSettings.ListItem2Id = $item2.Id

        Write-Progress -Activity 'Creating list items...' -Status 'Test List Item 3'
        $item3 = Add-KshListItem `
            -List $list1 `
            -Value @{
                ContentTypeId = $listContentType1.StringId
                Title = 'Test List Item 3'
                TestColumn1 = 'Test Value 3'
                TestColumn2 = 'Test Value 3'
                TestColumn3 = 'Test Value 3'
                TestColumn4 = @('Test Value 1', 'Test Value 2', 'Test Value 3')
                TestColumn5 = 1
                TestColumn6 = 1
                TestColumn7 = [datetime]'12/20/2016'
                TestColumn10 = $true
                TestColumn11 = $userValue3
                TestColumn12 = @($userValue1, $userValue2, $userValue3)
                TestColumn13 = $urlValue3
                TestColumn15 = '629dc9f8-097f-4cd1-8c0e-a9d458ed2d66'
                TestColumn16 = $geolocationValue3
                TestColumn17 = $taxonomyValue3
            }
        $appSettings.ListItem3Id = $item3.Id

        Write-Progress -Activity 'Updating list items...' -Status 'Preparing'
        $lookupValue1 = New-KshColumnLookupValue -LookupId $item1.Id
        $lookupValue2 = New-KshColumnLookupValue -LookupId $item2.Id
        $lookupValue3 = New-KshColumnLookupValue -LookupId $item3.Id

        Write-Progress -Activity 'Updating list items...' -Status 'Test List Item 1'
        $item1 = Set-KshListItem `
            -Identity $item1 `
            -Value @{
                TestColumn8 = $lookupValue1
                TestColumn9 = @($lookupValue1)
            } `
            -PassThru

        Write-Progress -Activity 'Updating list items...' -Status 'Test List Item 2'
        $item2 = Set-KshListItem `
            -Identity $item2 `
            -Value @{
                TestColumn8 = $lookupValue2
                TestColumn9 = @($lookupValue2)
            } `
            -PassThru

        Write-Progress -Activity 'Updating list items...' -Status 'Test List Item 3'
        $item3 = Set-KshListItem `
            -Identity $item3 `
            -Value @{
                TestColumn8 = $lookupValue3
                TestColumn9 = @($lookupValue1, $lookupValue2, $lookupValue3)
            } `
            -PassThru

        Write-Progress -Activity 'Creating attachments...' -Status 'Test File 1'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile1')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachmentFile1 = Save-KshAttachmentFile `
            -ListItem $item1 `
            -Content $stream `
            -FileName 'TestFile1.txt' `
            -PassThru
        $appSettings.AttachmentFile1Name = $attachmentFile1.FileName

        Write-Progress -Activity 'Creating attachments...' -Status 'Test File 2'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile2')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachmentFile2 = Save-KshAttachmentFile `
            -ListItem $item1 `
            -Content $stream `
            -FileName 'TestFile2.txt' `
            -PassThru
        $appSettings.AttachmentFile2Name = $attachmentFile2.FileName

        Write-Progress -Activity 'Creating attachments...' -Status 'Test File 3'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile3')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachmentFile3 = Save-KshAttachmentFile `
            -ListItem $item1 `
            -Content $stream `
            -FileName 'TestFile3.txt' `
            -PassThru
        $appSettings.AttachmentFile3Name = $attachmentFile3.FileName

        Write-Progress -Activity 'Creating folders...' -Status 'Test Folder 1'
        $folder1 = Add-KshFolder `
            -Folder $list2Folder `
            -FolderName 'Test Folder 1'
        $appSettings.Folder1Url = $folder1.ServerRelativeUrl
        $appSettings.Folder1Name = $folder1.Name

        Write-Progress -Activity 'Retrieving list item...' -Status 'Test Folder 1'
        $item1 = Get-KshListItem -Folder $folder1
        $appSettings.Folder1ListItemId = $item1.Id

        Write-Progress -Activity 'Retrieving drive item...' -Status 'Test Folder 1'
        $item1 = Get-KshDriveItem -ListItem $item1
        $appSettings.Folder1DriveItemId = $item1.Id

        Write-Progress -Activity 'Creating folders...' -Status 'Test Folder 2'
        $folder2 = Add-KshFolder `
            -Folder $folder1 `
            -FolderName 'Test Folder 2'
        $appSettings.Folder2Url = $folder2.ServerRelativeUrl
        $appSettings.Folder2Name = $folder2.Name

        Write-Progress -Activity 'Retrieving list item...' -Status 'Test Folder 2'
        $item2 = Get-KshListItem -Folder $folder2
        $appSettings.Folder2ListItemId = $item2.Id

        Write-Progress -Activity 'Retrieving drive item...' -Status 'Test Folder 2'
        $item2 = Get-KshDriveItem -ListItem $item2
        $appSettings.Folder2DriveItemId = $item2.Id

        Write-Progress -Activity 'Creating files...' -Status 'Test Folder 3'
        $folder3 = Add-KshFolder `
            -Folder $folder1 `
            -FolderName 'Test Folder 3'
        $appSettings.Folder3Url = $folder3.ServerRelativeUrl
        $appSettings.Folder3Name = $folder3.Name

        Write-Progress -Activity 'Retrieving list item...' -Status 'Test Folder 3'
        $item3 = Get-KshListItem -Folder $folder3
        $appSettings.Folder3ListItemId = $item3.Id

        Write-Progress -Activity 'Retrieving drive item...' -Status 'Test Folder 3'
        $item3 = Get-KshDriveItem -ListItem $item3
        $appSettings.Folder3DriveItemId = $item3.Id

        Write-Progress -Activity 'Creating files...' -Status 'Test Folder 4'
        $folder4 = Add-KshFolder `
            -Folder $folder3 `
            -FolderName 'Test Folder 4'
        $appSettings.Folder4Url = $folder4.ServerRelativeUrl
        $appSettings.Folder4Name = $folder4.Name

        Write-Progress -Activity 'Retrieving list item...' -Status 'Test Folder 4'
        $item4 = Get-KshListItem -Folder $folder4
        $appSettings.Folder4ListItemId = $item4.Id

        Write-Progress -Activity 'Retrieving drive item...' -Status 'Test Folder 4'
        $item4 = Get-KshDriveItem -ListItem $item4
        $appSettings.Folder4DriveItemId = $item4.Id

        Write-Progress -Activity 'Creating files...' -Status 'Test File 1'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile1')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file1 = Save-KshFile `
            -Folder $folder1 `
            -Content $stream `
            -FileName 'TestFile1.txt' `
            -PassThru
        $appSettings.File1Url = $file1.ServerRelativeUrl
        $appSettings.File1Name = $file1.Name

        Write-Progress -Activity 'Retrieving list item...' -Status 'Test File 1'
        $item1 = Get-KshListItem -File $file1
        $appSettings.File1ListItemId = $item1.Id

        Write-Progress -Activity 'Retrieving drive item...' -Status 'Test File 1'
        $item1 = Get-KshDriveItem -ListItem $item1
        $appSettings.File1DriveItemId = $item1.Id

        Write-Progress -Activity 'Creating files...' -Status 'Test File 2'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile2')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file2 = Save-KshFile `
            -Folder $folder1 `
            -Content $stream `
            -FileName 'TestFile2.txt' `
            -PassThru
        $appSettings.File2Url = $file2.ServerRelativeUrl
        $appSettings.File2Name = $file2.Name

        Write-Progress -Activity 'Retrieving list item...' -Status 'Test File 2'
        $item2 = Get-KshListItem -File $file2
        $appSettings.File2ListItemId = $item2.Id

        Write-Progress -Activity 'Retrieving drive item...' -Status 'Test File 2'
        $item2 = Get-KshDriveItem -ListItem $item2
        $appSettings.File2DriveItemId = $item2.Id

        Write-Progress -Activity 'Creating files...' -Status 'Test File 3'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile3')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file3 = Save-KshFile `
            -Folder $folder1 `
            -Content $stream `
            -FileName 'TestFile3.txt' `
            -PassThru
        $appSettings.File3Url = $file3.ServerRelativeUrl
        $appSettings.File3Name = $file3.Name

        Write-Progress -Activity 'Retrieving list item...' -Status 'Test File 3'
        $item3 = Get-KshListItem -File $file3
        $appSettings.File3ListItemId = $item3.Id

        Write-Progress -Activity 'Retrieving drive item...' -Status 'Test File 3'
        $item3 = Get-KshDriveItem -ListItem $item3
        $appSettings.File3DriveItemId = $item3.Id

        Write-Progress -Activity 'Creating files...' -Status 'Test File 4'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile4')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file4 = Save-KshFile `
            -Folder $folder4 `
            -Content $stream `
            -FileName 'TestFile4.txt' `
            -PassThru
        $appSettings.File4Url = $file4.ServerRelativeUrl
        $appSettings.File4Name = $file4.Name

        Write-Progress -Activity 'Retrieving list item...' -Status 'Test File 4'
        $item4 = Get-KshListItem -File $file4
        $appSettings.File4ListItemId = $item4.Id

        Write-Progress -Activity 'Retrieving drive item...' -Status 'Test File 4'
        $item4 = Get-KshDriveItem -ListItem $item4
        $appSettings.File4DriveItemId = $item4.Id

        Write-Progress -Activity 'Updating document set shared columns...' -Status 'Test Column 1'
        Add-KshDocumentSetSharedColumn `
            -ContentType $siteContentType7 `
            -Column $column1 `
            -PushChanges

        Write-Progress -Activity 'Updating document set shared columns...' -Status 'Test Column 2'
        Add-KshDocumentSetSharedColumn `
            -ContentType $siteContentType7 `
            -Column $column2 `
            -PushChanges

        Write-Progress -Activity 'Updating document set shared columns...' -Status 'Test Column 3'
        Add-KshDocumentSetSharedColumn `
            -ContentType $siteContentType7 `
            -Column $column3 `
            -PushChanges

        Write-Progress -Activity 'Updating document set welcome page columns...' -Status 'Test Column 1'
        Add-KshDocumentSetWelcomePageColumn `
            -ContentType $siteContentType7 `
            -Column $column1 `
            -PushChanges

        Write-Progress -Activity 'Updating document set welcome page columns...' -Status 'Test Column 2'
        Add-KshDocumentSetWelcomePageColumn `
            -ContentType $siteContentType7 `
            -Column $column2 `
            -PushChanges

        Write-Progress -Activity 'Updating document set welcome page columns...' -Status 'Test Column 3'
        Add-KshDocumentSetWelcomePageColumn `
            -ContentType $siteContentType7 `
            -Column $column3 `
            -PushChanges

        Write-Progress -Activity 'Creating document sets...' -Status 'Test Document Set 1'
        $documentSet1 = Add-KshDocumentSet `
            -Folder $list3Folder `
            -Name 'Test Document Set 1' `
            -ContentType $listContentType7
        $appSettings.DocumentSet1Url = $documentSet1

        Write-Progress -Activity 'Creating document sets...' -Status 'Test Document Set 2'
        $documentSet2 = Add-KshDocumentSet `
            -Folder $list3Folder `
            -Name 'Test Document Set 2' `
            -ContentType $listContentType7
        $appSettings.DocumentSet2Url = $documentSet2

        Write-Progress -Activity 'Creating document sets...' -Status 'Test Document Set 3'
        $documentSet3 = Add-KshDocumentSet `
            -Folder $list3Folder `
            -Name 'Test Document Set 3' `
            -ContentType $listContentType7
        $appSettings.DocumentSet3Url = $documentSet3

        Write-Progress -Activity 'Retrieving site pages...' -Status 'Site Pages'
        $sitePageList = Get-KshList -LibraryType 'ClientRenderedSitePages'
        $sitePageFolder = Get-KshFolder -List $sitePageList
        $appSettings.SitePageFolderUrl = $sitePageFolder.ServerRelativeUrl

        Write-Progress -Activity 'Creating site pages...' -Status 'Test Site Page 1'
        Add-KshSitePage `
            -List $sitePageList `
            -PageName 'Test Site Page 1' `
            -PageLayoutType 'Article'
        $sitePage1 = Get-KshFile -FileUrl "$($sitePageFolder.ServerRelativeUrl)/Test Site Page 1.aspx"
        $appSettings.SitePage1Url = $sitePage1.ServerRelativeUrl

        Write-Progress -Activity 'Creating site pages...' -Status 'Test Site Page 2'
        Add-KshSitePage `
            -List $sitePageList `
            -PageName 'Test Site Page 2' `
            -PageLayoutType 'Article'
        $sitePage2 = Get-KshFile -FileUrl "$($sitePageFolder.ServerRelativeUrl)/Test Site Page 2.aspx"
        $appSettings.SitePage2Url = $sitePage2.ServerRelativeUrl

        Write-Progress -Activity 'Creating site pages...' -Status 'Test Site Page 3'
        Add-KshSitePage `
            -List $sitePageList `
            -PageName 'Test Site Page 3' `
            -PageLayoutType 'Article'
        $sitePage3 = Get-KshFile -FileUrl "$($sitePageFolder.ServerRelativeUrl)/Test Site Page 3.aspx"
        $appSettings.SitePage3Url = $sitePage3.ServerRelativeUrl

        Write-Progress -Activity 'Set like to comment...' -Status 'Test Site Page 1'
        Set-KshLike -ListItem (Get-KshListItem -File $sitePage1) -Like

        Write-Progress -Activity 'Creating comments...' -Status 'Test Comment 1'
        $comment1 = Add-KshComment `
            -ListItem (Get-KshListItem -File $sitePage1) `
            -Text 'Test Comment 1'
        $appSettings.Comment1Id = $comment1.Id

        Write-Progress -Activity 'Creating comments...' -Status 'Test Comment 2'
        $comment2 = Add-KshComment `
            -Comment $comment1 `
            -Text 'Test Comment 2'
        $appSettings.Comment2Id = $comment2.Id

        Write-Progress -Activity 'Creating comments...' -Status 'Test Comment 3'
        $comment3 = Add-KshComment `
            -Comment $comment1 `
            -Text 'Test Comment 3'
        $appSettings.Comment3Id = $comment3.Id

        Write-Progress -Activity 'Creating comments...' -Status 'Test Comment 4'
        $comment4 = Add-KshComment `
            -Comment $comment1 `
            -Text 'Test Comment 4'
        $appSettings.Comment4Id = $comment4.Id

        Write-Progress -Activity 'Set like to comment...' -Status 'Test Comment 1'
        Set-KshLike -Comment $comment1 -Like

        Write-Progress -Activity 'Creating alerts...' -Status 'Test Alert 1'
        $item1 = Get-KshListItem -List $list1 -ItemId $appSettings.ListItem1Id
        $alert1 = Add-KshAlert `
            -AlertFrequency 'Daily' `
            -AlertTemplateName 'SPAlertTemplateType.GenericList' `
            -AlertType 'ListItem' `
            -List $list1 `
            -ListItem $item1 `
            -Title 'Test Alert 1' `
            -User $user1
        $appSettings.Alert1Id = $alert1.Id

        Write-Progress -Activity 'Creating alerts...' -Status 'Test Alert 2'
        $item2 = Get-KshListItem -List $list1 -ItemId $appSettings.ListItem2Id
        $alert2 = Add-KshAlert `
            -AlertFrequency 'Daily' `
            -AlertTemplateName 'SPAlertTemplateType.GenericList' `
            -AlertType 'ListItem' `
            -List $list1 `
            -ListItem $item2 `
            -Title 'Test Alert 2' `
            -User $user2
        $appSettings.Alert2Id = $alert2.Id

        Write-Progress -Activity 'Creating alerts...' -Status 'Test Alert 3'
        $item3 = Get-KshListItem -List $list1 -ItemId $appSettings.ListItem3Id
        $alert3 = Add-KshAlert `
            -AlertFrequency 'Daily' `
            -AlertTemplateName 'SPAlertTemplateType.GenericList' `
            -AlertType 'ListItem' `
            -List $list1 `
            -ListItem $item3 `
            -Title 'Test Alert 3' `
            -User $user3
        $appSettings.Alert3Id = $alert3.Id

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        Connect-KshSite `
            -Url $tenantAppCatalogUrl `
            -ClientId $ClientId `
            -CertificatePath $CertificatePath `
            -PrivateKeyPath $PrivateKeyPath

        Write-Progress -Activity 'Creating storage entities...' -Status 'Test Entity 1'
        Add-KshStorageEntity `
            -Key 'Test Entity 1' `
            -Value 'Test Value 1' `
            -Description 'Test Value 1 Description' `
            -Comment 'Test Value 1 Comment'
        $appSettings.StorageEntity1Key = 'Test Entity 1'

        Write-Progress -Activity 'Creating storage entities...' -Status 'Test Entity 2'
        Add-KshStorageEntity `
            -Key 'Test Entity 2' `
            -Value 'Test Value 2' `
            -Description 'Test Value 2 Description' `
            -Comment 'Test Value 2 Comment'
        $appSettings.StorageEntity2Key = 'Test Entity 2'

        Write-Progress -Activity 'Creating storage entities...' -Status 'Test Entity 3'
        Add-KshStorageEntity `
            -Key 'Test Entity 3' `
            -Value 'Test Value 3' `
            -Description 'Test Value 3 Description' `
            -Comment 'Test Value 3 Comment'
        $appSettings.StorageEntity3Key = 'Test Entity 3'

        Write-Progress -Activity 'Retrieving app paths...' -Status 'Processing'
        $app0Path = Resolve-Path "$PSScriptRoot/../TestApps/TestApp0.sppkg"
        $appSettings.App0Path = $app0Path.ToString()
        $app1Path = Resolve-Path "$PSScriptRoot/../TestApps/TestApp1.sppkg"
        $appSettings.App1Path = $app1Path.ToString()
        $app2Path = Resolve-Path "$PSScriptRoot/../TestApps/TestApp2.sppkg"
        $appSettings.App2Path = $app2Path.ToString()
        $app3Path = Resolve-Path "$PSScriptRoot/../TestApps/TestApp3.sppkg"
        $appSettings.App3Path = $app3Path.ToString()

        Write-Progress -Activity 'Creating tenant apps...' -Status 'Test App 1'
        $app1 = Add-KshApp `
            -Tenant `
            -Content ([System.IO.File]::OpenRead($app1Path)) `
            -FileName 'TestApp1.sppkg'
        $appSettings.TenantApp1Id = $app1.Id

        Write-Progress -Activity 'Creating tenant apps...' -Status 'Test App 2'
        $app2 = Add-KshApp `
            -Tenant `
            -Content ([System.IO.File]::OpenRead($app2Path)) `
            -FileName 'TestApp2.sppkg'
        $appSettings.TenantApp2Id = $app2.Id

        Write-Progress -Activity 'Creating tenant apps...' -Status 'Test App 3'
        $app3 = Add-KshApp `
            -Tenant `
            -Content ([System.IO.File]::OpenRead($app3Path)) `
            -FileName 'TestApp3.sppkg'
        $appSettings.TenantApp3Id = $app3.Id

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        Connect-KshSite `
            -Url $baseUrl `
            -ClientId $ClientId `
            -CertificatePath $CertificatePath `
            -PrivateKeyPath $PrivateKeyPath

        Write-Progress -Activity 'Creating site collection apps...' -Status 'Test App 1'
        $app1 = Add-KshApp `
            -Content ([System.IO.File]::OpenRead($app1Path)) `
            -FileName 'TestApp1.sppkg'
        $file1 = Get-KshFile -App $app1
        $item1 = Get-KshListItem -File $file1
        $appSettings.SiteCollectionApp1Id = $app1.Id
        $appSettings.SiteCollectionApp1ProductId = $item1['AppProductID']

        Write-Progress -Activity 'Creating site collection apps...' -Status 'Test App 2'
        $app2 = Add-KshApp `
            -Content ([System.IO.File]::OpenRead($app2Path)) `
            -FileName 'TestApp2.sppkg'
        $file2 = Get-KshFile -App $app2
        $item2 = Get-KshListItem -File $file2
        $appSettings.SiteCollectionApp2Id = $app2.Id
        $appSettings.SiteCollectionApp2ProductId = $item2['AppProductID']

        Write-Progress -Activity 'Creating site collection apps...' -Status 'Test App 3'
        $app3 = Add-KshApp `
            -Content ([System.IO.File]::OpenRead($app3Path)) `
            -FileName 'TestApp3.sppkg'
        $file3 = Get-KshFile -App $app3
        $item3 = Get-KshListItem -File $file3
        $appSettings.SiteCollectionApp3Id = $app3.Id
        $appSettings.SiteCollectionApp3ProductId = $item3['AppProductID']

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 1'
        Select-KshSite -Identity $site1

        Write-Progress -Activity 'Installing apps...' -Status 'Test App 1'
        Set-KshAppInstalled -Identity $app1 -Installed $true
        $appInstance1 = Get-KshAppInstance -AppProductId $item1['AppProductID']
        $appSettings.AppInstance1Id = $appInstance1.Id

        Write-Progress -Activity 'Installing apps...' -Status 'Test App 2'
        Set-KshAppInstalled -Identity $app2 -Installed $true
        $appInstance2 = Get-KshAppInstance -AppProductId $item2['AppProductID']
        $appSettings.AppInstance2Id = $appInstance2.Id

        Write-Progress -Activity 'Installing apps...' -Status 'Test App 3'
        Set-KshAppInstalled -Identity $app3 -Installed $true
        $appInstance3 = Get-KshAppInstance -AppProductId $item3['AppProductID']
        $appSettings.AppInstance3Id = $appInstance3.Id

        Write-Output $appSettings
    }

}

function Uninstall-TestSite {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]
        $TenantName,
        [Parameter(Mandatory = $true)]
        [string]
        $ClientId,
        [Parameter(Mandatory = $true)]
        [string]
        $CertificatePath,
        [Parameter(Mandatory = $true)]
        [string]
        $PrivateKeyPath
    )

    process {

        $global:ConfirmPreference = 'None'

        $baseUrl = "https://${TenantName}.sharepoint.com/sites/sp-client-core"
        $authorityUrl = "https://${TenantName}.sharepoint.com"
        $adminUrl = "https://${TenantName}-admin.sharepoint.com"

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        Connect-KshSite `
            -Url $adminUrl `
            -ClientId $ClientId `
            -CertificatePath $CertificatePath `
            -PrivateKeyPath $PrivateKeyPath

        Write-Progress -Activity 'Removing site collection app catalogs...' -Status 'Processing'
        Get-KshSiteCollectionAppCatalog -SiteCollectionUrl $baseUrl | Remove-KshSiteCollectionAppCatalog

        Write-Progress -Activity 'Removing a site collection...' -Status 'Processing'
        Get-KshTenantSiteCollection -SiteCollectionUrl $baseUrl | Remove-KshTenantSiteCollection
        Get-KshTenantDeletedSiteCollection -SiteCollectionUrl $baseUrl | Remove-KshTenantDeletedSiteCollection

        Write-Progress -Activity 'Retrieving term groups...' -Status 'Waiting'
        Start-Sleep -Seconds 15

        Write-Progress -Activity 'Retrieving term groups...' -Status 'Processing'
        $termGroup1 = Get-KshTermGroup -TermGroupName 'Test Term Group 1'
        $termGroup2 = Get-KshTermGroup -TermGroupName 'Test Term Group 2'
        $termGroup3 = Get-KshTermGroup -TermGroupName 'Test Term Group 3'

        Write-Progress -Activity 'Retrieving term sets...' -Status 'Processing'
        $termSet1 = Get-KshTermSet `
            -TermGroup $termGroup1 `
            -TermSetName 'Test Term Set 1'
        $termSet2 = Get-KshTermSet `
            -TermGroup $termGroup1 `
            -TermSetName 'Test Term Set 2'
        $termSet3 = Get-KshTermSet `
            -TermGroup $termGroup1 `
            -TermSetName 'Test Term Set 3'

        Write-Progress -Activity 'Retrieving terms...' -Status 'Processing'
        $term1 = Get-KshTerm `
            -TermSet $termSet1 `
            -TermName 'Test Term 1'

        Write-Progress -Activity 'Removing terms...' -Status 'Processing'
        Remove-KshTerm -Identity $term1

        Write-Progress -Activity 'Removing term sets...' -Status 'Waiting'
        Start-Sleep -Seconds 15

        Write-Progress -Activity 'Removing term sets...' -Status 'Processing'
        Remove-KshTermSet -Identity $termSet1
        Remove-KshTermSet -Identity $termSet2
        Remove-KshTermSet -Identity $termSet3

        Write-Progress -Activity 'Removing term groups...' -Status 'Waiting'
        Start-Sleep -Seconds 15

        Write-Progress -Activity 'Removing term groups...' -Status 'Processing'
        Remove-KshTermGroup -Identity $termGroup1
        Remove-KshTermGroup -Identity $termGroup2
        Remove-KshTermGroup -Identity $termGroup3

        Write-Progress -Activity 'Removing site scripts...' -Status 'Processing'
        Get-KshTenantSiteScript | Remove-KshTenantSiteScript

        Write-Progress -Activity 'Removing list designs...' -Status 'Processing'
        Get-KshTenantListDesign | Remove-KshTenantListDesign

        Write-Progress -Activity 'Removing site designs...' -Status 'Processing'
        Get-KshTenantSiteDesign | Remove-KshTenantSiteDesign

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        $tenantAppCatalogUrl = Get-KshTenantAppCatalog
        Connect-KshSite `
            -Url $tenantAppCatalogUrl `
            -ClientId $ClientId `
            -CertificatePath $CertificatePath `
            -PrivateKeyPath $PrivateKeyPath

        Write-Progress -Activity 'Removing tenant apps...' -Status 'Processing'
        Get-KshApp -Tenant | Where-Object { $_.Title -eq 'TestApp1' } | Remove-KshApp -Tenant
        Get-KshApp -Tenant | Where-Object { $_.Title -eq 'TestApp2' } | Remove-KshApp -Tenant
        Get-KshApp -Tenant | Where-Object { $_.Title -eq 'TestApp3' } | Remove-KshApp -Tenant

    }

}

