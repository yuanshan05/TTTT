using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Vali;

namespace WpfApp1
{
    public class MainWindowViewModel : BindableBase
    {
        private List<Student> students = new List<Student>();
        private Student student = new Student();
        private string key;
        private Vali.Student valiStudent = new Vali.Student();

        private decimal total;

        public decimal Total { get { return total; } set { SetProperty(ref total, value); } }


        public List<Student> Students { get { return students; } set { SetProperty(ref students, value); } }
        public Student Student { get { return student; } set { SetProperty(ref student, value); } }
        public string Key { get { return key; } set { SetProperty(ref key, value); } }

        private List<Student> source;

        public MainWindowViewModel()
        {
            source = Student.CreateStudents(40);

            TetxChangedCommand = new DelegateCommand<object>(OnTextChanged);
            QueryCommand = new DelegateCommand(OnQuery);
            ExceptionCommand = new DelegateCommand(OnException);
            TimeOutCommand = new DelegateCommand(OnTimeOut);

            //System.Drawing.Printing.PrintHelper.Print("");
            FlurlConfigCommand = new DelegateCommand(OnConfig);
            ImportCommand = new DelegateCommand(OnImport);
        }

        public DelegateCommand ImportCommand { get; set; }



        private double price;

        public double Price { get => price; set => SetProperty(ref price, value); }

        public DelegateCommand<object> TetxChangedCommand { get; private set; }

        public DelegateCommand QueryCommand { get; private set; }

        public DelegateCommand ExceptionCommand { get; private set; }

        public DelegateCommand TimeOutCommand { get; private set; }

        public DelegateCommand FlurlConfigCommand { get; private set; }

        async void OnConfig()
        {
            try
            {
                await HttpBase.FlurlConfig();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

        }

        async void OnException()
        {
            try
            {
                await HttpBase.Buniess();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        async void OnTimeOut()
        {
            try
            {
                await HttpBase.TimeOutFuns();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        void OnTextChanged(object obj)
        {

            MessageBox.Show("OK");

            if (obj is string key)
            {
                //string key = cmb.Text;

                Students = source.Where(x => x.Name.Contains(key) || x.Phone == key).ToList();
            }
        }

        void OnQuery()
        {
            Console.WriteLine($"{ Dictionarys.MemberState[1]}");
        }

        private bool isDropDownOpen = false;
        public bool IsDropDownOpen { get { return IsDropDownOpen; } set { SetProperty(ref isDropDownOpen, value); } }

        public Vali.Student ValiStudent { get => valiStudent; set => SetProperty(ref valiStudent, value); }

        public void TextInput(object sender, System.Windows.RoutedEventArgs e)
        {

            if (sender is ComboBox cmb)
            {
                string key = cmb.Text;

                Students = source.Where(x => x.Name.Contains(key) || x.Phone == key).ToList();
                if (Students != null)
                    cmb.IsDropDownOpen = true;
                else
                    cmb.IsDropDownOpen = false;

            }
        }

        public void SelectedChanged(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is ComboBox cmb)
            {
                Student s = cmb.SelectedItem as Student;

                MessageBox.Show(JsonConvert.SerializeObject(s));
            }
        }

         void OnImport()
        {
            string path = GetFilePath();
            if (string.IsNullOrWhiteSpace(path)) return;

            //var rt = await HttpBase.QueryCouon(104);

            //FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);

            StringBuilder sb = new StringBuilder();

            using (StreamReader streamReader = new StreamReader(path, false))
            {
                while (!streamReader.EndOfStream)
                {
                    sb.AppendLine(streamReader.ReadLine());
                }
            }

            Console.WriteLine(sb);

            //foreach (var item in rt)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append(item.CTime)
            //      .Append($",{item.NickName}")
            //      .Append($",{GenderCodeConverter(item.Gender.ToString())}")
            //     .Append($",{item.KidBirth}")
            //     .Append($",{item.CouponName}")
            //     .Append($",{item.CouponType}")
            //     .Append($",{item.ReceivedPay}")
            //     .Append($",{item.ConsumerCount}")
            //     .Append($",{item.PaymentType}")
            //     .Append($",{item.Phone}");

            //    sw.WriteLine(sb);
            //}
            //sw.Flush();
            //sw.Close();

            MessageBox.Show("导出完成");

        }


        string GenderCodeConverter(string code)
        {
            string gender = string.Empty;

            switch (code)
            {
                case "1":
                    gender = "男";
                    break;
                case "2":
                    gender = "女";
                    break;
                case "3":
                    gender = "未知";
                    break;
                default:
                    gender = "-";
                    break;
            }

            return gender;
        }

        string SetFilePath()
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog()
            {
                Filter = "CSV文件(*.csv)|*.csv|所有文件(*.*)|*.*"
            };
            if (sfd.ShowDialog() == true)
            {
                return sfd.FileName;
            }
            else
            {
                return null;
            }
        }

        public static string GetFilePath()
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "CSV文件(*.csv)|*.csv|所有文件(*.*)|*.*"
            };
            if (ofd.ShowDialog() == true)
                return ofd.FileName;
            else
                return null;
        }
    }
}
