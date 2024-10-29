//
// Copyright (c) 2018-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/sp-client-core/blob/main/LICENSE
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Tests.Utilities;

public static class PSCmdletExtensions
{

    [DebuggerHidden()]
    public static IEnumerable InvokeCommand(this Runspace runspace, string name, IReadOnlyDictionary<string, object> parameters)
    {
        return runspace.InvokeCommand<object>(name, parameters);
    }

    [DebuggerHidden()]
    public static IEnumerable<T> InvokeCommand<T>(this Runspace runspace, string name, IReadOnlyDictionary<string, object> parameters)
    {
        _ = runspace ?? throw new ArgumentNullException(nameof(runspace));
        _ = name ?? throw new ArgumentNullException(nameof(name));
        _ = parameters ?? throw new ArgumentNullException(nameof(parameters));
        var command = new Command(name);
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
        return outputs.Select(item => item?.BaseObject).Cast<T>();
    }

}
