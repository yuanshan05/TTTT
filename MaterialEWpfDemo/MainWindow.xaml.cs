using System;
using System.Collections.Generic;
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

namespace MaterialEWpfDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.autocomplete.ItemFilter = new AutoCompleteFilterPredicate<object>((k,i)=>i.Name.Contains(k)||i.Phone==k);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"控件属性值{this.paymentType.hidden.IsChecked}\t依赖属性值：{ this.paymentType.HiddenChecked}");

            this.paymentType.HiddenChecked = true;
            //this.paymentType.hidden.IsChecked = true;
            Console.WriteLine(this.paymentType.hidden.IsChecked);
            string type = this.paymentType.PaymentType;
            //Console.WriteLine(UtilTook.PaymentTypeConvert(type));
        }

        private void FuzzyQueryControl_InputChanged(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("*****");
        }

        private void FuzzyQueryControl_ItemSelectionChanged(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ItemControl Selection Item Changed");
        }

        //private void stackpanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{

        //}
    }
}
