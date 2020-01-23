

namespace SchoolJournal.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LoginModel
    {
        [Display(Name = "Логин")]
        public string Name { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
