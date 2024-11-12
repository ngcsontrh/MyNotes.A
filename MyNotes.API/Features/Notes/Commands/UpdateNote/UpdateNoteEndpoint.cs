using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNotes.API.Core.APIDefinitions;

namespace MyNotes.API.Features.Notes.Commands.UpdateNote
{
	public class UpdateNoteEndpoint : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapPatch("/notes/{id}", async ([FromRoute] string id, [FromBody] UpdateNoteRequest request, ISender sender) =>
			{
				var updatedRequest = request with { Id = id };
				var result = await sender.Send(updatedRequest);
				if (!result.Success)
				{
					return Results.BadRequest();
				}
				return Results.Ok(result);
			});
		}
	}
}
