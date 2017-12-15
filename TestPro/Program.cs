using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TestPro.DecoratorPattern;
using TestPro.Factory;

namespace TestPro
{
    class Program
    {
        //private static string fileName = @"C:\Users\八号楼科技\Desktop\系统会员数据.xlsx";
        static void Main(string[] args)
        {

            //string hi = "hi";

            //string hiRegex = @"\bhi\b";

            //var result = ExcelHelper.Reader(fileName, false);

            //Console.WriteLine($"========================{result.Count}=========================");

            //var date = DateTime.FromOADate(42871);


            //Console.WriteLine($"========================{date}=========================");

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Name{item.Name}\tPhone{item.Phone}\tCouponName{item.CouponName}\tCount:{item.Count}\tGender:{item.Gender}\tCTime:{item.CTime}\tDeadlineTime:{item.DeadlineTime}");
            //}

            //42871
            //TimeSpan.FromMilliseconds(42871).
            //TimeSpan.

            //string phone = "15563718500";

            //Console.WriteLine(phone.IsPhone());

            //string str1 = string.Empty;

            //string str2 = "";

            //string str3 = null;

            //Console.WriteLine(str1.IsNullOrEmpty());
            //Console.WriteLine(str1.IsNullOrWhiteSpace());

            //Console.WriteLine("=================");

            //Console.WriteLine(str2.IsNullOrEmpty());
            //Console.WriteLine(str2.IsNullOrWhiteSpace());

            //Console.WriteLine("=================");

            //Console.WriteLine(str3.IsNullOrEmpty());
            //Console.WriteLine(str3.IsNullOrWhiteSpace());

            //try
            //{
            //    DivideByZero(1);
            //}
            //catch (Exception exc)
            //{
            //    Console.WriteLine("=====Program======");
            //    Console.WriteLine(exc.Message);
            //    Console.WriteLine("************************");
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            //ConcreteComponent compont = new ConcreteComponent("装饰器");
            //ConcreteDecorateA decorateA = new ConcreteDecorateA();
            //ConcreteDecorateB decorateB = new ConcreteDecorateB();

            //decorateB.SetDecorate(compont);
            //decorateA.SetDecorate(decorateB);
            //decorateA.Show();

            //Events e = new Events();
            //e.ShowNameEvent += ShowName;

            //DateTime dt = DateTime.Now;

            //Console.WriteLine($"{dt.ToString("yyyy-MM-dd HH:mm:ss")}");

            //long timelong = ConvertDataTimeLong(dt);

            //Console.WriteLine(timelong);

            //DateTime dateTime = ConvertLongDateTime(timelong);

            //Console.WriteLine(dateTime.ToString("yyyy-MM-dd HH:mm:ss"));

            //StringSwith.Init();

            //FactoryPattern();

            //string test1 = "1234567890";
            //Console.WriteLine($"test1\n{SubString(test1, 3)}");
            //string test2 = "123456";
            //Console.WriteLine($"test2\n{SubString(test2)}");
            //string test3 = "12345678901234567890";
            //Console.WriteLine($"test3\n{SubString(test3)}");
            //string test4 = "12345612345678901234567890";
            //Console.WriteLine($"test4\n{SubString(test4, 5)}");
            //string test5 = null;
            //Console.WriteLine($"test5{SubString(test5)}");

            //RadomExtensions.Setting();
            //Setting();


            Console.ReadKey();
        }

        static DispatcherTimer timer;
        public static void Setting()
        {

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0),
            };

            timer.Tick += RandomGenNumber;
            timer.Start();
            Console.WriteLine("DispatcherTimer");
        }

        static int i = 1;

        private static void RandomGenNumber(object sender, EventArgs e)
        {
            if (timer.Interval == TimeSpan.FromSeconds(0))
                timer.Interval = TimeSpan.FromMilliseconds(500);

            long dt = DateTime.UtcNow.ToUniversalTime().Second;

            Random random = new Random();

            int rs = random.Next(Int32.MinValue, Int32.MaxValue);

            Console.WriteLine($"第{i++}次打印次：{rs}");


        }

        static string SubString(string value, int count = 10)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            int rows = value.Length / count;
            int cols = value.Length % count;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                sb.AppendLine(value.Substring(i * count, count));
            }

            if (cols > 0)
                sb.AppendLine(value.Substring(rows * count, cols));

            return sb.ToString();
        }

        static void FactoryPattern()
        {
            Console.WriteLine($"==========FactoryPattern=========");

            IFactory factory = new SubFactory();
            Operator operat = factory.CreaterOperator();

            operat.FirstNumber = 10;
            operat.SecondNumber = 30;

            Console.WriteLine(operat.GetResult());

        }

        private static void ShowName(string name)
        {
            Console.WriteLine($"ShowNameEvent:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        static void DivideByZero(int number)
        {
            try
            {
                int result = 1 / number;

                if (1 == 1)
                    throw new Exception("测试抛出异常");
            }
            catch (Exception exc)
            {
                Console.WriteLine("=====DivideByZero======");
                Console.WriteLine(exc);
                Console.WriteLine("************************");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// DateTime 转换 long
        /// </summary>
        /// <param name="dt">要转换的datetime</param>
        /// <returns></returns>
        static long ConvertDataTimeLong(DateTime dt)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = dt.Subtract(dtStart);
            long timeStamp = toNow.Ticks;
            timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 4));
            return timeStamp;
        }

        /// <summary>
        /// long 转换 DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static DateTime ConvertLongDateTime(long value)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            if (long.TryParse(value + "0000", out long timelong))
            {
                TimeSpan toNow = new TimeSpan(timelong);
                DateTime dtResult = dtStart.Add(toNow);
                return dtResult;
            }
            else
                throw new Exception("转换失败");

        }
    }
}
