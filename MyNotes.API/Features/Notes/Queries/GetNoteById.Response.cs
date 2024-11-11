namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetNoteById
	{
		public record Data(
		string Id,
		string? Title = null,
		string? Description = null);

		public record Response(
			bool Success,
			Data? Data = null);
	}
}
