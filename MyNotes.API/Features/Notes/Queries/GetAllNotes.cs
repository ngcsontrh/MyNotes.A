using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNotes.API.Infrastructure.APIDefinitions;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetAllNotes
	{
		public class Endpoint : IEndpoint
		{
			public void MapEndpoint(IEndpointRouteBuilder app)
			{
				app.MapGet("api/notes", async (ISender sender) =>
				{
					var result = await sender.Send(new Request());
					if (!result.Success)
					{
						return Results.BadRequest();
					}
					return result.Data!.Any() ? Results.Ok(result) : Results.NoContent();
				});
			}
		}

	}

	
}
