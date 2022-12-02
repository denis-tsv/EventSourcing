using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Web.DataAccess.Postgres;
using Shop.Web.Infrastructure;
using Shop.Web.Infrastructure.Interfaces;
using Shop.Web.UseCases.Orders.Commands.CreateOrder;
using Shop.Web.UseCases.Orders.Utils;
using Shop.Web.UseCases.Orders.Utils.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(s =>
    {
        s.RegisterValidatorsFromAssemblyContaining<CreateOrderDtoValidator>();
    });
builder.Services.AddRouting(x => x.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(CreateOrderCommand));
builder.Services.AddAutoMapper(typeof(OrderProfile));

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddDbContext<IReadDbContext, AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

builder.Services.AddScoped<IAggregateStore, SqlAggregateStore>();
builder.Services.AddSingleton<ICurrentUserService, TestCurrentUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
