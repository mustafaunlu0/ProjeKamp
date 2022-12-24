using System.ComponentModel.DataAnnotations;

namespace ProjeKamp.Models
{
    public class PostDetail
    {
        [Key]
        public int detailId { get; set; }
        public int postId { get; set; }

        public int ParticipantId { get; set; }

    }
}
