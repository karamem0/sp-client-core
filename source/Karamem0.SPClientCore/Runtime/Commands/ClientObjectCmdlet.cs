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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Commands;

public abstract class ClientObjectCmdlet : PSCmdlet
{

    protected List<object?> Outputs { get; private set; } = [];

    protected override void ProcessRecord()
    {
        var telemetry = TelemetryClientFactory.Create();
        var stopwatch = new Stopwatch();
        if (string.Compare(
                this.MyInvocation.InvocationName,
                this.MyInvocation.MyCommand.Name,
                true
            ) !=
            0)
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

public abstract class ClientObjectCmdlet<T> : ClientObjectCmdlet
{

    private T? service;

    protected override void BeginProcessing()
    {
        if (ClientService.ServiceProvider is null)
        {
            throw new InvalidOperationException(StringResources.ErrorNotConnected);
        }
        this.service = ClientService.ServiceProvider.GetService<T>();
    }

    protected T Service => this.service ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);

}

public abstract class ClientObjectCmdlet<T1, T2> : ClientObjectCmdlet
{

    private T1? service1;

    private T2? service2;

    protected override void BeginProcessing()
    {
        if (ClientService.ServiceProvider is null)
        {
            throw new InvalidOperationException(StringResources.ErrorNotConnected);
        }
        this.service1 = ClientService.ServiceProvider.GetService<T1>();
        this.service2 = ClientService.ServiceProvider.GetService<T2>();
    }

    protected T1 Service1 => this.service1 ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);

    protected T2 Service2 => this.service2 ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);

}

public abstract class ClientObjectCmdlet<T1, T2, T3> : ClientObjectCmdlet
{

    private T1? service1;

    private T2? service2;

    private T3? service3;

    protected override void BeginProcessing()
    {
        if (ClientService.ServiceProvider is null)
        {
            throw new InvalidOperationException(StringResources.ErrorNotConnected);
        }
        this.service1 = ClientService.ServiceProvider.GetService<T1>();
        this.service2 = ClientService.ServiceProvider.GetService<T2>();
        this.service3 = ClientService.ServiceProvider.GetService<T3>();
    }

    protected T1 Service1 => this.service1 ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);

    protected T2 Service2 => this.service2 ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);

    protected T3 Service3 => this.service3 ?? throw new InvalidOperationException(StringResources.ErrorValueCannotBeNull);

}
