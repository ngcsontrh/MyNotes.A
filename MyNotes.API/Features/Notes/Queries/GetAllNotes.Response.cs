namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetAllNotes
	{
		public record Data(
			string? Id,
			string? Title = null,
			string? Description = null);

		public record Response(
			bool Success,
			List<Data>? Data = null);
	}
}
