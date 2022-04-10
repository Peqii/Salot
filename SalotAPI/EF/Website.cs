using System;
using System.Collections.Generic;

#nullable disable

namespace SalotAPI.EF
{
    public partial class Website
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public bool? Lunch { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
