using FluentValidation;
using MediatR;
using MyNotes.API.Domain.Contracts.Requests;
using MyNotes.API.Domain.Contracts.Responses;
using MyNotes.API.Domain.Entities;
using MyNotes.API.Infrastructure.APIDefinitions;
using MyNotes.API.Infrastructure.Persistance;

namespace MyNotes.API.Features.Notes.Commands
{
	public class CreateNoteEndpoint : IEndpoint
	{
		public void MapEndpoint(IEndpointRouteBuilder app)
		{
			app.MapPost("api/note", async (CreateNoteRequest request, ISender sender) =>
			{
				var result = await sender.Send(request);
				if (!result.Success)
				{
					return Results.BadRequest("Bruh");
				}
				return Results.Created("api/note", result);
			});
		}
	}

	public sealed class CreateNoteRequestValidator : AbstractValidator<CreateNoteRequest>
	{
		public CreateNoteRequestValidator()
		{
			RuleFor(c => c.Title).NotEmpty();
			RuleFor(c => c.Description).NotEmpty();
		}
	}

	public sealed class CreateNoteHandle : IRequestHandler<CreateNoteRequest, CreateNoteResponse>
	{
		private readonly IValidator<CreateNoteRequest> _validator;
		private readonly ApplicationDbContext _context;

		public CreateNoteHandle(ApplicationDbContext context, IValidator<CreateNoteRequest> validator)
		{
			_context = context;
			_validator = validator;
		}

		public async Task<CreateNoteResponse> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request, cancellationToken);

			if (!validationResult.IsValid)
			{
				return new CreateNoteResponse
				{
					Success = false,
				};
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
				return new CreateNoteResponse
				{
					Success = false,
				};
			}

			return new CreateNoteResponse { Success = true };
		}
	}
}
