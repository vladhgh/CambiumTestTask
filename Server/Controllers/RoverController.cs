using LasmartTest.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LasmartTest.Server.Controllers
{
	[Route("api/[controller]")]
	public class RoverController : Controller
    {
		private readonly ApiContext _context;

		public RoverController(ApiContext context)
        {
			_context = context;
        }

        [HttpPost("deploy")]
		public async Task<IActionResult>Deploy([FromBody] Rover rover)
        {
            _context.Rovers.Add(rover);
            await _context.SaveChangesAsync();
            return Ok(rover);
        }

        [HttpPost("move")]
        public async Task<IActionResult>Move([FromBody] Rover roverToMove)
        {
            //Here just to simulate latency between Earth and Mars
            Thread.Sleep(500);

            var rover = _context.Rovers.FirstOrDefault(rover => rover.Id == roverToMove.Id);
            if (roverToMove.NextAction == Action.Move)
            {
                rover.Move();
            } else if (roverToMove.NextAction == Action.RotateLeft || roverToMove.NextAction == Action.RotateRight)
            {
                rover.Rotate(roverToMove.NextAction);
            } else
            {
                return BadRequest("Unknown action passed: " + roverToMove.NextAction);
            }

            await _context.SaveChangesAsync();

            return Ok(rover);
        }
    }
}
