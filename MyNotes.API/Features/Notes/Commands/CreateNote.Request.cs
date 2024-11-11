using MediatR;
namespace MyNotes.API.Features.Notes.Commands
{
	public static partial class CreateNote
	{
		public record Request(string Title, string Description) : IRequest<Response>;
	}
}
