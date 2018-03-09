//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Services
{

    public abstract class ClientObjectService
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Register(ClientContext clientContext)
        {
            ClientObjectService.ServiceProvider = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsSubclassOf(typeof(ClientObjectService)))
                .Aggregate<Type, IServiceCollection>(
                    new ServiceCollection(), 
                    (accumulate, source) => accumulate.AddTransient(source.GetInterfaces()[0], source))
                .AddSingleton(typeof(ClientContext), clientContext)
                .BuildServiceProvider();
        }

        protected ClientObjectService(ClientContext clientContext)
        {
            if (clientContext == null)
            {
                throw new ArgumentNullException(nameof(clientContext));
            }
            this.ClientContext = clientContext;
        }

        protected ClientContext ClientContext { get; private set; }

    }

}
