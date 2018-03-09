//
// Copyright (c) 2018 karamem0
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

namespace Karamem0.SharePoint.PowerShell.PipeBinds
{

    public abstract class ClientObjectPipeBind<T> : ClientObjectPipeBind where T : ClientObject
    {

        protected ClientObjectPipeBind()
        {
        }

        protected ClientObjectPipeBind(T inputObject)
        {
            if (inputObject == null)
            {
                throw new ArgumentNullException(nameof(inputObject));
            }
            this.ClientObject = inputObject;
        }

        public T ClientObject { get; private set; }

    }

}
