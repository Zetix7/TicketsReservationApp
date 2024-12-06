using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TicketsReservation.DataAccess;
using TicketsReservation.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<TicketsReservationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TicketsReservationConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => options
    .WithTitle("Tickets Reservation API")
    .WithTheme(ScalarTheme.Moon)
    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
