﻿using Microsoft.EntityFrameworkCore;
using MoviesApi.Model;

namespace MoviesApi.Data.Context
{
	public class AppDbContext : DbContext
	{
		#region Constructor	
		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
		#endregion Constructor	

		public DbSet<Movie> Movies { get; set; }

	}
}