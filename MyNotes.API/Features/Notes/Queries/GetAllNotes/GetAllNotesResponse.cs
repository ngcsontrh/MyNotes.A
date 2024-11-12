namespace MyNotes.API.Features.Notes.Queries.GetAllNotes
{
	public record GetAllNotesResponse(
		bool Success,
		List<GetAllNotesData>? Data = null);

	public record GetAllNotesData(
		string? Id,
		string? Title = null,
		string? Description = null);
}
