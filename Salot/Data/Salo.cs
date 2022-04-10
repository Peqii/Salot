using Salot.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Data
{
    class Salo : Human
    {
        bool Grandparent { get; set; }

        public Salo(Gender gender, string Name, int Age) : base(gender, Name, Age)
        {
        }
    }
}
