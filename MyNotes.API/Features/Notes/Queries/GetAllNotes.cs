using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNotes.API.Domain.Contracts.Requests;
using MyNotes.API.Domain.Contracts.Responses;
using MyNotes.API.Infrastructure.APIDefinitions;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Queries
{
	public class GetAllNotesEndpoint : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapGet("api/notes", async (ISender sender) =>
			{
				var result = await sender.Send(new GetAllNoteRequest());
				if (result.Error)
				{
					return Results.BadRequest();
				}
				return result.Data!.Any() ? Results.Ok(result) : Results.NoContent();
			});
		}
	}

	internal sealed class Handler : IRequestHandler<GetAllNoteRequest, GetListNoteResponse>
	{
		private readonly ApplicationDbContext _context;

		public Handler(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<GetListNoteResponse> Handle(GetAllNoteRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var notes = await _context.Notes.ToListAsync();
				var response = new GetListNoteResponse
				{
					Data = notes.Select(c => new NoteDataResponse
					{
						Id = c.Id,
						Title = c.Title,
						Description = c.Description
					}).ToList()
				};
				return response;
			}
			catch (Exception)
			{
				return new GetListNoteResponse { Error = true };
			}
		}
	}
}
