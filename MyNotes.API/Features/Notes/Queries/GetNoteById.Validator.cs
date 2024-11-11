using FluentValidation;

namespace MyNotes.API.Features.Notes.Queries
{
	public static partial class GetNoteById
	{
		public sealed class Validator : AbstractValidator<Request>
		{
			public Validator()
			{
				RuleFor(c => c.Id).NotEmpty();
			}
		}
	}
}
