using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MemberHttp
    {
        public static async Task<List<string>> GetMembers()
        {
            string path = "";
            var query = new { };

            return await HttpBase.GetAsync<List<string>>(path, query);
        }

        public static async Task<List<string>> Query()
        {
            return await HttpBase.GetAsync<List<string>>("host-url", "path-url", "query-parameter");
        }

        public static async Task<bool> AddMember(List<string> bodys)
        {
            var query = new { name = "张三", age = 18 };

            return await HttpBase.PostAsync<bool, List<string>>("", bodys, query);
        }

        public static async Task<bool> Update(List<string> bodys)
        {
            return await HttpBase.PostAsync<bool, List<string>>("host-url", "path-url", bodys, null);
        }


    }
}
