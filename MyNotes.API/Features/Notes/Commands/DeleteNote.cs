using FluentValidation;
using MediatR;
using MyNotes.API.Infrastructure.APIDefinitions;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Commands
{
	public static partial class DeleteNote
	{
		public class Endpoint : IEndpoint
		{
			public void MapEndpoint(IEndpointRouteBuilder app)
			{
				app.MapDelete("/api/notes/{id}", async (string id, ISender sender) =>
				{
					var response = await sender.Send(new Request(Id: id));
					return response.Success ? Results.NoContent() : Results.BadRequest();
				});
			}
		}

	}
}
