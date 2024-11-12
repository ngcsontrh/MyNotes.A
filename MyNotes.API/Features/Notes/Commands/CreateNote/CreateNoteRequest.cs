using MediatR;

namespace MyNotes.API.Features.Notes.Commands.CreateNote
{
	public record CreateNoteRequest(
		string Title, 
		string Description) : IRequest<CreateNoteResponse>;
}
