using Ride.Application.Features.RequestRide;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();   // before builder.Build()
builder.Services.AddScoped<RequestRideHandler>();
var app = builder.Build();

app.MapControllers();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();
