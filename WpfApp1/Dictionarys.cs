using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Dictionarys
    {
        //public T Id { get; set; }

        //public string Content { get; set; }

        public static Dictionary<int, string> MemberState { get; set; } = new Dictionary<int, string>
        {
            { 1 , "正常" },
            { 2 , "挂失" },
            { 3 , "注销" },
        };
    }
}
