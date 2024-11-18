using MediatR;

namespace MyNotes.API.Features.Notes.Commands.DeleteNote
{
    public record DeleteNoteRequest(string Id) : IRequest<DeleteNoteResponse>;

    public record DeleteNoteResponse(bool Success);
}
