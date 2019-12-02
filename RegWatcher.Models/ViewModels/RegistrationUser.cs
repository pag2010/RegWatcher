using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class RegistrationUser : AuthenticationUser
    {
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яёЁА-Я\s]+$",
            ErrorMessage = "Имя должно начинаться с большой буквы и содержать только русские буквы")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яёЁА-Я\s]+$", 
            ErrorMessage = "Фамилия должна начинаться с большой буквы и содержать только русские буквы")]
        public string SecondName { get; set; }

        [RegularExpression(@"^[А-ЯЁ][а-яёЁА-Я\s]+$",
            ErrorMessage = "Отчество должно начинаться с большой буквы и содержать только русские буквы")]
        public string LastName { get; set; }
    }
}
