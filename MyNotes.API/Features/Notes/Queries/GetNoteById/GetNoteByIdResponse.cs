namespace MyNotes.API.Features.Notes.Queries.GetNoteById
{
    public record GetNoteByIdData(
        string Id,
        string? Title = null,
        string? Description = null);

    public record GetNoteByIdResponse(
        bool Success,
        GetNoteByIdData? Data = null);
}
