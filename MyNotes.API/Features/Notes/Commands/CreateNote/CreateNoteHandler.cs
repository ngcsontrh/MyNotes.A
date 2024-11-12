using FluentValidation;
using MediatR;
using MyNotes.API.Domain.Entities;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Commands.CreateNote
{
	public class CreateNoteHandler : IRequestHandler<CreateNoteRequest, CreateNoteResponse>
	{
		private readonly IValidator<CreateNoteRequest> _validator;
		private readonly ApplicationDbContext _context;

		public CreateNoteHandler(ApplicationDbContext context, IValidator<CreateNoteRequest> validator)
		{
			_context = context;
			_validator = validator;
		}

		public async Task<CreateNoteResponse> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request, cancellationToken);

			if (!validationResult.IsValid)
			{
				return new CreateNoteResponse(Success: false);
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
				return new CreateNoteResponse(Success: false);
			}

			return new CreateNoteResponse(Success: true);
		}
	}
}