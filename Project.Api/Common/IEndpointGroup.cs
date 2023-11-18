namespace Project.Api.Common;

public interface IEndpointGroup
{
    static abstract string BasePath { get; }

    static virtual string[] Tags { get; } = Array.Empty<string>();

    static virtual bool OpenApiEnabled { get; set; } = true;
    
    static abstract void ConfigureEndpoints(RouteGroupBuilder builder);
}