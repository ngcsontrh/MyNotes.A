using MediatR;

namespace MyNotes.API.Features.Notes.Commands
{
	public static partial class DeleteNote
	{
		public record Request(string Id) : IRequest<Response>;
	}
}
