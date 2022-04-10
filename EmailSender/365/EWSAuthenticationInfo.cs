using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender._365
{
    public class EWSAuthenticationInfo
    {

        public EWSAuthenticationInfo() { }

        public string ExchangeServiceUrl { get; set; }
        public string ExchangeUsername { get; set; }
        public string ExchangeClientId { get; set; }
        public string ExchangeTenantId { get; set; }
        public string ExchangeClientSecret { get; set; }
        public string ExchangeUserPassword { get; set; }
        
    }
}
