using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Praxis.Infrastructure.Persistence;
using Praxis.Application.Interfaces;
using Praxis.Infrastructure.Repositories;
using Praxis.Application.Events.CreateEvent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// - Add the database context to the service container
builder.Services.AddDbContext<PraxisDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// - Repository registrations
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();

// - Service registrations
builder.Services.AddScoped<CreateEventService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
