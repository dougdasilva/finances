using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyFinances.Entities
{
    class Performance
    {
        public string Name { get; set; }

        public Performance()
        {

        }
        public Performance(string name)
        {
            Name = name;
        }
    }
}
