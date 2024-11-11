﻿using FluentValidation;
using MediatR;
using MyNotes.API.Domain.Entities;
using MyNotes.API.Infrastructure.APIDefinitions;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Commands
{
	public static partial class CreateNote
	{
		public class Endpoint : IEndpoint
		{
			public void MapEndpoint(IEndpointRouteBuilder app)
			{
				app.MapPost("api/notes", async (Request request, ISender sender) =>
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
}
