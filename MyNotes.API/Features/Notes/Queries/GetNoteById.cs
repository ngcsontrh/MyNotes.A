using FluentValidation;
using MediatR;
using MyNotes.API.Infrastructure.APIDefinitions;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetNoteById
	{
		public class Endpoint : IEndpoint
		{
			public void MapEndpoint(IEndpointRouteBuilder app)
			{
				app.MapGet("api/notes/{:id}", async(string id, ISender sender) =>
				{
					var result = await sender.Send(new Request(id));
					if (!result.Success)
					{
						return Results.NotFound();
					}
					return Results.Ok(result);
				});
			}
		}
	}
}
