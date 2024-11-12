using MediatR;

namespace MyNotes.API.Features.Notes.Commands.DeleteNote
{
	public record DeleteNoteRequest(string Id) : IRequest<DeleteNoteResponse>;
}
