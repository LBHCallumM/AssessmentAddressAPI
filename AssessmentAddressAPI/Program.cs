using AssessmentAddressAPI.Gateways;
using AssessmentAddressAPI.Gateways.Interfaces;
using AssessmentAddressAPI.Infrastructure;
using AssessmentAddressAPI.UseCases;
using AssessmentAddressAPI.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureDbContext(builder);

builder.Services.AddTransient<IGetAddressesByPostCodeUseCase, GetAddressesByPostCodeUseCase>();
builder.Services.AddTransient<IAddressGateway, AddressGateway>();

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

static void ConfigureDbContext(WebApplicationBuilder builder)
{
    var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException($"The required environment variable 'CONNECTION_STRING' is not set.");
    }

    builder.Services.AddDbContext<AddressDbContext>(
        opt => opt
            .UseNpgsql(connectionString)
    );
}