using WebApplication3.Models;
using WebApplication3.Services;
namespace WebApplication3.Services { 
    public class TweetService : ITweetService
    {
        private readonly List<TweetModel> _tweetList;

        public TweetService()
        {
            _tweetList = new List<TweetModel>
            {
                new TweetModel { Id = 1, Text = "Having a great day at the park!", Author = "JohnDoe", CreatedAt = DateTime.Now.AddDays(-1) },
                new TweetModel { Id = 2, Text = "Just finished reading a fascinating book!", Author = "JaneSmith", CreatedAt = DateTime.Now.AddDays(-2) },
                new TweetModel { Id = 3, Text = "Excited for my upcoming trip to Paris!", Author = "MikeJohnson", CreatedAt = DateTime.Now.AddDays(-3) },
                new TweetModel { Id = 4, Text = "Enjoying sushi with friends in Tokyo!", Author = "EmilyBrown", CreatedAt = DateTime.Now.AddDays(-4) },
                new TweetModel { Id = 5, Text = "Exploring the beautiful beaches of Sydney!", Author = "AlexWilliams", CreatedAt = DateTime.Now.AddDays(-5) },
                new TweetModel { Id = 6, Text = "Berlin has such a rich history!", Author = "JessicaLee", CreatedAt = DateTime.Now.AddDays(-6) },
                new TweetModel { Id = 7, Text = "Having fun in Moscow!", Author = "DavidMartinez", CreatedAt = DateTime.Now.AddDays(-7) },
                new TweetModel { Id = 8, Text = "Great Wall of China is amazing!", Author = "EmmaGarcia", CreatedAt = DateTime.Now.AddDays(-8) },
                new TweetModel { Id = 9, Text = "Rio de Janeiro is such a vibrant city!", Author = "DanielLopez", CreatedAt = DateTime.Now.AddDays(-9) },
                new TweetModel { Id = 10, Text = "Toronto Raptors won the game!", Author = "OliviaTaylor", CreatedAt = DateTime.Now.AddDays(-10) }
            };
        }

        public Task<List<TweetModel>> GetTweetsAsync()
        {
            return Task.FromResult(_tweetList);
        }

        public Task AddTweetAsync(TweetModel tweet)
        {
            _tweetList.Add(tweet);
            return Task.CompletedTask;
        }

        public Task UpdateTweetAsync(int id, TweetModel tweet)
        {
            var existingTweet = _tweetList.FirstOrDefault(t => t.Id == id);
            if (existingTweet != null)
            {
                existingTweet.Text = tweet.Text;
            }
            return Task.CompletedTask;
        }

        public Task DeleteTweetAsync(int id)
        {
            var tweetToDelete = _tweetList.FirstOrDefault(t => t.Id == id);
            if (tweetToDelete != null)
            {
                _tweetList.Remove(tweetToDelete);
            }
            return Task.CompletedTask;
        }
    }
}