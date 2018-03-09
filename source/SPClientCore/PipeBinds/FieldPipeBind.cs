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

    public class FieldPipeBind : ClientObjectPipeBind<Field>
    {

        public FieldPipeBind(Field inputObject) : base(inputObject)
        {
        }

        public FieldPipeBind(Guid? inputId)
        {
            if (inputId == null)
            {
                throw new ArgumentNullException(nameof(inputId));
            }
            this.Id = inputId;
        }

        public FieldPipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            else if (Guid.TryParse(inputString, out var inputId))
            {
                this.Id = inputId;
            }
            else
            {
                this.Title = inputString;
            }
        }

        public Guid? Id { get; private set; }

        public string Title { get; private set; }

    }

}
