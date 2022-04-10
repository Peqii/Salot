using System;
using System.Collections.Generic;

#nullable disable

namespace SalotAPI.EF
{
    public partial class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int? Gender { get; set; }
        public int Species { get; set; }
        public string Asdasd { get; set; }
    }
}
