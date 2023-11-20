using System.Reflection;
using FluentValidation;
using ImplementationA.Services;
using Project.Api.Extensions;
using Project.Core.Features.Categories;
using Project.Core.Features.Products;

var builder = WebApplication.CreateSlimBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.WebHost.UseKestrelHttpsConfiguration();
}

builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator(c =>
{
    c.ServiceLifetime = ServiceLifetime.Scoped;
});

// TODO: convert to AOT friendly
builder.Services.AddValidatorsFromAssembly(Assembly.Load("Project.Api"));

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

var app = builder.Build();

app.UseStatusCodePages();

if (!app.Environment.IsDevelopment())
{
    app.UseProblemDetailsExceptionHandler();
}

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGccEndpoints();

app.Run();