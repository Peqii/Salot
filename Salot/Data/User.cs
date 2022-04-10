using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Salot.Data
{
    
    public class User : NonOrgan
    {
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Password")]
        
        public string Password { get; set; }
        [JsonProperty("Phone")] 
        public string Phone { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid? HumanID { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string UserId { get; set; }

    }
}
