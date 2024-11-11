using MediatR;
using MyNotes.API.Domain.Contracts.Responses;
namespace MyNotes.API.Domain.Contracts.Requests
{
	public record GetAllNoteRequest : IRequest<GetListNoteResponse>;

	public record CreateNoteRequest : IRequest<CreateNoteResponse>
	{
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
	}
}
