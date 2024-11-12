using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNotes.API.Domain.Entities;

namespace MyNotes.API.Infrastructure.Persistance.Configs
{
	public class NoteConfig : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Title).HasMaxLength(100);
		}
	}
}
