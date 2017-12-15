using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using System.Configuration;

namespace WpfApp1
{
    public class HttpBase
    {
        public const string Url = "http://localhost:1813";

        public static string HostUrl { get; private set; } = ConfigurationManager.AppSettings["HttpServiceUrl"];

        public const string Exception = "/api/test/TestBuniessException";

        public const string TimeOut = "/api/test/TimeoutException";

        public static string OparkGoods_list = "/api/GoodsType/{0}/QueryList";

        public static string FlurlConfigString = "/api/test/TestFlurlConfig";

        public static string QueryOparkMemberCoupon = "/api/test/QueryOparkMemberCoupon/{0}";

        public static async Task<string> Buniess()
        {

            var result = await Url.AppendPathSegment(Exception)
                .GetAsync()
                .ReceiveJson<JsonModel<string>>();

            if (result.Code != 0)
                throw new System.Exception(result.Message);

            return result.Data;

        }

        public static async Task<bool> TimeOutFuns()
        {
            var result = await Url.AppendPathSegment(TimeOut).GetAsync().ReceiveJson<JsonModel<bool>>();

            if (result.Code != 0)
                throw new System.Exception(result.Message);

            return result.Data;
        }

        public static async Task<List<object>> QueryList(long? oparkid = null)
        {
            var rs = await HostUrl
                          .AppendPathSegment(string.Format(OparkGoods_list, oparkid))
                          .GetAsync()
                          .ReceiveJson<JsonModel<List<object>>>();

            if (rs.Code != 0)
                throw new Exception(rs.Message);

            return rs.Data;

        }

        public static async Task<List<OparkMemberCouponSimple>> QueryCouon(long oparkid)
        {
            var rt = await Url.AppendPathSegment(string.Format(QueryOparkMemberCoupon, oparkid))
                .GetAsync().ReceiveJson<JsonModel<List<OparkMemberCouponSimple>>>();

            if (rt.Code != 0)
                throw new System.Exception(rt.Message);

            return rt.Data;
        }

        public static async Task<string> FlurlConfig()
        {
            var rs = await HostUrl.AppendPathSegment(FlurlConfigString).GetAsync().ReceiveJson<JsonModel<string>>();

            if (rs.Code != 0)
                throw new System.Exception(rs.Message);

            return rs.Data;

        }

        public HttpBase()
        {
            FlurlHttp.Configure(config =>
            {
                config.BeforeCall = BeforeCall;


            });
        }

        public static async Task<T> GetAsync<T>(string path, object query = null)
        {
            var rs = await HostUrl.AppendPathSegment(path)
                                  .SetQueryParams(query)
                                  .GetAsync()
                                  .ReceiveJson<JsonModel<T>>();

            if (rs.Code != 0)
                throw new System.Exception(rs.Message);

            return rs.Data;
        }

        public static async Task<T> GetAsync<T>(string host, string path, object query = null)
        {
            var rs = await host.AppendPathSegment(path)
                               .SetQueryParams(query)
                               .GetAsync()
                               .ReceiveJson<JsonModel<T>>();

            if (rs.Code != 0)
                throw new System.Exception(rs.Message);

            return rs.Data;
        }

        public static async Task<TOut> PostAsync<TOut, TBody>(string path, TBody body, object query = null)
        {
            var rs = await HostUrl.AppendPathSegment(path)
                                  .SetQueryParams(query)
                                  .PostJsonAsync(body)
                                  .ReceiveJson<JsonModel<TOut>>();

            if (rs.Code != 0)
                throw new System.Exception(rs.Message);

            return rs.Data;

        }

        public static async Task<TOut> PostAsync<TOut, TBody>(string host, string path, TBody body, object query = null)
        {
            if (string.IsNullOrWhiteSpace(host))
                throw new System.Exception("HostUrl错误");

            var rs = await host.AppendPathSegment(path)
                                  .SetQueryParams(query)
                                  .PostJsonAsync(body)
                                  .ReceiveJson<JsonModel<TOut>>();

            if (rs.Code != 0)
                throw new System.Exception(rs.Message);

            return rs.Data;


        }


        #region FlurlHttp-Config

        void BeforeCall(HttpCall call)
        {

        }

        #endregion

    }

    public class OparkMemberCouponSimple
    {
        public long OparkUserId { get; set; }

        public string NickName { get; set; }

        public string Phone { get; set; }

        public int? Gender { get; set; }

        public DateTime? KidBirth { get; set; }

        public string CouponName { get; set; }

        public int? CouponType { get; set; }

        public int? ConsumerCount { get; set; }

        public int? PaymentType { get; set; }

        public double ReceivedPay { get; set; }

        public DateTime? CTime { get; set; }
    }
}
