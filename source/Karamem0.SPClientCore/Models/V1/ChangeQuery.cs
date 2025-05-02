//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models.V1;

[ClientObject(Name = "SP.ChangeQuery", Id = "{887a7218-1232-4cfc-b78f-88d54e9d8ec7}")]
[JsonObject()]
public class ChangeQuery : ClientValueObject
{

    public ChangeQuery(IReadOnlyDictionary<string, object?> parameters)
    {
        var flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public;
        foreach (var parameter in parameters)
        {
            switch (parameter.Key)
            {
                case "BeginToken":
                    this.BeginChangeToken = (ChangeToken)parameter.Value;
                    break;
                case "EndToken":
                    this.EndChangeToken = (ChangeToken)parameter.Value;
                    break;
                case "FetchLimit":
                    this.FetchLimit = (long)parameter.Value;
                    break;
                case "LatestFirst":
                    this.LatestFirst = (bool)parameter.Value;
                    break;
                case "Objects":
                    var objects = (ChangeObjects)parameter.Value;
                    foreach (var e in Enum
                                 .GetValues(typeof(ChangeObjects))
                                 .Cast<Enum>()
                                 .Where(objects.HasFlag))
                    {
                        var property = this
                            .GetType()
                            .GetProperty(Enum.GetName(typeof(ChangeObjects), e), flags);
                        property?.SetValue(this, true);
                    }
                    break;
                case "Operations":
                    var operations = (ChangeOperations)parameter.Value;
                    foreach (var e in Enum
                                 .GetValues(typeof(ChangeOperations))
                                 .Cast<Enum>()
                                 .Where(operations.HasFlag))
                    {
                        var property = this
                            .GetType()
                            .GetProperty(Enum.GetName(typeof(ChangeOperations), e), flags);
                        property?.SetValue(this, true);
                    }
                    break;
                case "RecursiveAll":
                    this.RecursiveAll = (bool)parameter.Value;
                    break;
                default:
                    break;
            }
        }
    }

    [JsonProperty()]
    public virtual bool Activity { get; set; }

    [JsonProperty()]
    public virtual bool Add { get; set; }

    [JsonProperty()]
    public virtual bool Alert { get; set; }

    [JsonProperty("ChangeTokenStart")]
    public virtual ChangeToken? BeginChangeToken { get; set; }

    [JsonProperty("Field")]
    public virtual bool Column { get; set; }

    [JsonProperty()]
    public virtual bool ContentType { get; set; }

    [JsonProperty()]
    public virtual bool DeleteObject { get; set; }

    [JsonProperty("ChangeTokenEnd")]
    public virtual ChangeToken? EndChangeToken { get; set; }

    [JsonProperty()]
    public virtual long FetchLimit { get; set; }

    [JsonProperty()]
    public virtual bool File { get; set; }

    [JsonProperty()]
    public virtual bool Folder { get; set; }

    [JsonProperty()]
    public virtual bool Group { get; set; }

    [JsonProperty()]
    public virtual bool GroupMembershipAdd { get; set; }

    [JsonProperty()]
    public virtual bool GroupMembershipDelete { get; set; }

    [JsonProperty()]
    public virtual bool Item { get; set; }

    [JsonProperty()]
    public virtual bool LatestFirst { get; set; }

    [JsonProperty()]
    public virtual bool List { get; set; }

    [JsonProperty()]
    public virtual bool Move { get; set; }

    [JsonProperty()]
    public virtual bool Navigation { get; set; }

    [JsonProperty()]
    public virtual bool RecursiveAll { get; set; }

    [JsonProperty()]
    public virtual bool Rename { get; set; }

    [JsonProperty()]
    public virtual bool RequireSecurityTrim { get; set; }

    [JsonProperty()]
    public virtual bool Restore { get; set; }

    [JsonProperty()]
    public virtual bool RoleAssignmentAdd { get; set; }

    [JsonProperty()]
    public virtual bool RoleAssignmentDelete { get; set; }

    [JsonProperty()]
    public virtual bool RoleDefinitionAdd { get; set; }

    [JsonProperty()]
    public virtual bool RoleDefinitionDelete { get; set; }

    [JsonProperty()]
    public virtual bool RoleDefinitionUpdate { get; set; }

    [JsonProperty()]
    public virtual bool SecurityPolicy { get; set; }

    [JsonProperty("Web")]
    public virtual bool Site { get; set; }

    [JsonProperty("Site")]
    public virtual bool SiteCollection { get; set; }

    [JsonProperty()]
    public virtual bool SystemUpdate { get; set; }

    [JsonProperty()]
    public virtual bool Update { get; set; }

    [JsonProperty()]
    public virtual bool User { get; set; }

    [JsonProperty()]
    public virtual bool View { get; set; }

}
