using WebApplication3.Models;

namespace WebApplication3.Services { 
    public interface ITweetService
    {
        Task<List<TweetModel>> GetTweetsAsync();
        Task AddTweetAsync(TweetModel tweet);
        Task UpdateTweetAsync(int id, TweetModel tweet);
        Task DeleteTweetAsync(int id);
    }
}