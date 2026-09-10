using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.GetProducts;
using Commerce.Application.Products.Interfaces;
using Commerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Commerce.Infrastructure.Data;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CommonDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<GetProductsHandler>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Swagger JSON va Swagger UI'ni yoqamiz.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();