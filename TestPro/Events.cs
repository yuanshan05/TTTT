using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro
{
    public class Events
    {
        public delegate void ShowHandler(string name);

        public event ShowHandler ShowNameEvent;
    }
}
