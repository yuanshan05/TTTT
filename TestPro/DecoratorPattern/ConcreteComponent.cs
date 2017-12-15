using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro.DecoratorPattern
{
    public class ConcreteComponent : Component
    {
        protected string name;
        public ConcreteComponent(string name)
        {
            this.name = name;
        }

        public override void Show()
        {
            Console.WriteLine($"输出{this.name}");
        }
    }
}
