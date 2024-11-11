using FluentValidation;
using MediatR;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Commands
{
	public static partial class DeleteNote
	{
		internal sealed class DeleteNoteHandler : IRequestHandler<Request, Response>
		{
			private readonly IValidator<Request> _validator;
			private readonly ApplicationDbContext _context;

			public DeleteNoteHandler(IValidator<Request> validator, ApplicationDbContext context)
			{
				_validator = validator;
				_context = context;
			}

			public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
			{
				var validationResult = await _validator.ValidateAsync(request, cancellationToken);

				if (!validationResult.IsValid)
				{
					return new Response(false);
				}

				var entity = await _context.Notes.FindAsync(request.Id, cancellationToken);
				if (entity == null)
				{
					return new Response(false);
				}

				_context.Notes.Remove(entity);
				await _context.SaveChangesAsync(cancellationToken);

				return new Response(true);
			}
		}
	}
}
