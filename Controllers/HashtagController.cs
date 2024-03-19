using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HashtagController : ControllerBase
    {
        private readonly IHashtagService _hashtagService;

        public HashtagController(IHashtagService hashtagService)
        {
            _hashtagService = hashtagService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hashtags = await _hashtagService.GetHashtagsAsync();
            return Ok(hashtags);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HashtagModel hashtag)
        {
            await _hashtagService.AddHashtagAsync(hashtag);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HashtagModel hashtag)
        {
            await _hashtagService.UpdateHashtagAsync(id, hashtag);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _hashtagService.DeleteHashtagAsync(id);
            return Ok();
        }
    }
}