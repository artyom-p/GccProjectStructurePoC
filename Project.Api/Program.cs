using FluentValidation;
using Project.Api.Extensions;

// This project is used as an API definition, swagger is generated from it

var builder = WebApplication.CreateSlimBuilder(args);

builder.Host.UseDefaultServiceProvider(c =>
{
    c.ValidateScopes = false;
    c.ValidateOnBuild = false;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator(options =>
{
    options.ServiceLifetime = ServiceLifetime.Scoped;
});

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGccEndpoints();

app.Run();