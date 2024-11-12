using FluentValidation;
using MediatR;

namespace MyNotes.API.Features.Notes.Queries.GetNoteById
{
	public class GetNoteByIdValidator : AbstractValidator<GetNoteByIdRequest>
	{
		public GetNoteByIdValidator()
		{
			RuleFor(c => c.Id).NotEmpty();
		}
	}
}
