using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro.DecoratorPattern
{
    public class Decorate : Component
    {
        protected Component component;

        public void SetDecorate(Component component)
        {
            this.component = component;
        }


        public override void Show()
        {
            if (component != null)
            {
                //Console.WriteLine("Decorate");
                component.Show();
            }
        }
    }
}
