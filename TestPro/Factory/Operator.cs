using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro.Factory
{
    public abstract class Operator
    {
        public double FirstNumber { get; set; }

        public double SecondNumber { get; set; }

        public abstract double GetResult();

    }
}
