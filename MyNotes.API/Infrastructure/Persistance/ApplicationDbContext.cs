using Microsoft.EntityFrameworkCore;
using MyNotes.API.Domain.Entities;
using System.Reflection;

namespace MyNotes.API.Infrastructure.Persistance
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<Note> Notes { get; set; }
	}
}
