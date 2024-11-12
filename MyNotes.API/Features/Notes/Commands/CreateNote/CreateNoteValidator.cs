using FluentValidation;

namespace MyNotes.API.Features.Notes.Commands.CreateNote
{
	public class CreateNoteValidator : AbstractValidator<CreateNoteRequest>
	{
        public CreateNoteValidator()
        {
			RuleFor(c => c.Title).NotEmpty();
			RuleFor(c => c.Title).MaximumLength(100);
			RuleFor(c => c.Description).NotEmpty();
		}
    }
}
