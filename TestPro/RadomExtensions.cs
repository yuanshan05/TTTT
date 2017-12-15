using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TestPro
{
    public class RadomExtensions
    {
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
    }
}
