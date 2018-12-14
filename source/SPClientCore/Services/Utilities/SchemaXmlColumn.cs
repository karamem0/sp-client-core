//
// Copyright (c) 2019 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Karamem0.SharePoint.PowerShell.Services.Utilities
{

    public static class SchemaXmlColumn
    {

        public static string Create(ColumnType type, IReadOnlyDictionary<string, object> parameters)
        {
            return SchemaXmlColumn.Create(new XElement("Field", new XAttribute("Type", new SchemaXmlValue(type))), parameters);
        }

        public static string Create(string text, IReadOnlyDictionary<string, object> parameters)
        {
            return SchemaXmlColumn.Create(XElement.Parse(text), parameters);
        }

        public static string Create(XElement element, IReadOnlyDictionary<string, object> parameters)
        {
            foreach (var parameter in parameters)
            {
                switch (parameter.Key)
                {
                    case "AllowMultipleValues":
                        element.SetAttributeValue("Mult", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "CalendarType":
                        var value = parameter.Value as CalendarType?;
                        if (value != null)
                        {
                            element.SetAttributeValue("CalType", new SchemaXmlValue((int)value.GetValueOrDefault()));
                        }
                        continue;
                    case "ChoiceFormat":
                        element.SetAttributeValue("Format", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Choices":
                        var choices = parameter.Value as IEnumerable<string>;
                        if (choices != null)
                        {
                            element.Add(new XElement("CHOICES",
                                choices.Select(choice => new XElement("CHOICE", new SchemaXmlValue(choice)))));
                        }
                        continue;
                    case "ClientSideComponentId":
                        element.SetAttributeValue("ClientSideComponentId", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "ClientSideComponentProperties":
                        element.SetAttributeValue("ClientSideComponentProperties", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Columns":
                        var columns = parameter.Value as IEnumerable<Column>;
                        if (columns != null)
                        {
                            element.Add(new XElement("FieldRefs",
                                columns.Select(column => new XElement("FieldRef",
                                    new XAttribute("ID", new SchemaXmlValue(column.Id)),
                                    new XAttribute("Name", new SchemaXmlValue(column.Name))))));
                        }
                        continue;
                    case "CurrencyLcid":
                        element.SetAttributeValue("LCID", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "CustomFormatter":
                        element.SetAttributeValue("CustomFormatter", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "DateFormat":
                        element.SetAttributeValue("Format", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "DefaultFormula":
                        element.SetElementValue("DefaultFormula", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "DefaultValue":
                        element.SetElementValue("Default", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Description":
                        element.SetAttributeValue("Description", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Direction":
                        element.SetAttributeValue("Direction", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "EnforceUniqueValues":
                        element.SetAttributeValue("EnforceUniqueValues", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "FillInChoice":
                        element.SetAttributeValue("FillInChoice", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Formula":
                        element.SetElementValue("Formula", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "FriendlyFormat":
                        element.SetAttributeValue("FriendlyDisplayFormat", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Group":
                        element.SetAttributeValue("Group", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Hidden":
                        element.SetAttributeValue("CanToggleHidden", new SchemaXmlValue(parameter.Value));
                        element.SetAttributeValue("Hidden", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Id":
                        element.SetAttributeValue("ID", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Indexed":
                        element.SetAttributeValue("Indexed", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "JSLink":
                        element.SetAttributeValue("JSLink", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "MaxLength":
                        element.SetAttributeValue("Max", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "MaxValue":
                        element.SetAttributeValue("Max", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "MinValue":
                        element.SetAttributeValue("Min", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "LookupColumnName":
                        element.SetAttributeValue("ShowField", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "LookupListId":
                        element.SetAttributeValue("List", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Name":
                        element.SetAttributeValue("Name", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "NoCrawl":
                        element.SetAttributeValue("NoCrawl", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "NumberFormat":
                        element.SetAttributeValue("Decimals", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "NumberOfLines":
                        element.SetAttributeValue("NumLines", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "OutputType":
                        element.SetAttributeValue("ResultType", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "ReadOnly":
                        element.SetAttributeValue("ReadOnly", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "RelationshipDeleteBehavior":
                        element.SetAttributeValue("RelationshipDeleteBehavior", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Required":
                        element.SetAttributeValue("Required", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "RestrictedMode":
                        element.SetAttributeValue("RestrictedMode", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "RichText":
                        element.SetAttributeValue("RichText", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "RichTextMode":
                        element.SetAttributeValue("RichTextMode", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "SelectionGroupId":
                        element.SetAttributeValue("UserSelectionScope", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "SelectionMode":
                        element.SetAttributeValue("UserSelectionMode", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "ShowAsPercentage":
                        element.SetAttributeValue("Percentage", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "StaticName":
                        element.SetAttributeValue("StaticName", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "Title":
                        element.SetAttributeValue("DisplayName", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "UnlimitedLengthInDocumentLibrary":
                        element.SetAttributeValue("UnlimitedLengthInDocumentLibrary", new SchemaXmlValue(parameter.Value));
                        continue;
                    case "UrlFormat":
                        element.SetAttributeValue("Format", new SchemaXmlValue(parameter.Value));
                        continue;
                    default:
                        continue;
                }
            }
            return element.ToString(SaveOptions.DisableFormatting);
        }

    }

}
