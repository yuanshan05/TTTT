using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro.Factory
{
    public class AddFactory : IFactory
    {
        public Operator CreaterOperator()
        {
            return new AddOpeartor();
        }
    }
}
