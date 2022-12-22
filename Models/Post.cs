using System.ComponentModel.DataAnnotations.Schema;

namespace ProjeKamp.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string PostName { get; set; }

        public string PostCity { get; set; }

        public string PostCounty { get; set; }

        public string PostDate { get; set; }

        public string PostHour { get; set; }

        public string PostUri { get; set; }
        [NotMapped]
        public IFormFile PostImage { get; set; }

        public string PostContent { get; set; }

        public int NumberOfParticipants { get; set; }

        public int AdminId { get; set; }

    }
}
