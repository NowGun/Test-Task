using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testovoe.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Почта")]
        [Required(ErrorMessage = "Заполните почту")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Заполните пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
