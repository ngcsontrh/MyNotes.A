namespace MyNotes.API.Domain.Contracts.Responses
{
	public record NoteDataResponse
	{
		public string Id { get; set; } = null!;
		public string? Title { get; set; }
		public string? Description { get; set; }
	}

	public record CreateNoteResponse
	{
		public bool Success { get; set; }
	}

	public record GetNoteResponse
	{
		public bool Error { get; set; }
		public NoteDataResponse? Data { get; set; }
	}

	public record GetListNoteResponse
	{
		public bool Error { get; set; }
		public List<NoteDataResponse>? Data { get; set; }
	}
}
