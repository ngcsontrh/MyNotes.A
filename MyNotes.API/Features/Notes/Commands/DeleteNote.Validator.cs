using FluentValidation;

namespace MyNotes.API.Features.Notes.Commands
{
	public static partial class DeleteNote
	{
		public class Validator : AbstractValidator<Request>
		{
			public Validator()
			{
				RuleFor(c => c.Id).NotEmpty();
			}
		}
	}
}
