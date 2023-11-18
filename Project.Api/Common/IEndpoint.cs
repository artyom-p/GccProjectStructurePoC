namespace Project.Api.Common;

public interface IEndpoint
{
    static abstract IEndpointConventionBuilder Map(IEndpointRouteBuilder builder);
}