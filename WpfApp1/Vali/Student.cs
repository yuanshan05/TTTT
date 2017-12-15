using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Vali
{
    public class Student : ValidationBase
    {
        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "年龄不能为空")]
        [RegularExpression(@"^\d.$", ErrorMessage = "年龄只能为整数")]
        public int? Age { get; set; }
    }
}
