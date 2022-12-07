namespace ProjeKamp.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string PostContent { get; set; }

        public int NumberOfParticipants { get; set; }

        public int NumberOfUndecided { get; set; }

        public int AdminId { get; set; }

    }
}
