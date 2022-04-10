using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Salot.Data.Enums;

namespace Salot.Data
{
    interface ILivingThings<T> : IDatarecordBase  where T : class 
    {
        string Name { get; set; }

        int Age { get; set; }
        [JsonIgnore]
        DateTime CreatedOn { get; set; }
        [JsonIgnore]
        DateTime ModifiedOn { get; set; }
        [JsonIgnore]
        Guid ID { get; set; }
    }
}
