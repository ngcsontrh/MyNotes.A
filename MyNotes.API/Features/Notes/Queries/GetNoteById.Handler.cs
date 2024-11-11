using FluentValidation;
using MediatR;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetNoteById
	{
		internal sealed class GetNoteByIdHandler : IRequestHandler<Request, Response>
		{
			private readonly IValidator<Request> _validator;
			private readonly ApplicationDbContext _context;

			public GetNoteByIdHandler(IValidator<Request> validator, ApplicationDbContext context)
			{
				_context = context;
				_validator = validator;
			}

			public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
			{
				var validationResult = await _validator.ValidateAsync(request);
				if (!validationResult.IsValid)
				{
					return new Response(
						Success: false);
				}

				try
				{
					var entity = await _context.Notes.FindAsync(request.Id);
					if (entity == null)
					{
						return new Response(Success: false);
					}
					return new Response(
						Success: true,
						Data: new Data(entity.Id, entity.Title, entity.Description));
				}
				catch (Exception)
				{
					return new Response(Success: false);
				}
			}
		}
	}
}
