using MediatR;
using MyNotes.API.Core.APIDefinitions;

namespace MyNotes.API.Features.Notes.Commands.CreateNote
{
    public class CreateNoteEndpoint : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapPost("api/notes", async (CreateNoteRequest request, ISender sender) =>
			{
				var result = await sender.Send(request);
				if (!result.Success)
				{
					return Results.BadRequest("Bruh");
				}
				return Results.Created();
			});
		}
	}
}
