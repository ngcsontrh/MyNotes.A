using MediatR;

namespace MyNotes.API.Features.Notes.Commands.UpdateNote
{
    public record UpdateNoteRequest(
        string Id,
        string? Title = null,
        string? Description = null) : IRequest<UpdateNoteResponse>;

    public record UpdateNoteResponse(
        bool Success,
        UpdateNoteResponseData? Data = null
        );

    public record UpdateNoteResponseData(
        string? Title = null,
        string? Description = null);
}
