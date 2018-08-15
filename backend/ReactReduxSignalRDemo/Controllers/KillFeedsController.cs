using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KillFeedsController : ControllerBase
    {
        private readonly KillFeedsContext _context;

        public KillFeedsController(KillFeedsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<KillFeed> GetKillFeeds()
        {
            var killFeeds = _context.KillFeeds.
                Include(x => x.KillFeedItems)
                .ThenInclude(x => x.Kill)
                .Include(x => x.KillFeedItems)
                .ThenInclude(x => x.Death)
                .ToList();

            return killFeeds.Select(x => new KillFeed
            {
                KillFeedId = x.KillFeedId,
                MatchId = x.MatchId,
                UserId = x.UserId,
                KillFeedItems = x.KillFeedItems.Reverse()
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetKillFeed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var killFeed = _context.KillFeeds.Where(x => x.KillFeedId == id)
                .Include(x => x.KillFeedItems)
                .ThenInclude(x => x.Kill)
                .Include(x => x.KillFeedItems)
                .ThenInclude(x => x.Death)
                .FirstOrDefault();
            
            if (killFeed == null)
            {
                return NotFound();
            }

            killFeed.KillFeedItems = killFeed.KillFeedItems.Reverse();

            return Ok(killFeed);
        }
    }
}