using MediatR;

namespace MyNotes.API.Features.Notes.Queries.GetNoteById
{
    public record GetNoteByIdRequest(string Id) : IRequest<GetNoteByIdResponse>;

    public record GetNoteByIdData(
        string Id,
        string? Title = null,
        string? Description = null);

    public record GetNoteByIdResponse(
        bool Success,
        GetNoteByIdData? Data = null);
}
