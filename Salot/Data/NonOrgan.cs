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
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime CreatedOn { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime ModifiedOn { get; set; }
    }
}
