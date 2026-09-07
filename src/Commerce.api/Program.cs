using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.Interfaces;
using Commerce.Infrastructure.Data;
using Commerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// API endpointlarini boshqarish uchun Controllerlarni qo'shamiz.
builder.Services.AddControllers();

// API hujjatlarini yaratish uchun OpenAPI'ni qo'shamiz.
builder.Services.AddOpenApi();

// PostgreSQL bilan ishlash uchun CommonDbContext'ni sozlaymiz.
builder.Services.AddDbContext<CommonDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// IProductRepository so'ralganda ProductRepository beriladi.
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// CreateProductHandler'ni DI container'ga qo'shamiz.
builder.Services.AddScoped<CreateProductHandler>();

var app = builder.Build();

// Development muhitida OpenAPI endpointini yoqamiz.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Controllerlarni HTTP route'lar bilan bog'laymiz.
app.MapControllers();

app.Run();