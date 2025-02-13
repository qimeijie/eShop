using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Contracts.Service;
using ShippingMicroservice.Infrastructure;
using ShippingMicroservice.Infrastructure.Data;
using ShippingMicroservice.Infrastructure.Repositories;
using ShippingMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShippingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDb")));
builder.Services.AddAutoMapper(typeof(ApplicationMapper));

builder.Services.AddScoped<IRegionRepositoryAsync, RegionRepotitoryAsync>();
builder.Services.AddScoped<IShipperRepositoryAsync, ShipperRepositoryAsync>();
builder.Services.AddScoped<IShipperServiceAsync, ShipperServicesAsync>();

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
