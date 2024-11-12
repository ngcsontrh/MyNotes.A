using FluentValidation;
using MediatR;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Commands.UpdateNote
{
	public class UpdateNoteHandler : IRequestHandler<UpdateNoteRequest, UpdateNoteResponse>
	{
		private readonly ApplicationDbContext _context;
		private readonly IValidator<UpdateNoteRequest> _validator;

        public UpdateNoteHandler(ApplicationDbContext context, IValidator<UpdateNoteRequest> validator)
        {
			_context = context;
			_validator = validator;
        }

        public async Task<UpdateNoteResponse> Handle(UpdateNoteRequest request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request);
			if (!validationResult.IsValid)
			{
				return new UpdateNoteResponse(false);
			}
			var entity = await _context.Notes.FindAsync(request.Id);
			if (entity == null)
			{
				return new UpdateNoteResponse(false);
			}
			entity.UpdateIgnoreNull(request);
			_context.Notes.Update(entity);
			await _context.SaveChangesAsync(cancellationToken);

			return new UpdateNoteResponse(
				true,
				new UpdateNoteResponseData(
					entity.Title,
					entity.Description));
		}
	}
}
