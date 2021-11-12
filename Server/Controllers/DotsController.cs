using System;
using System.Linq;
using System.Threading.Tasks;
using LasmartTest.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LasmartTest.Server.Controllers
{
	[Route("api/[controller]")]
	public class DotsController : Controller
	{
		private readonly ApiContext _context;

		public DotsController(ApiContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Get()
		{
			var dots = await _context.Dots
				.Include(u => u.Comments)
				.ToArrayAsync();
			return Ok(dots);
		}

		[HttpDelete("{dotId:int}")]
		public async Task<IActionResult> Delete(int dotId)
		{
			try
			{
				var dotToDelete = await _context.Dots.FirstOrDefaultAsync(x => x.Id == dotId);
				if (dotToDelete == null) return NotFound($"Dot not found with Id = {dotId}");
				_context.Dots.Remove(dotToDelete);
				await _context.SaveChangesAsync();
				return Ok($"Dot with Id = {dotId} deleted");
			}
			catch (Exception e)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
			}
		}
	}
}