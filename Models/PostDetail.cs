using System.ComponentModel.DataAnnotations;

namespace ProjeKamp.Models
{
    public class PostDetail
    {
        [Display(Name ="Detay ID")]
        [Key]
        public int detailId { get; set; }

        [Display(Name = "Post ID")]
        public int postId { get; set; }

        [Display(Name = "Katılımcı ID")]
        public int ParticipantId { get; set; }


    }
}
