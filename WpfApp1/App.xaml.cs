using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //FlurlHttp.Configure(c =>
            //{
            //    //c.OnErrorAsync = HandleErrorAsync;
            //    c.DefaultTimeout = TimeSpan.FromSeconds(5);
            //    c.OnError = HandleError;
            //});
            FlurlHttpConfigure.Configure();
        }

        //public static async Task HandleErrorAsync(HttpCall call)
        //{
        //    //await LogErrorAsync(call.Exception, call.Request.Url.AbsoluteUri);
        //    //call.ExceptionHandled = true; // don't propagate up the exception

        //    if (call.Exception is TimeoutException)
        //    {

        //    }
        //}

        public void HandleError(HttpCall call)
        {
            if (call.Exception is FlurlHttpTimeoutException)
            {
                throw new Exception("网络异常");
                //MessageBox.Show("网络异常");
            }
            else if (call.Exception is TimeoutException)
            {
                //MessageBox.Show("网络异常");  
                throw new Exception("网络异常");
            }
            else if (call.Exception is FlurlHttpException ex)
            {
                if (ex.Call.Response != null)
                    throw new Exception($"Failed with response code {call.Response.StatusCode}");
                //MessageBox.Show($"Failed with response code {call.Response.StatusCode}");
                else
                    throw new Exception($"Totally failed before getting a response! \n{ex.Message}");
                //MessageBox.Show($"Totally failed before getting a response! \n{ex.Message}");
                //return;
            }
            else
            {
                throw new Exception(call.Exception.Message);
                //MessageBox.Show(call.Exception.Message);
                //return;
            }
        }
    }
}
