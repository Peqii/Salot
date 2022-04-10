using System;
using System.Collections.Generic;

#nullable disable

namespace SalotAPI.EF
{
    public partial class Human
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool? IsRelative { get; set; }
        public bool? Grandparent { get; set; }
        public int? Gender { get; set; }
    }
}
