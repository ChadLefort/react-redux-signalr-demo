using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactReduxSignalRDemo.Models;

namespace ReactReduxSignalRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly OperatorsContext _context;

        public OperatorsController(OperatorsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Operator> GetOperators()
        {
            return _context.Operators;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperator([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @operator = await _context.Operators.FindAsync(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return Ok(@operator);
        }
    }
}