using System.Reflection;
using FluentValidation;
using ImplementationB.Api.Repositories;
using Project.Api.Extensions;
using Project.Core.Features.Products;
using Project.Core.Features.Categories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator(c =>
{
    c.ServiceLifetime = ServiceLifetime.Scoped;
});
builder.Services.AddValidatorsFromAssembly(Assembly.Load("Project.Api"));
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGccEndpoints();

app.Run();