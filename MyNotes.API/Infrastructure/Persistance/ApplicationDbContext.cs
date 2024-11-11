using Microsoft.EntityFrameworkCore;
using MyNotes.API.Domain.Entities;

namespace MyNotes.API.Infrastructure.Persistance
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Note> Notes { get; set; }
	}
}
