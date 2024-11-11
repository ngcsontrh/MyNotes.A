namespace MyNotes.API.Infrastructure.APIDefinitions
{
	public interface IEndpoint
	{
		void MapEndpoint(IEndpointRouteBuilder app);
	}
}
