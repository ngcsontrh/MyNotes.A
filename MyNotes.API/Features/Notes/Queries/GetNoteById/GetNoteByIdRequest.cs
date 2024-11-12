using MediatR;

namespace MyNotes.API.Features.Notes.Queries.GetNoteById
{
	public record GetNoteByIdRequest(string Id) : IRequest<GetNoteByIdResponse>;
}
