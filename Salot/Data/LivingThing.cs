using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Data
{
    public class LivingThing : ILivingThings<LivingThing>
    {
        [JsonProperty("Name")]  
        public string Name { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        [JsonIgnore]
        public DateTime CreatedOn { get; set; }
        [JsonIgnore]    
        public DateTime ModifiedOn { get; set; }
        [JsonIgnore]
        public Guid ID { get; set; }
    }
}
