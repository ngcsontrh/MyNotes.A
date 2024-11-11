using MediatR;

namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetNoteById
	{
		public record Request(string Id) : IRequest<Response>;
	}
}
