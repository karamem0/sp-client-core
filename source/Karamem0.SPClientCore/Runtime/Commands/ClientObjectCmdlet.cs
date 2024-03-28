//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using Karamem0.SharePoint.PowerShell.Resources;
using Karamem0.SharePoint.PowerShell.Runtime.ApplicationInsights;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Runtime.Commands;

public abstract class ClientObjectCmdlet : PSCmdlet
{

    protected ClientObjectCmdlet()
    {
        this.Outputs = [];
    }

    protected List<object> Outputs { get; private set; }

    protected override void ProcessRecord()
    {
        var telemetry = TelemetryClientFactory.Create();
        var stopwatch = new Stopwatch();
        if (string.Compare(this.MyInvocation.InvocationName, this.MyInvocation.MyCommand.Name, true) != 0)
        {
            this.WriteWarning(string.Format(
                StringResources.WarningCmdletIsObsolete,
                this.MyInvocation.InvocationName,
                this.MyInvocation.MyCommand.Name));
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
            this.WriteError(new ErrorRecord(ex, "Exception", ErrorCategory.NotSpecified, null));
            telemetry.TrackException(ex);
        }
        finally
        {
            Trace.Listeners.Remove(listener);
            stopwatch.Stop();
            telemetry.GetMetric(this.MyInvocation.InvocationName).TrackValue(stopwatch.ElapsedMilliseconds);
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
                    throw new ArgumentException(
                        string.Format(StringResources.ErrorValueCannotBeValue, false),
                        nameof(parameterName));
                }
            }
        }
    }

}
