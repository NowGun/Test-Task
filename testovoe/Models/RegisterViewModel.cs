using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testovoe.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Заполните имя")]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заполните фамилию")]
        [MinLength(3)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Почта введена неверно")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
