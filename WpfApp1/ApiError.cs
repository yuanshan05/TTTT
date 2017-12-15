using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ApiError
    {
        public string Id { get; set; }

        public DateTime CTime { get; set; } = DateTime.Now;

        public string RequestUri { get; set; }

        public ErrorType Type { get; set; }
    }

    public enum ErrorType
    {
        BusinessLogic, //业务逻辑错误
        Exception, //异常错误
    }
}
