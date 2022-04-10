using System;
using System.Collections.Generic;

#nullable disable

namespace SalotAPI.EF
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Guid? HumanId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Salt { get; set; }
    }
}
