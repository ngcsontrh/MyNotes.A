namespace MyNotes.API.Features.Notes.Commands.UpdateNote
{
	public record UpdateNoteResponse(
		bool Success,
		UpdateNoteResponseData? Data = null
		);

	public record UpdateNoteResponseData(
		string? Title = null,
		string? Description = null);
}
