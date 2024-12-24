using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Drozhyk_report
{
    public abstract class Person
    {
        // Abstract properties
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }

        // Abstract method to get person details
        public abstract string GetDetails();
    }
}
