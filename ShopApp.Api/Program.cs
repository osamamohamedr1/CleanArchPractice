using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopApp.Api.Middlewares;
using ShopApp.Application;
using ShopApp.Application.Behaviors;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Infrastructure.Data;
using ShopApp.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var constr= builder.Configuration.GetConnectionString("DefaultConnection")??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(connectionString:constr));
// mediatr
builder.Services.AddMediatR(cfg =>
{       // application assembly marker
    cfg.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly);
});
//fluentValidtion
builder.Services.AddValidatorsFromAssembly(typeof(IAssemblyMarker).Assembly);
//validtion Pipline
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>(); 
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandler();

app.Run();
