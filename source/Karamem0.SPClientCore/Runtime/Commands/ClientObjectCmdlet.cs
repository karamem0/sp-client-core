//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.ApplicationInsights;
using Karamem0.SharePoint.PowerShell.Runtime.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Management.Automation;

namespace Karamem0.SharePoint.PowerShell.Runtime.Commands;

public abstract class ClientObjectCmdlet : PSCmdlet
{

    protected List<object?> Outputs { get; private set; } = [];

    protected override void ProcessRecord()
    {
        var telemetry = TelemetryClientFactory.Create();
        var stopwatch = new Stopwatch();
        if (string.Equals(
                this.MyInvocation.InvocationName,
                this.MyInvocation.MyCommand.Name,
                StringComparison.InvariantCultureIgnoreCase
            ))
        {
        }
        else
        {
            this.WriteWarning(
                string.Format(
                    StringResources.WarningCmdletIsObsolete,
                    this.MyInvocation.InvocationName,
                    this.MyInvocation.MyCommand.Name
                )
            );
        }
        var listener = Trace.Listeners[Trace.Listeners.Add(new ClientObjectCmdletTraceListener(this))];
        try
        {
            stopwatch.Start();
            this.Outputs.Clear();
            this.ProcessRecordCore();
            listener.Flush();
            this.WriteObject(this.Outputs, true);
        }
        catch (PipelineStoppedException)
        {
            listener.Flush();
            throw;
        }
        catch (Exception ex)
        {
            listener.Flush();
            this.WriteError(
                new ErrorRecord(
                    ex,
                    "Exception",
                    ErrorCategory.NotSpecified,
                    null
                )
            );
            telemetry.TrackException(ex);
        }
        finally
        {
            Trace.Listeners.Remove(listener);
            stopwatch.Stop();
            telemetry
                .GetMetric(this.MyInvocation.InvocationName)
                .TrackValue(stopwatch.ElapsedMilliseconds);
        }
    }

    protected abstract void ProcessRecordCore();

    public void ValidateSwitchParameter(string parameterName)
    {
        if (this.MyInvocation.BoundParameters.TryGetValue(parameterName, out var parameterValue))
        {
            if (parameterValue is SwitchParameter switchParameter)
            {
                if (switchParameter ? false : true)
                {
                    throw new ArgumentException(string.Format(StringResources.ErrorValueCannotBeValue, false), nameof(parameterName));
                }
            }
        }
    }

}

public abstract class ClientObjectCmdlet<T> : ClientObjectCmdlet where T : notnull
{

    protected override void BeginProcessing()
    {
        if (ClientService.ServiceProvider is null)
        {
            throw new InvalidOperationException(StringResources.ErrorNotConnected);
        }
        this.Service = ClientService.ServiceProvider.GetRequiredService<T>();
    }

    protected T Service
    {
        get => field ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        private set;
    }

}

public abstract class ClientObjectCmdlet<T1, T2> : ClientObjectCmdlet where T1 : notnull where T2 : notnull
{

    protected override void BeginProcessing()
    {
        if (ClientService.ServiceProvider is null)
        {
            throw new InvalidOperationException(StringResources.ErrorNotConnected);
        }
        this.Service1 = ClientService.ServiceProvider.GetRequiredService<T1>();
        this.Service2 = ClientService.ServiceProvider.GetRequiredService<T2>();
    }

    protected T1 Service1
    {
        get => field ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        private set;
    }

    protected T2 Service2
    {
        get => field ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        private set;
    }

}

public abstract class ClientObjectCmdlet<T1, T2, T3> : ClientObjectCmdlet where T1 : notnull where T2 : notnull where T3 : notnull
{

    protected override void BeginProcessing()
    {
        if (ClientService.ServiceProvider is null)
        {
            throw new InvalidOperationException(StringResources.ErrorNotConnected);
        }
        this.Service1 = ClientService.ServiceProvider.GetRequiredService<T1>();
        this.Service2 = ClientService.ServiceProvider.GetRequiredService<T2>();
        this.Service3 = ClientService.ServiceProvider.GetRequiredService<T3>();
    }

    protected T1 Service1
    {
        get => field ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        private set;
    }

    protected T2 Service2
    {
        get => field ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        private set;
    }

    protected T3 Service3
    {
        get => field ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);
        private set;
    }

}
