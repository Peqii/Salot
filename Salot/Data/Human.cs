using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Salot.Data.Enums;
namespace Salot.Data
{
    public class Human : LivingThing
    {
        Gender gender { get; set; }

        public Human()
        {

        }
        public Human(Gender gender, string Name, int Age)
        {
            this.gender = gender;
            this.Name = Name;
            this.Age = Age;
        }
    }
}
