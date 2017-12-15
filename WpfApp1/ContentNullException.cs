using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /// <summary>
    /// 打印内容为空
    /// </summary>
    public class ContentNullException : Exception
    {

        public ContentNullException(string message) : base(message)
        {

        }

        public ContentNullException() : base("打印内容不能为空")
        {

        }

    }
}
