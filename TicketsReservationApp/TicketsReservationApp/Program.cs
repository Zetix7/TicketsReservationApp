using MediatR;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TicketsReservation.ApplicationServices.API.Domain;
using TicketsReservation.DataAccess;
using TicketsReservation.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<TicketsReservationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TicketsReservationConnection")));
builder.Services.AddMediatR(typeof(ResponseBase<>));

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
