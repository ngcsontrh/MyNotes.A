using FluentValidation;
using MediatR;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Commands.DeleteNote
{
	public class DeleteNoteHandler : IRequestHandler<DeleteNoteRequest, DeleteNoteResponse>
	{
		private readonly IValidator<DeleteNoteRequest> _validator;
		private readonly ApplicationDbContext _context;

		public DeleteNoteHandler(IValidator<DeleteNoteRequest> validator, ApplicationDbContext context)
		{
			_validator = validator;
			_context = context;
		}

		public async Task<DeleteNoteResponse> Handle(DeleteNoteRequest request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request, cancellationToken);

			if (!validationResult.IsValid)
			{
				return new DeleteNoteResponse(false);
			}

			var entity = await _context.Notes.FindAsync(request.Id, cancellationToken);
			if (entity == null)
			{
				return new DeleteNoteResponse(false);
			}

			_context.Notes.Remove(entity);
			await _context.SaveChangesAsync(cancellationToken);

			return new DeleteNoteResponse(true);
		}
	}
}
