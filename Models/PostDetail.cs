using System.ComponentModel.DataAnnotations;

namespace ProjeKamp.Models
{
    public class PostDetail
    {
        [Key]
        public int postId { get; set; }

        public User ParticipantId { get; set; }

    }
}
