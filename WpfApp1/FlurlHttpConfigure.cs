using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class FlurlHttpConfigure
    {
        public static void Configure()
        {
            Flurl.Http.FlurlHttp.Configure(c =>
            {
                c.BeforeCall = BeforeCall;
                c.OnError = HandleError;
                c.AfterCallAsync = HandleAfterCallAsync;
            });

            Flurl.Http.FlurlHttp.RaiseEventAsync(new System.Net.Http.HttpRequestMessage()
            {
                Method = System.Net.Http.HttpMethod.Get,
                RequestUri = new Uri("http://api-client-test.fcleyuan/com/api/OparkAdmin/login"),
            }
            , Flurl.Http.FlurlEventType.BeforeCall);
        }

        static async Task HandleAfterCallAsync(Flurl.Http.HttpCall call)
        {
            string str = await call.Response.Content.ReadAsStringAsync();

            JsonModel<object> rs = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonModel<object>>(str);

            if (rs.Code != 0)
            {
                //TODO: 写日志
                Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n请求路径：{call.Request.RequestUri.ToString()}\t请求方法：{call.Request.Method.ToString()}\t请求内容:{call.Request.Content?.ToString()}");
            }
        }

        static void BeforeCall(Flurl.Http.HttpCall call)
        {
            call.Request.Headers.Add("token", "vvv");
        }

        static void HandleError(Flurl.Http.HttpCall call)
        {
            Console.WriteLine($"HttpStatusCode:{call.HttpStatus}---{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            Console.WriteLine($"ExceptionMessage:{call.Exception.Message}");

            if (call.HttpStatus == System.Net.HttpStatusCode.RequestTimeout)
                throw new Exception("网络超时");

            if (call.HttpStatus == System.Net.HttpStatusCode.GatewayTimeout)
                throw new Exception("网络超时");

            if (call.Exception is Flurl.Http.FlurlHttpTimeoutException)
                throw new Exception("网络异常");
            else if (call.Exception is TimeoutException)
                throw new Exception("网络异常");
            else if (call.Exception is Flurl.Http.FlurlHttpException ex)
            {
                Console.WriteLine($"异常信息：{ex.Message}");
                //if (ex.Call.Response != null)
                //    throw new Exception($"Failed with response code {call.Response.StatusCode}");
                //else
                //    throw new Exception($"Totally failed before getting a response! \n{ex.Message}");
            }
            else
                throw new Exception("网络异常");
            //throw new Exception(call.Exception.Message);
        }
    }
}
