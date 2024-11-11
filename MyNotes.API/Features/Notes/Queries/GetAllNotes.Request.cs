using MediatR;

namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetAllNotes
	{
		public record Request() : IRequest<Response>;
	}
}
