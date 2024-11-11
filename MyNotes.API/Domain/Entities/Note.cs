namespace MyNotes.API.Domain.Entities
{
	public class Note
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string? Title { get; set; }
		public string? Description { get; set; }
	}
}
