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
        private readonly R6KillFeedContext _context;

        public KillFeedsController(R6KillFeedContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<KillFeed> GetKillFeeds()
        {
            return _context.KillFeeds.
                Include(x => x.KillFeedItems)
                .ThenInclude(x => x.Kill)
                .Include(x => x.KillFeedItems)
                .ThenInclude(x => x.Death);
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
                .ThenInclude(x => x.Death);

            if (killFeed == null)
            {
                return NotFound();
            }

            return Ok(killFeed);
        }
    }
}