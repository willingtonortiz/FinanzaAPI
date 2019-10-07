using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.Entities
{
	public class FinanzasContext : DbContext
	{

		public DbSet<User> Users { get; set; }
		public DbSet<Pyme> Pymes { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<Bank> Banks { get; set; }
		

		public FinanzasContext(DbContextOptions<FinanzasContext> options) : base(options)
		{
		}

		// protected override void OnModelCreating(ModelBuilder modelBuilder)
		// {
		// }
	}
}