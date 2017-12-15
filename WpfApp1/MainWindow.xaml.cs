using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void ComboBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is ComboBox cmb)
                MessageBox.Show(cmb.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintHelper.Print("测试打印", $"10*39={10 * 39}", null, "就是测试玩玩");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("测试打印2");
            sb.AppendLine($"10*39={10 * 39}");
            sb.AppendLine();
            sb.AppendLine("就是玩玩2");

            try
            {
                PrintHelper.Print(sb.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private async void QueryOparkGoods(object sender, RoutedEventArgs e)
        {
            var rs = await HttpBase.QueryList();

            Console.WriteLine("============");

            Console.WriteLine(JsonConvert.SerializeObject(rs));
        }

        private  void Button_Click_2(object sender, RoutedEventArgs e)
        {
             //MemberHttp.GetMembers();
        }
    }
}
