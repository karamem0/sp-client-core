//
// Copyright (c) 2018-2025 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace Karamem0.SharePoint.PowerShell.Test.Utility;

public static class PSCmdletExtensions
{

    [DebuggerHidden()]
    public static IReadOnlyList<object> InvokeCommand(
        this Runspace runspace,
        string name,
        IReadOnlyDictionary<string, object> parameters
    )
    {
        return runspace.InvokeCommand<object>(name, parameters);
    }

    [DebuggerHidden()]
    public static IReadOnlyList<T> InvokeCommand<T>(
        this Runspace runspace,
        string name,
        IReadOnlyDictionary<string, object> parameters
    )
    {
        var command = new Command(name);
        runspace.SessionStateProxy.PSVariable.Set("ConfirmPreference", "None");
        foreach (var parameter in parameters)
        {
            command.Parameters.Add(parameter.Key, parameter.Value);
        }
        var pipeline = runspace.CreatePipeline();
        pipeline.Commands.Add(command);
        var outputs = pipeline.Invoke();
        if (pipeline.HadErrors)
        {
            var psObject = pipeline.Error.Read() as PSObject;
            var errorRecord = psObject.BaseObject as ErrorRecord;
            throw errorRecord.Exception;
        }
        return outputs
            .Select(item => item?.BaseObject)
            .Cast<T>()
            .ToList()
            .AsReadOnly();
    }

}
