using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Contracts.Repository;
using PromotionsMicroservice.ApplicationCore.Contracts.Service;
using PromotionsMicroservice.Infrastructure;
using PromotionsMicroservice.Infrastructure.Data;
using PromotionsMicroservice.Infrastructure.Repositories;
using PromotionsMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PromotionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PromotionDb")));
builder.Services.AddAutoMapper(typeof(ApplicationMapper));

builder.Services.AddScoped<IPromotionRepositoryAsync, PromotionRepositoryAsync>();
builder.Services.AddScoped<IPromotionServiceAsync, PromotionServiceAsync>();

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
