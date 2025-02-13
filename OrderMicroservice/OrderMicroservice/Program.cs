using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.Infrastructure;
using OrderAPI.Infrastructure.Data;
using OrderAPI.Infrastructure.Repositories;
using OrderAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderDb")));
builder.Services.AddAutoMapper(typeof(ApplicationMapper));
builder.Services.AddScoped<IAddressRepositoryAsync, AddressRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IOrderDetailRepositoryAsync, OrderDetailsRepositoryAsync>();
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IPaymentMethodRepositoryAsync, PaymentMethodRespositoryAsync>();
builder.Services.AddScoped<IShoppingCartItemRepositoryAsync, ShoppingCartItemRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartRepositoryAsync, ShoppingCartRepositoryAsync>();
builder.Services.AddScoped<IUserAddressRepositoryAsync, UserAddressRepositoryAsync>();

builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<IPaymentServiceAsync, PaymentServiceAsync>();
builder.Services.AddScoped<IShoppingCartItemServiceAsync, ShoppingCartItemServiceAsync>();
builder.Services.AddScoped<IShoppingCartServiceAsync, ShoppingCartServiceAsync>();

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
