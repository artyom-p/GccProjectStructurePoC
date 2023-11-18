using System.Reflection;
using FluentValidation;
using ImplementationA.Repositories;
using Project.Core.Features.Products;
using Project.Core.Features.Categories;
using Project.Api.Extensions;

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