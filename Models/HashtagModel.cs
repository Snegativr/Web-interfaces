namespace WebApplication3.Models
{
    public class HashtagModel
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UsageCount { get; set; }
    }
}