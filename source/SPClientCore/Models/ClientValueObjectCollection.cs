//
// Copyright (c) 2018 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/SPClientCore/blob/master/LICENSE
//

using Karamem0.SharePoint.PowerShell.Models.OData;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SharePoint.PowerShell.Models
{

    public class ClientValueObjectCollection<T> : ClientValueObject, IEnumerable<T>
    {

        public ClientValueObjectCollection()
        {
        }

        [JsonConstructor()]
        public ClientValueObjectCollection(T[] results)
        {
            this.Entries = results;
        }

        [JsonProperty("results")]
        public IReadOnlyList<T> Entries { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (this.Entries == null)
            {
                return Enumerable.Empty<T>().GetEnumerator();
            }
            else
            {
                return this.Entries.GetEnumerator();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Entries == null)
            {
                return Enumerable.Empty<T>().GetEnumerator();
            }
            else
            {
                return this.Entries.GetEnumerator();
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

}
