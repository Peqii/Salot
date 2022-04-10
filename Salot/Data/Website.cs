using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Data
{
    public class Website : NonOrgan
    {
        public Website()
        {

        }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("lunch")]
        public bool? Lunch { get; set; }
        public Guid? UserId { get; set; }
    }
    public class WebsiteData
    {
        public string LunchMenuFromWebsite { get; set; }
        public string RestaurantName { get; set; }
    }
}
