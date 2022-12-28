using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjeKamp.Models
{
    public class Post
    {
        [Required]
        [Display(Name = "Post ID")]
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Kamp Adı")]
        public string PostName { get; set; }

        [Required]
        [Display(Name = "Şehir")]
        public string PostCity { get; set; }

        [Required]
        [Display(Name = "İlçe")]
        public string PostCounty { get; set; }

        [Required]
        [Display(Name = "Tarih")]
        public string PostDate { get; set; }

        [Required]
        [Display(Name = "Saat")]
        public string PostHour { get; set; }

        [Required]
        [Display(Name = "Resim Uzantısı")]
        public string PostUri { get; set; }

        [Required]
        [Display(Name = "Resim")]
        [NotMapped]
        public IFormFile PostImage { get; set; }

        [Required]
        [Display(Name = "Harita-URL")]
        public string PostMap { get; set; }

        [Required]
        [Display(Name = "Kamp İçerik")]
        public string PostContent { get; set; }

        [Required]
        [Display(Name = "Kontenjan")]
        public int NumberOfParticipants { get; set; }

        [Required]
        [Display(Name = "Admin ID")]
        public int AdminId { get; set; }

    }
}
