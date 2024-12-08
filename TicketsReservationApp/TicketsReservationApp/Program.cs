using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TicketsReservation.ApplicationServices.API.Domain;
using TicketsReservation.ApplicationServices.Mappings;
using TicketsReservation.DataAccess;
using TicketsReservation.DataAccess.CQRS.Queries;
using TicketsReservation.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<TicketsReservationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TicketsReservationConnection")));
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(ResponseBase<>).Assembly));
builder.Services.AddAutoMapper(typeof(ClientsProfile).Assembly);
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

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
