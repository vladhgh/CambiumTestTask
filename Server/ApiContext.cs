using LasmartTest.Shared;
using Microsoft.EntityFrameworkCore;

namespace LasmartTest.Server
{
	public class ApiContext : DbContext
	{
		public ApiContext(DbContextOptions<ApiContext> options)
			: base(options){}
		public DbSet<Rover> Rovers { get; set; }
	}
}