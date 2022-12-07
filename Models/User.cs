using System.ComponentModel.DataAnnotations;

namespace ProjeKamp.Models
{
    public class User
    {

        public int UserId { get; set; }

        [Required(ErrorMessage ="Ad Alanı Zorunludur")]
        [Display(Name ="Ad")]
        [StringLength(15)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Soyad Alanı Zorunludur")]
        [Display(Name = "Soyad")]
        [StringLength(15)]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "E-Mail Alanı Zorunludur")]
        [EmailAddress]
        [Display(Name = "E-Posta")]
        public string UserEmail { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Alanı Zorunludur")]
        [StringLength(15)]
        public string UserPassword { get; set; }
    }
}
