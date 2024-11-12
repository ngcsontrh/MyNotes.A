using MediatR;

namespace MyNotes.API.Features.Notes.Queries.GetAllNotes
{
	public record GetAllNotesRequest : IRequest<GetAllNotesResponse>;
}
