namespace MyNotes.API.Core.APIDefinitions
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
