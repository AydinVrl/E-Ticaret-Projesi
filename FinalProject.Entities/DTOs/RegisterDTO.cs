using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.DTOs
{
    public record RegisterDTO
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        public string UserName { get; init; }

        [Required(ErrorMessage = "Kullanıcı email alanı zorunludur.")]
        [EmailAddress]
        public string Email { get; init; }

        [Required(ErrorMessage = "Kullanıcı şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler Tutarsız.")]
        [DataType(DataType.Password)]
        public string ConfrimPass { get; set; }
    }
}
