using MediatR;
using Microsoft.EntityFrameworkCore;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetAllNotes
	{
		internal sealed class Handler : IRequestHandler<Request, Response>
		{
			private readonly ApplicationDbContext _context;

			public Handler(ApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
			{
				try
				{
					var notes = await _context.Notes.ToListAsync(cancellationToken);
					var response = new Response
					(
						Success: true,
						Data: notes.Select(c => new Data(c.Id, c.Title, c.Description)).ToList()
					);
					return response;
				}
				catch (Exception)
				{
					return new Response(Success: false);
				}
			}
		}
	}
}
