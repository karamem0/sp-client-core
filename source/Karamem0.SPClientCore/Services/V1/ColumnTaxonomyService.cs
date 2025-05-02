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
using Karamem0.SharePoint.PowerShell.Services.V1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Karamem0.SharePoint.PowerShell.Services.V1;

public interface IColumnTaxonomyService
{

    ColumnTaxonomy? AddObject(
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
    );

    ColumnTaxonomy? AddObject(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
    );

    void RemoveObject(ColumnTaxonomy columnTaxonomyObject);

    void SetObject(ColumnTaxonomy columnTaxonomyObject, IReadOnlyDictionary<string, object?> modificationInfo);

    void SetObjectValue(
        ColumnTaxonomy columnTaxonomyObject,
        ListItem listItemObject,
        IEnumerable<Term> termCollection,
        uint lcid
    );

}

public class ColumnTaxonomyService(ClientContext clientContext) : ClientService<ColumnTaxonomy>(clientContext), IColumnTaxonomyService
{

    public ColumnTaxonomy? AddObject(
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ColumnTaxonomy>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ColumnTaxonomy? AddObject(
        List listObject,
        IReadOnlyDictionary<string, object?> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
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
            objectPathId => ClientActionQuery.Create(objectPathId, ClientQuery.Create(true, typeof(Column)))
        );
        return this
            .ClientContext.ProcessQuery(requestPayload)
            .ToObject<ColumnTaxonomy>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObjectValue(
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
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
