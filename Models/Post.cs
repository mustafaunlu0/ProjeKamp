using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjeKamp.Models
{
    public class Post
    {
        [Display(Name = "Post ID")]
        public int PostId { get; set; }

        [Display(Name = "Kamp Adı")]
        public string PostName { get; set; }

        [Display(Name = "Şehir")]
        public string PostCity { get; set; }

        [Display(Name = "İlçe")]
        public string PostCounty { get; set; }

        [Display(Name = "Tarih")]
        public string PostDate { get; set; }

        [Display(Name = "Saat")]
        public string PostHour { get; set; }

        [Display(Name = "Resim Uzantısı")]
        public string PostUri { get; set; }

        [Display(Name = "Resim")]
        [NotMapped]
        public IFormFile PostImage { get; set; }

        [Display(Name = "Kamp İçerik")]
        public string PostContent { get; set; }

        [Display(Name = "Kontenjan")]
        public int NumberOfParticipants { get; set; }

        [Display(Name = "Admin ID")]
        public int AdminId { get; set; }

    }
}
