using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro.Factory
{
    public abstract class Base
    {
        public virtual void Show<T>(T value)
        {
            Console.WriteLine(value);
        }
    }
}
