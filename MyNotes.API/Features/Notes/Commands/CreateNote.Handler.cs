using FluentValidation;
using MediatR;
using MyNotes.API.Domain.Entities;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Commands
{
	public static partial class CreateNote
	{
		internal sealed class Handler : IRequestHandler<Request, Response>
		{
			private readonly IValidator<Request> _validator;
			private readonly ApplicationDbContext _context;

			public Handler(ApplicationDbContext context, IValidator<Request> validator)
			{
				_context = context;
				_validator = validator;
			}

			public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
			{
				var validationResult = await _validator.ValidateAsync(request, cancellationToken);

				if (!validationResult.IsValid)
				{
					return new Response(Success: false);
				}

				var entity = new Note
				{
					Title = request.Title,
					Description = request.Description,
				};

				try
				{
					await _context.Notes.AddAsync(entity, cancellationToken);
					await _context.SaveChangesAsync(cancellationToken);
				}
				catch (Exception)
				{
					return new Response(Success: false);
				}

				return new Response(Success: true);
			}
		}
	}
}
