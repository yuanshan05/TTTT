using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro.DecoratorPattern
{
    public class ConcreteDecorateA : Decorate
    {

        

        public override void Show()
        {
            base.Show();
            Console.WriteLine("ConcreteDecorateA");
        }
    }
}
