//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.ApplicationInsights;

public static class TelemetryClientFactory
{

    private static readonly IReadOnlyCollection<string> trueStrings = ["1", "true", "yes"];

    private static readonly Lazy<TelemetryClient> instance = new(() =>
    {
        var location = Assembly.GetExecutingAssembly().Location;
        var config = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(location))
            .AddJsonFile("SPClientCore.config.json")
            .AddEnvironmentVariables()
            .Build();
        var services = new ServiceCollection()
            .AddSingleton(provider =>
            {
                var options = new TelemetryConfiguration();
                var connectionString = config["APPLICATIONINSIGHTS_CONNECTION_STRING"];
                if (string.IsNullOrEmpty(connectionString))
                {
                }
                else
                {
                    options.ConnectionString = connectionString;
                }
                var optout1 = config["POWERSHELL_TELEMETRY_OPTOUT"];
                if (trueStrings.Any(item => string.Compare(item, optout1, true) == 0))
                {
                    options.DisableTelemetry = true;
                }
                var optout2 = config["SPCLIENTCORE_TELEMETRY_OPTOUT"];
                if (trueStrings.Any(item => string.Compare(item, optout2, true) == 0))
                {
                    options.DisableTelemetry = true;
                }
                return options;
            })
            .AddSingleton<ITelemetryChannel, InMemoryChannel>()
            .AddSingleton<TelemetryClient>()
            .BuildServiceProvider();
        return services.GetService<TelemetryClient>();
    });

    public static TelemetryClient Create()
    {
        return instance.Value;
    }

}
