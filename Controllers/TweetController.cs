using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers {
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TweetController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tweets = await _tweetService.GetTweetsAsync();
            return Ok(tweets);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TweetModel tweet)
        {
            await _tweetService.AddTweetAsync(tweet);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TweetModel tweet)
        {
            await _tweetService.UpdateTweetAsync(id, tweet);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tweetService.DeleteTweetAsync(id);
            return Ok();
        }
    }
}