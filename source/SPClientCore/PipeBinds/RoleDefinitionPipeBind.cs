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

    public class RoleDefinitionPipeBind : ClientObjectPipeBind<RoleDefinition>
    {

        public RoleDefinitionPipeBind(RoleDefinition inputObject) : base(inputObject)
        {
        }

        public RoleDefinitionPipeBind(int? inputId)
        {
            if (inputId == null)
            {
                throw new ArgumentNullException(nameof(inputId));
            }
            this.Id = inputId;
        }

        public RoleDefinitionPipeBind(RoleTypeKind? inputType)
        {
            if (inputType == null)
            {
                throw new ArgumentNullException(nameof(inputType));
            }
            this.Type = inputType;
        }

        public RoleDefinitionPipeBind(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            else if (int.TryParse(inputString, out var inputId))
            {
                this.Id = inputId;
            }
            else if (Enum.TryParse<RoleTypeKind>(inputString, out var inputType))
            {
                this.Type = inputType;
            }
            else
            {
                this.Name = inputString;
            }
        }

        public int? Id { get; private set; }

        public string Name { get; private set; }

        public RoleTypeKind? Type { get; private set; }

    }

}
