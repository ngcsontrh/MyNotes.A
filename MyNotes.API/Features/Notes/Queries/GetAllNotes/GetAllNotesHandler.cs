using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Queries.GetAllNotes
{
	public class GetAllNotesHandler : IRequestHandler<GetAllNotesRequest, GetAllNotesResponse>
	{
		private readonly ApplicationDbContext _context;

		public GetAllNotesHandler(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<GetAllNotesResponse> Handle(GetAllNotesRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var notes = await _context.Notes.AsNoTracking().ToListAsync(cancellationToken);
				var response = new GetAllNotesResponse
				(
					Success: true,
					Data: notes.Select(c => new GetAllNotesData(c.Id, c.Title, c.Description)).ToList()
				);
				return response;
			}
			catch (Exception)
			{
				return new GetAllNotesResponse(Success: false);
			}
		}
	}
}
