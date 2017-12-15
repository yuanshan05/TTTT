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
    /// FuzzyQueryControl.xaml 的交互逻辑
    /// </summary>
    public partial class FuzzyQueryControl : UserControl
    {
        public FuzzyQueryControl()
        {
            InitializeComponent();
            this.querykey.TextChanged += TextChangedHandler;

        }


        #region 路由事件

        //TODO: 1、ItemsControl 选择(MouseLeftButtonDown)事件；2、TextBox 输入改变(TextChanged)事件

        /// <summary>
        /// 输入文本改变事件
        /// </summary>
        public static readonly RoutedEvent InputChangedRoutedEvent = EventManager.RegisterRoutedEvent("InputChanged", RoutingStrategy.Bubble, typeof(EventHandler<TextChangedEventArgs>), typeof(FuzzyQueryControl));

        // Using a RouterEvent as the backing store for InputChanged.  This enables animation, styling, binding, etc...
        public event RoutedEventHandler InputChanged
        {
            add { this.AddHandler(InputChangedRoutedEvent, value); }
            remove { this.RemoveHandler(InputChangedRoutedEvent, value); }
        }

        /// <summary>
        /// 选择改变
        /// </summary>
        public static readonly RoutedEvent ItemSelectionChangedRoutedEvent = EventManager.RegisterRoutedEvent("ItemSelectionChanged", RoutingStrategy.Bubble, typeof(EventHandler<MouseButtonEventArgs>), typeof(FuzzyQueryControl));

        // Using a RoutedEvent as the backing store for ItemSelectionChanged.  This enables animation, styling, binding, etc...
        public event RoutedEventHandler ItemSelectionChanged
        {
            add { this.AddHandler(ItemSelectionChangedRoutedEvent, value); }
            remove { this.RemoveHandler(ItemSelectionChangedRoutedEvent, value); }
        }

        #endregion

        #region 依赖属性

        /// <summary>
        /// 查询条件关键字
        /// </summary>
        public string CondtionKey
        {
            get { return (string)GetValue(CondtionKeyProperty); }
            set { SetValue(CondtionKeyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CondtionKey.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CondtionKeyProperty =
            DependencyProperty.Register("CondtionKey", typeof(string), typeof(FuzzyQueryControl), new PropertyMetadata(null));


        /// <summary>
        /// 水印
        /// </summary>
        public string WatermarkKey
        {
            get { return (string)GetValue(WatermarkKeyProperty); }
            set { SetValue(WatermarkKeyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WatermarkKey.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkKeyProperty =
            DependencyProperty.Register("WatermarkKey", typeof(string), typeof(FuzzyQueryControl), new PropertyMetadata(null));



        public double TextHeight
        {
            get { return (double)GetValue(TextHeightProperty); }
            set { SetValue(TextHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextHeightProperty =
            DependencyProperty.Register("TextHeight", typeof(double), typeof(FuzzyQueryControl), new PropertyMetadata(27.0));


        public double TextWidth
        {
            get { return (double)GetValue(TextWidthProperty); }
            set { SetValue(TextWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextWidthProperty =
            DependencyProperty.Register("TextWidth", typeof(double), typeof(FuzzyQueryControl), new PropertyMetadata(60.0));

        public System.Collections.IEnumerable ItemsControlSource
        {
            get { return (System.Collections.IEnumerable)GetValue(ItemsControlSourceProperty); }
            set { SetValue(ItemsControlSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsControlSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsControlSourceProperty =
            DependencyProperty.Register("ItemsControlSource", typeof(System.Collections.IEnumerable), typeof(FuzzyQueryControl), new PropertyMetadata(null));



        public Style ItemsControlItemStyle
        {
            get { return (Style)GetValue(ItemsControlItemStyleProperty); }
            set { SetValue(ItemsControlItemStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsControlItemStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsControlItemStyleProperty =
            DependencyProperty.Register("ItemsControlItemStyle", typeof(Style), typeof(FuzzyQueryControl), new PropertyMetadata(null));



        public bool PopupOpen
        {
            get { return (bool)GetValue(PopupOpenProperty); }
            set { SetValue(PopupOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PopupOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupOpenProperty =
            DependencyProperty.Register("PopupOpen", typeof(bool), typeof(FuzzyQueryControl), new PropertyMetadata(false));


        public DataTemplate ItemTemplte
        {
            get { return (DataTemplate)GetValue(ItemTemplteProperty); }
            set { SetValue(ItemTemplteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemTemplte.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemTemplteProperty =
            DependencyProperty.Register("ItemTemplte", typeof(DataTemplate), typeof(FuzzyQueryControl), new PropertyMetadata(null));


   

        #endregion

        #region 事件

        /// <summary>
        /// 文本输入改变事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChangedHandler(object sender, TextChangedEventArgs e)
        {
            this.querykey.TextChanged -= TextChangedHandler;

            this.querykey.SelectionStart = this.querykey.Text.Length;

            RoutedEventArgs args = new RoutedEventArgs(FuzzyQueryControl.InputChangedRoutedEvent, sender);
            this.RaiseEvent(args);
        }

        #endregion

    }
}
