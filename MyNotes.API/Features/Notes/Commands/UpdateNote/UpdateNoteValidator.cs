using FluentValidation;

namespace MyNotes.API.Features.Notes.Commands.UpdateNote
{
	public class UpdateNoteValidator : AbstractValidator<UpdateNoteRequest>
	{
		public UpdateNoteValidator()
		{
			RuleFor(c => c.Id).NotNull();
			RuleFor(c => c.Title).MaximumLength(100);
		}
	}
}
