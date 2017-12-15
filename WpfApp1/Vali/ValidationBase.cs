using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.Vali
{
    public class ValidationBase : IDataErrorInfo, INotifyPropertyChanged
    {
        protected string errMsg;
        private bool hasValidate = false;

        public string Error
        {
            get
            {
                if (!hasValidate)
                {
                    this.Validate();
                }
                return errMsg;
            }
        }

        public string this[string columnName]
        {
            get
            {
                this.hasValidate = true;
                List<System.ComponentModel.DataAnnotations.ValidationResult> resultList = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                ValidationContext context = new ValidationContext(this, null, null) { MemberName = columnName };
                if (Validator.TryValidateProperty(this.GetPropertyValue(columnName), context, resultList))
                {
                    return null;
                }
                this.errMsg = null;
                foreach (var item in resultList)
                {
                    this.errMsg += item.ErrorMessage + Environment.NewLine;
                }
                return this.errMsg;
            }
        }

        private object GetPropertyValue(string propName)
        {
            PropertyInfo property = base.GetType().GetProperty(propName, BindingFlags.GetProperty | BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            if (property == null)
            {
                return null;
            }
            if (property.GetIndexParameters().Length > 0)
            {
                return null;
            }
            return property.GetValue(this, null);
        }

        public virtual bool Validate()
        {
            this.hasValidate = true;
            List<System.ComponentModel.DataAnnotations.ValidationResult> resultList = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool flag = Validator.TryValidateObject(this, new ValidationContext(this, null, null), resultList, true);
            this.errMsg = null;
            foreach (var item in resultList)
            {
                this.errMsg += item.ErrorMessage + Environment.NewLine;
            }
            return flag;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPeropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
