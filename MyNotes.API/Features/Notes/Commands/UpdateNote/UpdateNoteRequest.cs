using MediatR;

namespace MyNotes.API.Features.Notes.Commands.UpdateNote
{
	public record UpdateNoteRequest(
		string Id,
		string? Title = null, 
		string? Description = null) : IRequest<UpdateNoteResponse>;
}
