using System;
using Microsoft.EntityFrameworkCore;

namespace FinanzasBE.Entities
{
	public class FinanzasContext : DbContext
	{

		public DbSet<User> Users { get; set; }
		public DbSet<Pyme> Pymes { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<Bank> Banks { get; set; }
		public DbSet<DiscountPool> DiscountPools { get; set; }
		public DbSet<Discount> Discounts { get; set; }
		public DbSet<Cost> Costs { get; set; }
		public DbSet<DiscountCost> DiscountCosts { get; set; }


		public FinanzasContext(DbContextOptions<FinanzasContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>();
			modelBuilder.Entity<Pyme>();
			modelBuilder.Entity<Bill>();
			modelBuilder.Entity<Bank>();
			modelBuilder.Entity<DiscountPool>();
			modelBuilder.Entity<Discount>();
			modelBuilder.Entity<Cost>();

			modelBuilder.Entity<DiscountCost>()
				.HasKey(x => new { x.DiscountId, x.CostId });
			modelBuilder.Entity<DiscountCost>()
				.HasOne(x => x.Discount)
				.WithMany(x => x.DiscountCosts)
				.HasForeignKey(x => x.DiscountId);
			modelBuilder.Entity<DiscountCost>()
				.HasOne(x => x.Cost)
				.WithMany(x => x.DiscountCosts)
				.HasForeignKey(x => x.CostId);


			modelBuilder.Entity<User>().HasData(
				new User()
				{
					UserId = 1,
					Username = "20123456789",
					Password = "20123456789",
					Role = Role.User
				}
			);

			modelBuilder.Entity<Pyme>().HasData(
				new Pyme
				{
					PymeId = 1,
					Ruc = "20123456789",
					Address = "no address",
					BusinessName = "PYME SAC",
					UserId = 1
				}
			);

			modelBuilder.Entity<Bill>().HasData(
				new Bill()
				{
					BillId = 1,
					Amount = 1000,
					BillType = BillType.ToPay,
					Currency = "SOLES",
					DrawerRuc = "20123456789",
					DraweeRuc = "20123456789",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					PymeId = 1
				},
				new Bill()
				{
					BillId = 2,
					Amount = 2000,
					BillType = BillType.ToCharge,
					Currency = "DOLARES",
					DrawerRuc = "20123456789",
					DraweeRuc = "20123456789",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					PymeId = 1
				},
				new Bill()
				{
					BillId = 3,
					Amount = 3000,
					BillType = BillType.Discounted,
					Currency = "SOLES",
					DrawerRuc = "20123456789",
					DraweeRuc = "20123456789",
					StartDate = DateTime.Now,
					EndDate = DateTime.Now,
					PymeId = 1
				}
			);
		}
	}
}