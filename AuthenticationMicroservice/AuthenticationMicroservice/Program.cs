using AuthenticationMicroservice.ApplicationCore.Contracts.Repositories;
using AuthenticationMicroservice.ApplicationCore.Contracts.Services;
using AuthenticationMicroservice.Infrastucture;
using AuthenticationMicroservice.Infrastucture.Data;
using AuthenticationMicroservice.Infrastucture.Repositories;
using AuthenticationMicroservice.Infrastucture.Services;
using Microsoft.EntityFrameworkCore;
using JwtAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AccountDb")));
builder.Services.AddAutoMapper(typeof(ApplicationMapper));
builder.Services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
builder.Services.AddScoped<IUserRoleRepositoryAsync, UserRoleRepositoryAsync>();
builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();
builder.Services.AddScoped<IAuthenticationServiceAsync, AuthenticationServiceAsync>();
builder.Services.AddJwtAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
