using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drawing = System.Drawing;
using WpfApp1;

namespace System.Drawing.Printing
{
    public class PrintHelper
    {
        public static string Content { get; set; }

        /// <summary>
        /// 打印小票
        /// </summary>
        /// <exception cref="ContentNullException"/>
        /// <param name="paras"></param>
        public static void Print(params string[] paras)
        {
            if (paras.Count() <= 0)
                throw new ContentNullException();

            Content = BuilderContext(paras);

            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("58mm * 297mm", 228, 1169);
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.Print();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <exception cref="ContentNullException"></exception>
        /// <param name="para"></param>
        public static void Print(string para)
        {
            if (string.IsNullOrWhiteSpace(para))
                throw new Exception("打印内容不能为空！");

            Content = para;

            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("58mm * 297mm", 228, 1169);
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.Print();
        }

        private static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            (sender as PrintDocument).PrintPage -= PrintDocument_PrintPage;

            (sender as PrintDocument).PrintPage -= PrintDocument_PrintPage;
            Font fntTxt = new Font("宋体", 9, FontStyle.Regular);//正文文字
            Brush brush = new SolidBrush(Color.Black);//画刷
            Pen pen = new Pen(Color.Black);           //线条颜色
            PointF point = new Point(10, 10);

            Content += $"\n-------{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}-------------";

            e.Graphics.DrawString(Content, fntTxt, brush, point);

        }

        static string BuilderContext(params string[] paras)
        {

            StringBuilder sb = new StringBuilder();

            foreach (var para in paras)
            {
                sb.AppendLine(para);
            }

            return sb.ToString();
        }
    }
}
