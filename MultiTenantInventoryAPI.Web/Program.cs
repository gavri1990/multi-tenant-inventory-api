using Microsoft.EntityFrameworkCore;
using MultiTenantInventoryAPI.Core.Interfaces;
using MultiTenantInventoryAPI.Infrastructure.Data;
using MultiTenantInventoryAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");  //looks up the merged appsettings.*.json files
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, o => o.UseCompatibilityLevel(170))); //SQL Server 2025 compatibility

builder.Services.AddScoped<ISubscriptionTypeRepository, SubscriptionTypeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
