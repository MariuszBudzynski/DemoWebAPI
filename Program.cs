using DemoApps.MockRepository;
using DemoApps.Repositories;
using Microsoft.EntityFrameworkCore;
using WebAPIdemo.Models;
using WebAPIdemo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebAPIdbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDemo")));

builder.Services.AddScoped<IProductRepository, ProductRepository>(); //Use Mock Repository for local testing
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
