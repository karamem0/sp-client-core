//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.V1;
using Karamem0.SharePoint.PowerShell.Runtime.Models;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services.V1
{

    public interface ITenantThemeService
    {

        bool AddObject(string themeName, IReadOnlyDictionary<string, object> creationInfo);

        TenantTheme GetObject(TenantTheme themeObject);

        TenantTheme GetObject(string themeName);

        IEnumerable<TenantTheme> GetObjectEnumerable();

        void RemoveObject(TenantTheme themeObject);

        void RemoveObject(string themeName);

        bool SetObject(TenantTheme themeObject, IReadOnlyDictionary<string, object> modificationInfo);

        bool SetObject(string themeName, IReadOnlyDictionary<string, object> modificationInfo);

    }

    public class TenantThemeService : ClientService, ITenantThemeService
    {

        public TenantThemeService(ClientContext clientContext) : base(clientContext)
        {
        }

        public bool AddObject(string themeName, IReadOnlyDictionary<string, object> creationInfo)
        {
            _ = themeName ?? throw new ArgumentNullException(nameof(themeName));
            _ = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "AddTenantTheme",
                    requestPayload.CreateParameter(themeName),
                    requestPayload.CreateParameter(JsonConvert.SerializeObject(new TenantThemeCreationInfo(creationInfo)))));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<bool>(requestPayload.GetActionId<ClientActionMethod>());
        }

        public TenantTheme GetObject(TenantTheme themeObject)
        {
            _ = themeObject ?? throw new ArgumentNullException(nameof(themeObject));
            return this.GetObject(themeObject.Name);
        }

        public TenantTheme GetObject(string themeName)
        {
            _ = themeName ?? throw new ArgumentNullException(nameof(themeName));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(
                    objectPath1.Id,
                    "GetTenantTheme",
                    requestPayload.CreateParameter(themeName)),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = new ClientQuery(true, typeof(TenantTheme))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantTheme>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public IEnumerable<TenantTheme> GetObjectEnumerable()
        {
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                new ObjectPathMethod(objectPath1.Id, "GetAllTenantThemes"),
                objectPathId => new ClientActionInstantiateObjectPath(objectPathId),
                objectPathId => new ClientActionQuery(objectPathId)
                {
                    Query = ClientQuery.Empty,
                    ChildItemQuery = new ClientQuery(true, typeof(TenantTheme))
                });
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<TenantThemeEnumerable>(requestPayload.GetActionId<ClientActionQuery>());
        }

        public void RemoveObject(TenantTheme themeObject)
        {
            _ = themeObject ?? throw new ArgumentNullException(nameof(themeObject));
            this.RemoveObject(themeObject.Name);
        }

        public void RemoveObject(string themeName)
        {
            _ = themeName ?? throw new ArgumentNullException(nameof(themeName));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "DeleteTenantTheme",
                    requestPayload.CreateParameter(themeName)));
            _ = this.ClientContext.ProcessQuery(requestPayload);
        }

        public bool SetObject(TenantTheme themeObject, IReadOnlyDictionary<string, object> modificationInfo)
        {
            _ = themeObject ?? throw new ArgumentNullException(nameof(themeObject));
            return this.SetObject(themeObject.Name, modificationInfo);
        }

        public bool SetObject(string themeName, IReadOnlyDictionary<string, object> modificationInfo)
        {
            _ = themeName ?? throw new ArgumentNullException(nameof(themeName));
            _ = modificationInfo ?? throw new ArgumentNullException(nameof(modificationInfo));
            var requestPayload = new ClientRequestPayload();
            var objectPath1 = requestPayload.Add(
                new ObjectPathConstructor(typeof(Tenant)));
            var objectPath2 = requestPayload.Add(
                objectPath1,
                objectPathId => new ClientActionMethod(
                    objectPathId,
                    "UpdateTenantTheme",
                    requestPayload.CreateParameter(themeName),
                    requestPayload.CreateParameter(JsonConvert.SerializeObject(new TenantThemeCreationInfo(modificationInfo)))));
            return this.ClientContext
                .ProcessQuery(requestPayload)
                .ToObject<bool>(requestPayload.GetActionId<ClientActionMethod>());
        }

    }

}
