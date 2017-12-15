using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialEWpfDemo
{
    public class UtilTook
    {
        public static string PaymentTypeConvert(string code)
        {
            string type = string.Empty;
            switch (code)
            {
                case "1":
                    type = "现金";
                    break;
                case "2":
                    type = "微信";
                    break;
                case "3":
                    type = "支付宝";
                    break;
                case "4":
                    type = "刷卡";
                    break;
                case "5":
                    type = "线上";
                    break;
                case "6":
                    type = "储值";
                    break;
                case "7":
                    type = "转储";
                    break;
                default:
                    break;
            }

            return type;
        }
    }
}
