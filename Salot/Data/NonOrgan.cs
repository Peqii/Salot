using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Data
{
    public class NonOrgan : INonOrgans
    {
        public Guid ID { get; set; }
        [JsonIgnore]
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]
        public DateTime ModifiedOn { get; set; }
    }
}
