using Newtonsoft.Json;
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
    /// PaymmentTypeControl.xaml 的交互逻辑
    /// </summary>
    public partial class PaymmentTypeControl : UserControl
    {
        public PaymmentTypeControl()
        {
            InitializeComponent();
        }

        #region 依赖属性 常用

        /// <summary>
        /// 支付方式标题
        /// </summary>
        public string CheckBoxContent
        {
            get { return (string)GetValue(CheckBoxContentProperty); }
            set { SetValue(CheckBoxContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckBoxContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckBoxContentProperty =
            DependencyProperty.Register("CheckBoxContent", typeof(string), typeof(PaymmentTypeControl), new PropertyMetadata("支付方式"));

        /// <summary>
        /// 隐藏支付方式的选中状态 
        /// 用户：回复选中默认状态
        /// </summary>
        public bool HiddenChecked
        {
            get { return (bool)GetValue(HiddenCheckedProperty); }
            set { SetValue(HiddenCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HiddeChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HiddenCheckedProperty =
            DependencyProperty.Register("HiddenChecked", typeof(bool), typeof(PaymmentTypeControl), new PropertyMetadata(false));

        /// <summary>
        /// 最终结果支付方式
        /// </summary>
        public string PaymentType
        {
            get { return (string)GetValue(PaymentTypeProperty); }
            set { SetValue(PaymentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PaymentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentTypeProperty =
            DependencyProperty.Register("PaymentType", typeof(string), typeof(PaymmentTypeControl), new PropertyMetadata(null));


        /// <summary>
        /// 显示复选框
        /// </summary>
        public Visibility CheckBoxVisility
        {
            get { return (Visibility)GetValue(CheckBoxVisilityProperty); }
            set { SetValue(CheckBoxVisilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckBoxVisility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckBoxVisilityProperty =
            DependencyProperty.Register("CheckBoxVisility", typeof(Visibility), typeof(PaymmentTypeControl), new PropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// 复选框是否选中
        /// </summary>
        public bool CheckBoxIsChecked
        {
            get { return (bool)GetValue(CheckBoxIsCheckedProperty); }
            set { SetValue(CheckBoxIsCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckBoxIsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckBoxIsCheckedProperty =
            DependencyProperty.Register("CheckBoxIsChecked", typeof(bool), typeof(PaymmentTypeControl), new PropertyMetadata(false));


        #endregion

        #region 依赖属性 支付方式可见性

        /// <summary>
        /// 现金支付方式 可见性
        /// </summary>
        public Visibility CashVisibility
        {
            get { return (Visibility)GetValue(CashVisibilityProperty); }
            set { SetValue(CashVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CashVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CashVisibilityProperty =
            DependencyProperty.Register("CashVisibility", typeof(Visibility), typeof(PaymmentTypeControl), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// 微信支付方式 可见性
        /// </summary>
        public Visibility WechatVisibility
        {
            get { return (Visibility)GetValue(WechatVisibilityProperty); }
            set { SetValue(WechatVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WechatVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WechatVisibilityProperty =
            DependencyProperty.Register("WechatVisibility", typeof(Visibility), typeof(PaymmentTypeControl), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// 支付宝支付方式 可见性
        /// </summary>
        public Visibility AilPayVisibility
        {
            get { return (Visibility)GetValue(AilPayVisibilityProperty); }
            set { SetValue(AilPayVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AilPayVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AilPayVisibilityProperty =
            DependencyProperty.Register("AilPayVisibility", typeof(Visibility), typeof(PaymmentTypeControl), new PropertyMetadata(Visibility.Visible));


        /// <summary>
        /// 刷卡支付方式 可见性
        /// </summary>
        public Visibility UnionPayVisibility
        {
            get { return (Visibility)GetValue(UnionPayVisibilityProperty); }
            set { SetValue(UnionPayVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnionPayVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnionPayVisibilityProperty =
            DependencyProperty.Register("UnionPayVisibility", typeof(Visibility), typeof(PaymmentTypeControl), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// 转储支付方式 可见性
        /// </summary>
        public Visibility StoredVisibility
        {
            get { return (Visibility)GetValue(StoredVisibilityProperty); }
            set { SetValue(StoredVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StoredVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StoredVisibilityProperty =
            DependencyProperty.Register("StoredVisibility", typeof(Visibility), typeof(PaymmentTypeControl), new PropertyMetadata(Visibility.Visible));


        /// <summary>
        /// 转储支付方式 可见性
        /// </summary>
        public Visibility TransferVisibility
        {
            get { return (Visibility)GetValue(TransferVisibilityProperty); }
            set { SetValue(TransferVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TransferVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TransferVisibilityProperty =
            DependencyProperty.Register("TransferVisibility", typeof(Visibility), typeof(PaymmentTypeControl), new PropertyMetadata(Visibility.Visible));




        #endregion

        private void PaymentTypeClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton rbtn)
            {
                if (rbtn.IsChecked.Value)
                {
                    PaymentType = rbtn.Tag.ToString();
                }
                else
                {
                    rbtn.IsChecked = null;
                    PaymentType = null;
                }
            }
        }

        private void HiddenCheckedEvent(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is RadioButton rbtn)
            {
                if (rbtn.IsChecked.Value)
                {
                    PaymentType = null;
                }
            }
        }
    }
}
