using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPro
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExceptionFilterAttribute : Attribute
    {

    }
}
