using MediatR;
using MyNotes.API.Core.APIDefinitions;

namespace MyNotes.API.Features.Notes.Queries.GetAllNotes
{
    public class GetAllNotesEndpoint : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapGet("api/notes", async (ISender sender) =>
			{
				var result = await sender.Send(new GetAllNotesRequest());
				if (!result.Success)
				{
					return Results.BadRequest();
				}
				return result.Data!.Any() ? Results.Ok(result) : Results.NoContent();
			});
		}
	}
}
