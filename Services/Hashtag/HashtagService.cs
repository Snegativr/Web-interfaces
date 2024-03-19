using WebApplication3.Models;
using WebApplication3.Services;
namespace WebApplication3.Services
{
    public class HashtagService : IHashtagService
    {
        private readonly List<HashtagModel> _hashtagList;

        public HashtagService()
        {
            _hashtagList = new List<HashtagModel>
            {
                new HashtagModel { Id = 1, Tag = "programming", Description = "Hashtags related to programming", CreatedAt = DateTime.Now.AddDays(-5), UsageCount = 1000 },
                new HashtagModel { Id = 2, Tag = "technology", Description = "Hashtags related to technology", CreatedAt = DateTime.Now.AddDays(-3), UsageCount = 800 },
                new HashtagModel { Id = 3, Tag = "gamedev", Description = "Hashtags related to game development", CreatedAt = DateTime.Now.AddDays(-7), UsageCount = 600 },
                new HashtagModel { Id = 4, Tag = "AI", Description = "Hashtags related to artificial intelligence", CreatedAt = DateTime.Now.AddDays(-2), UsageCount = 1200 },
                new HashtagModel { Id = 5, Tag = "machinelearning", Description = "Hashtags related to machine learning", CreatedAt = DateTime.Now.AddDays(-4), UsageCount = 900 },
                new HashtagModel { Id = 6, Tag = "coding", Description = "Hashtags related to coding", CreatedAt = DateTime.Now.AddDays(-6), UsageCount = 700 },
                new HashtagModel { Id = 7, Tag = "webdev", Description = "Hashtags related to web development", CreatedAt = DateTime.Now.AddDays(-8), UsageCount = 500 },
                new HashtagModel { Id = 8, Tag = "datascience", Description = "Hashtags related to data science", CreatedAt = DateTime.Now.AddDays(-1), UsageCount = 1500 },
                new HashtagModel { Id = 9, Tag = "cybersecurity", Description = "Hashtags related to cybersecurity", CreatedAt = DateTime.Now.AddDays(-9), UsageCount = 400 },
                new HashtagModel { Id = 10, Tag = "blockchain", Description = "Hashtags related to blockchain", CreatedAt = DateTime.Now.AddDays(-10), UsageCount = 300 }
            };
        }

        public Task<List<HashtagModel>> GetHashtagsAsync()
        {
            return Task.FromResult(_hashtagList);
        }

        public Task AddHashtagAsync(HashtagModel hashtag)
        {
            _hashtagList.Add(hashtag);
            return Task.CompletedTask;
        }

        public Task UpdateHashtagAsync(int id, HashtagModel hashtag)
        {
            var existingHashtag = _hashtagList.FirstOrDefault(h => h.Id == id);
            if (existingHashtag != null)
            {
                existingHashtag.Tag = hashtag.Tag;
                existingHashtag.Description = hashtag.Description;
                existingHashtag.CreatedAt = hashtag.CreatedAt;
                existingHashtag.UsageCount = hashtag.UsageCount;
            }
            return Task.CompletedTask;
        }

        public Task DeleteHashtagAsync(int id)
        {
            var hashtagToDelete = _hashtagList.FirstOrDefault(h => h.Id == id);
            if (hashtagToDelete != null)
            {
                _hashtagList.Remove(hashtagToDelete);
            }
            return Task.CompletedTask;
        }
    }
}