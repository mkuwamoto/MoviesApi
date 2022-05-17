using Microsoft.EntityFrameworkCore;
using MoviesApi.Model;

namespace MoviesApi.Data.Context
{
	public class AppDbContext : DbContext
	{
		#region Constructor	
		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
		#endregion Constructor	

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Address>()
				.HasOne(address => address.Theater)
				.WithOne(theater => theater.Address)
				.HasForeignKey<Theater>(theater => theater.AddressId);
		}

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Theater> Theaters { get; set; }
		public DbSet<Address> Address { get; set; }

	}
}
