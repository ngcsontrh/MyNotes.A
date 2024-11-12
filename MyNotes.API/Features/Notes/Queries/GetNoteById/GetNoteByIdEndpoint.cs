using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNotes.API.Core.APIDefinitions;

namespace MyNotes.API.Features.Notes.Queries.GetNoteById
{
    public class GetNoteByIdEndpoint : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapGet("api/notes/{id}", async ([FromRoute] string id, ISender sender) =>
			{
				var result = await sender.Send(new GetNoteByIdRequest(Id: id));
				if (!result.Success)
				{
					return Results.NotFound();
				}
				return Results.Ok(result);
			});
		}
	}
}
