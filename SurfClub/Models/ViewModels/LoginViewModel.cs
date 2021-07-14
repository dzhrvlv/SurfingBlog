using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Псевдоним обязателен")]
        [MaxLength(20, ErrorMessage = "Максимальная длина двадцать символов"), MinLength(3, ErrorMessage = "Минимальная длина три символа")]
        public String Nickname { get; set; }
        
        [Required(ErrorMessage = "Пароль обязателен")]
        [MaxLength(20, ErrorMessage = "Максимальная длина двадцать символов"), MinLength(6, ErrorMessage = "Минимальная длина шесть символов")]
        public String Password { get; set; }

        public bool RememberMe { get; set; }
        
    }
}
