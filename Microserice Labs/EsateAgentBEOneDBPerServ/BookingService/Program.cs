using Microsoft.EntityFrameworkCore;
using BookingService.Infrastructure;
using BookingService.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //Needed for Cors

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            //policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddDbContext<BookingContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("sqlestateagentdata")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var bookingContext = scope.ServiceProvider.GetRequiredService<BookingContext>();
        bookingContext.Database.EnsureCreated();
        bookingContext.Seed();
    }
}

app.MapGet("/bookings", async (BookingContext db) =>
    await db.Bookings.ToListAsync());

app.MapGet("/bookings/{id}", async (int id, BookingContext db) =>
    await db.Bookings.FindAsync(id)
        is Booking booking
            ? Results.Ok(booking)
            : Results.NotFound());

app.MapPost("/bookings", async (Booking booking, BookingContext db) =>
{
    db.Bookings.Add(booking);
    await db.SaveChangesAsync();

    return Results.Created($"/bookings/{booking.Id}", booking);
});

app.MapPut("/bookings/{id}", async (int id, Booking inputBooking, BookingContext db) =>
{
    var booking = await db.Bookings.FindAsync(id);

    if (booking is null) return Results.NotFound();

    booking.BuyerId = inputBooking.BuyerId;
    booking.PropertyId = inputBooking.PropertyId;
    booking.Time = inputBooking.Time;


    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/bookings/{id}", async (int id, BookingContext db) =>
{
    if (await db.Bookings.FindAsync(id) is Booking booking)
    {
        db.Bookings.Remove(booking);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();

