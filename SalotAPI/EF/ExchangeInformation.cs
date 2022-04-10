using System;
using System.Collections.Generic;

#nullable disable

namespace SalotAPI.EF
{
    public partial class ExchangeInformation
    {
        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ServiceUrl { get; set; }
        public string TenantId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
