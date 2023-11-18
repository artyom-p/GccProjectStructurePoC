using Project.Api.Common;

namespace Project.Api.Extensions;

public static class RouteGroupBuilderExtensions
{
    public static RouteGroupBuilder MapMinimalEndpoint<TEndpoint>(this RouteGroupBuilder builder)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(builder);
        return builder;
    }
}