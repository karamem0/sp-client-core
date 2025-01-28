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

    ColumnTaxonomy AddObject(
        IReadOnlyDictionary<string, object> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
    );

    ColumnTaxonomy AddObject(
        List listObject,
        IReadOnlyDictionary<string, object> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
    );

    void RemoveObject(ColumnTaxonomy columnTaxonomyObject);

    void SetObject(ColumnTaxonomy columnTaxonomyObject, IReadOnlyDictionary<string, object> modificationInfo);

    void SetObjectValue(
        ColumnTaxonomy columnTaxonomyObject,
        ListItem listItemObject,
        IEnumerable<Term> termCollection,
        uint lcid
    );

}

public class ColumnTaxonomyService(ClientContext clientContext)
    : ClientService<ColumnTaxonomy>(clientContext), IColumnTaxonomyService
{

    public ColumnTaxonomy AddObject(
        IReadOnlyDictionary<string, object> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
    )
    {
        _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathStaticProperty(typeof(Context), "Current"));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Web"));
        var objectPath3 = requestPayload.Add(new ObjectPathProperty(objectPath2.Id, "Fields"));
        var objectPath4 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath3.Id,
                "AddFieldAsXml",
                requestPayload.CreateParameter(
                    SchemaXmlColumn.Create(
                        new XElement("Field", new XAttribute("Type", "TaxonomyFieldType")),
                        creationInfo
                    )
                ),
                requestPayload.CreateParameter(addToDefaultView),
                requestPayload.CreateParameter(addColumnOptions)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(Column))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ColumnTaxonomy>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public ColumnTaxonomy AddObject(
        List listObject,
        IReadOnlyDictionary<string, object> creationInfo,
        bool addToDefaultView,
        AddColumnOptions addColumnOptions
    )
    {
        _ = listObject ?? throw new ArgumentNullException(nameof(listObject));
        _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(listObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathProperty(objectPath1.Id, "Fields"));
        var objectPath3 = requestPayload.Add(
            new ObjectPathMethod(
                objectPath2.Id,
                "AddFieldAsXml",
                requestPayload.CreateParameter(
                    SchemaXmlColumn.Create(
                        new XElement("Field", new XAttribute("Type", "TaxonomyFieldType")),
                        creationInfo
                    )
                ),
                requestPayload.CreateParameter(addToDefaultView),
                requestPayload.CreateParameter(addColumnOptions)
            ),
            objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
            objectPathId => new ClientActionQuery(objectPathId)
            {
                Query = new ClientQuery(true, typeof(Column))
            }
        );
        return this.ClientContext.ProcessQuery(requestPayload)
            .ToObject<ColumnTaxonomy>(requestPayload.GetActionId<ClientActionQuery>());
    }

    public void SetObjectValue(
        ColumnTaxonomy columnTaxonomyObject,
        ListItem listItemObject,
        IEnumerable<Term> termCollection,
        uint lcid
    )
    {
        _ = columnTaxonomyObject ?? throw new ArgumentNullException(nameof(columnTaxonomyObject));
        _ = listItemObject ?? throw new ArgumentNullException(nameof(listItemObject));
        _ = termCollection ?? throw new ArgumentNullException(nameof(termCollection));
        var requestPayload = new ClientRequestPayload();
        var objectPath1 = requestPayload.Add(new ObjectPathIdentity(columnTaxonomyObject.ObjectIdentity));
        var objectPath2 = requestPayload.Add(new ObjectPathIdentity(listItemObject.ObjectIdentity));
        var objectPath3 = requestPayload.Add(
            objectPath1,
            objectPathId => new ClientActionMethod(
                objectPathId,
                "SetFieldValueByCollection",
                requestPayload.CreateParameter(objectPath2),
                requestPayload.CreateParameter(termCollection),
                requestPayload.CreateParameter(lcid)
            )
        );
        var objectPath4 = requestPayload.Add(
            objectPath2,
            objectPathId => new ClientActionMethod(objectPathId, "Update")
        );
        _ = this.ClientContext.ProcessQuery(requestPayload);
    }

}
