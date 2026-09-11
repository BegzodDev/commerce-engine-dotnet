using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.GetProducts;
using Commerce.Application.Products.Interfaces;
using Commerce.Application.Products.UpdateProduct;
using Commerce.Infrastructure.Data;
using Commerce.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<UpdateProductHandler>();
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