using System.ComponentModel.DataAnnotations;

namespace FinalProject.WebApp.Models.VMs
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Zorunludur!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
