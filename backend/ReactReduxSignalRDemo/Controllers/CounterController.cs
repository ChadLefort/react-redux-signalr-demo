using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly CounterContext _context;

        public CounterController(CounterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public CounterResult GetCounter()
        {
            return _context.Counter.Select(x => new CounterResult {Count = x.Count}).FirstOrDefault();
        }
    }
}