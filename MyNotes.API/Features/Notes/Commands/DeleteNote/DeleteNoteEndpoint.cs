using MediatR;
using MyNotes.API.Core.APIDefinitions;

namespace MyNotes.API.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteEndpoint : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapDelete("/api/notes/{id}", async (string id, ISender sender) =>
			{
				var response = await sender.Send(new DeleteNoteRequest(Id: id));
				return response.Success ? Results.NoContent() : Results.BadRequest();
			});
		}
	}
}
