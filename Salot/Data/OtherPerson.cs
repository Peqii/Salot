using Salot.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Data
{
    class OtherPerson : Human
    {
        bool isRelative { get; set; }
        public OtherPerson(Gender gender, string Name, int Age, bool isRelative) : base(gender, Name, Age)
        {
            this.isRelative = isRelative;
        }
    }
}
