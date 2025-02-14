using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Contracts.Repository;
using ReviewsMicroservice.ApplicationCore.Contracts.Service;
using ReviewsMicroservice.Infrastructure;
using ReviewsMicroservice.Infrastructure.Data;
using ReviewsMicroservice.Infrastructure.Repositories;
using ReviewsMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReviewDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReviewDb")));
builder.Services.AddAutoMapper(typeof(ApplicationMapper));

builder.Services.AddScoped<IReviewRepositoryAsync, ReviewRepositoryAsync>();
builder.Services.AddScoped<IReviewServiceAsync, ReviewServiceAsync>();

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
