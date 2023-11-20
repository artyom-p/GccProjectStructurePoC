using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using FluentValidation;
using ImplementationA.Services;
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
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.MapGccEndpoints();

app.Run();