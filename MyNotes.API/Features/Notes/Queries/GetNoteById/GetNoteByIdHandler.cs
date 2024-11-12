using FluentValidation;
using MediatR;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Queries.GetNoteById
{
	public class GetNoteByIdHandler : IRequestHandler<GetNoteByIdRequest, GetNoteByIdResponse>
	{
		private readonly IValidator<GetNoteByIdRequest> _validator;
		private readonly ApplicationDbContext _context;

		public GetNoteByIdHandler(IValidator<GetNoteByIdRequest> validator, ApplicationDbContext context)
		{
			_context = context;
			_validator = validator;
		}

		public async Task<GetNoteByIdResponse> Handle(GetNoteByIdRequest request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request);
			if (!validationResult.IsValid)
			{
				return new GetNoteByIdResponse(
					Success: false);
			}

			try
			{
				var entity = await _context.Notes.FindAsync(request.Id);
				if (entity == null)
				{
					return new GetNoteByIdResponse(Success: false);
				}
				return new GetNoteByIdResponse(
					Success: true,
					Data: new GetNoteByIdData(entity.Id, entity.Title, entity.Description));
			}
			catch (Exception)
			{
				return new GetNoteByIdResponse(Success: false);
			}
		}
	}
}
