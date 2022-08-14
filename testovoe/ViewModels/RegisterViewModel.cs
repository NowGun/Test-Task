using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testovoe.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Введите фамилию")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Введите почту")]
        [EmailAddress(ErrorMessage = "Почта введена неверно")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
