//
// Copyright (c) 2018-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Karamem0.SharePoint.PowerShell.Services.V1.Utilities;
using System.Xml.Linq;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IColumnTaxonomyService
{

    Task<ColumnTaxonomy?> AddObjectAsync(
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions,
        bool selectAllProperties = true
    );

    Task<ColumnTaxonomy?> AddObjectAsync(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions,
        bool selectAllProperties = true
    );

    Task RemoveObjectAsync(ColumnTaxonomy columnTaxonomyObject);

    Task SetObjectAsync(ColumnTaxonomy columnTaxonomyObject, IReadOnlyDictionary<string, object?> modificationInfo);

    Task SetObjectValueAsync(
        ColumnTaxonomy columnTaxonomyObject,
        ListItem listItemObject,
        IEnumerable<Term> termCollection,
        uint lcid
    );

}

public class ColumnTaxonomyService(ClientContext clientContext) : ClientService<ColumnTaxonomy>(clientContext), IColumnTaxonomyService
{

    public async Task<ColumnTaxonomy?> AddObjectAsync(
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathStaticProperty.Create(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(ObjectPathProperty.Create(objectPath2.Id, "Fields"));
        var objectPath4 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath3.Id,
                "AddFieldAsXml",
                requestPayload.CreateParameter(SchemaXmlColumn.Create(new XElement("Field", new XAttribute("Type", "TaxonomyFieldType")), creationInfo)),
                requestPayload.CreateParameter(addToDefaultView),
                requestPayload.CreateParameter(addColumnOptions)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ColumnTaxonomy>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task<ColumnTaxonomy?> AddObjectAsync(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions,
        bool selectAllProperties = true
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathProperty.Create(objectPath1.Id, "Fields"));
        var objectPath3 = requestPayload.Add(
            ObjectPathMethod.Create(
                objectPath2.Id,
                "AddFieldAsXml",
                requestPayload.CreateParameter(SchemaXmlColumn.Create(new XElement("Field", new XAttribute("Type", "TaxonomyFieldType")), creationInfo)),
                requestPayload.CreateParameter(addToDefaultView),
                requestPayload.CreateParameter(addColumnOptions)
            ),
            ClientActionInstantiateObjectPath.Create,
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(selectAllProperties, typeof(Column)))
        );
        return await this
            .ClientContext.ProcessQueryAsync(requestPayload)
            .ContinueWith(task => task.Result.ToObject<ColumnTaxonomy>(requestPayload.GetActionId<ClientActionQuery>()));
    }

    public async Task SetObjectValueAsync(
        ColumnTaxonomy columnTaxonomyObject,
        ListItem listItemObject,
        IEnumerable<Term> termCollection,
        uint lcid
    )
    {
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(ObjectPathIdentity.Create(columnTaxonomyObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(ObjectPathIdentity.Create(listItemObject.ObjectIdentity));
        var objectPath3 = requestPayload.Add(
            objectPath1,
            objectPathId => ClientActionMethod.Create(
                objectPathId,
                "SetFieldValueByCollection",
                requestPayload.CreateParameter(objectPath2),
                requestPayload.CreateParameter(termCollection),
                requestPayload.CreateParameter(lcid)
            )
        );
        var objectPath4 = requestPayload.Add(objectPath2, objectPathId => ClientActionMethod.Create(objectPathId, "Update"));
        _ = await this.ClientContext.ProcessQueryAsync(requestPayload);
    }

}
