using FluentValidation;

namespace MyNotes.API.Features.Notes.Commands.DeleteNote
{
	public class DeleteNoteValidation : AbstractValidator<DeleteNoteRequest>
	{
        public DeleteNoteValidation()
		{
			RuleFor(c => c.Id).NotEmpty();
		}
	}
}
