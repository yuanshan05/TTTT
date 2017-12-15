using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace MaterialEWpfDemo
{
    public class MainWindowViewModel : BindableBase
    {

        private AutoCompleteFilterPredicate<Student> filter = new AutoCompleteFilterPredicate<Student>((str, item) => item.Name.Contains(str) || item.Phone == str);

        public AutoCompleteFilterPredicate<Student> Filter { get => filter; set => SetProperty(ref filter, value); }

        private bool isChecked;

        public bool IsChecked { get => isChecked; set => SetProperty(ref isChecked, value); }

        private string payemntType;

        public string PayemntType { get => payemntType; set => SetProperty(ref payemntType, value); }

        private bool isFree;

        public bool IsFree { get => isFree; set => SetProperty(ref isFree, value); }

        private string key;

        public string Key { get => key; set => SetProperty(ref key, value); }

        private List<Student> students = new List<Student>();

        public List<Student> Students { get => students; set => SetProperty(ref students, value); }

        private ICollectionView studentView;

        public ICollectionView StudentView { get => studentView; set => SetProperty(ref studentView, value); }

        private bool isDropDownOpen = false;

        public bool IsDropDownOpen { get => isDropDownOpen; set => SetProperty(ref isDropDownOpen, value); }

        public MainWindowViewModel()
        {
            ConfirmCommand = new DelegateCommand(OnConforim);
            SelectionChanged = new DelegateCommand<Student>(OnSelectionChanged);
        }


        public DelegateCommand ConfirmCommand { get; private set; }

        public DelegateCommand<Student> SelectionChanged { get; private set; }

        void OnConforim()
        {
            IsChecked = !IsChecked;
            if (IsFree)
            {
                Console.WriteLine("*********");
            }

            Console.WriteLine("=====================================");
            Console.WriteLine(PayemntType);
        }

        void OnSelectionChanged(Student student)
        {
            if (student == null) return;

            Key = student.Phone;
            IsDropDownOpen = false;
        }

        public void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            Students = Student.Initializer();

            StudentView = CollectionViewSource.GetDefaultView(Students);
        }


        public void OnSelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (e.OriginalSource is System.Windows.Controls.ComboBox cmb)
            {
                if (cmb.SelectedItem is Student st)
                {
                    Key = st.Phone;

                    IsDropDownOpen = false;
                }
            }
        }



        public void OnTextInput(object sender, System.Windows.RoutedEventArgs e)
        {
            if (e.OriginalSource is System.Windows.Controls.TextBox text)
            {
                string str = text.Text;
                if (string.IsNullOrWhiteSpace(str))
                    StudentView.Filter = null;
                else
                    StudentView.Filter =
                        s => (s as Student).Name.ToLower().Contains(str.ToLower()) || (s as Student).Phone.ToLower().Contains(str.ToLower());

                if ((StudentView as ListCollectionView).Count > 0)
                {
                    IsDropDownOpen = true;
                }
                else
                {
                    IsDropDownOpen = false;
                }

                Key = str;
            }
        }


        public void OnMouseLeftButtonDown(object sender, System.Windows.RoutedEventArgs e)
        {
            if (e.OriginalSource is System.Windows.Controls.ItemsControl item)
            {
                //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(e?.OriginalSource));


            }
        }

        public void OnInputChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (e.OriginalSource is Xceed.Wpf.Toolkit.WatermarkTextBox box)
            {

                Console.WriteLine(box.Text);
            }
        }

        public void OnItemControlSelectionChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            Console.WriteLine("OnItemControlSelectionChanged");
        }

    }
}
