using Microsoft.EntityFrameworkCore;
using MyNotes.API.Domain.Entities;
using System.Reflection;

namespace MyNotes.API.Infrastructure.Persistance
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<Note>? Notes { get; set; }
	}
}
