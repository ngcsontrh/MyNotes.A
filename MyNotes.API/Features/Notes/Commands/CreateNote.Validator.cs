using FluentValidation;

namespace MyNotes.API.Features.Notes.Commands
{
	public static partial class CreateNote
	{
		public sealed class Validator : AbstractValidator<Request>
		{
			public Validator()
			{
				RuleFor(c => c.Title).NotEmpty();
				RuleFor(c => c.Description).NotEmpty();
			}
		}
	}
}
