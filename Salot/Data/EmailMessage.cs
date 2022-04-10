using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Data
{
    public class EmailMessage
    {
        public string WebsiteString { get; set; }
       
        public string Menu { get; set; }

        public DayOfWeek DayOfWeek {get; set;}
    }
}
