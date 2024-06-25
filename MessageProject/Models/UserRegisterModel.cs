using System.ComponentModel.DataAnnotations;

namespace MessageProject.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Ad gerekli.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Soyad gerekli.")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gerekli.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Email gerekli.")]
        [EmailAddress(ErrorMessage = "Geçersiz email adresi.")]
        public string mail { get; set; }

        [Required(ErrorMessage = "Şifre gerekli.")]
        public string password { get; set; }
    }
}

