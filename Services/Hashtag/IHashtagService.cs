using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface IHashtagService
    {
        Task<List<HashtagModel>> GetHashtagsAsync();
        Task AddHashtagAsync(HashtagModel hashtag);
        Task UpdateHashtagAsync(int id, HashtagModel hashtag);
        Task DeleteHashtagAsync(int id);
    }
}