namespace WebApplication3.Models { 
    public class TweetModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}