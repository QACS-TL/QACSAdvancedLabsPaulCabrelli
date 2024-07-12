using Microsoft.EntityFrameworkCore;
using Events;

using BookingService.Infrastructure;
using BookingService.Models;
using BookingService.DomainEventHandlers;
using BookingService.Repository;
using Events.Common;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; //Needed for Cors

// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddApplicationServices();
//builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            //policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

// Configure MassTransit with RabbitMQ
//builder.Services.AddMassTransit(x =>
//{
//    x.AddConsumer<PropertyDeletedEventConsumer>();

//    x.UsingRabbitMq((context, cfg) =>
//    {
//        //cfg.Host("rabbitmq://localhost");
//        //cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
//        cfg.Host(new Uri(@"amqp://localhost:5672/"), h => {
//            h.Username("guest");
//            h.Password("guest");
//        });

//        cfg.ReceiveEndpoint(EventBusConstants.DeletePropertyQueue, e =>
//        {
//            e.ConfigureConsumer<PropertyDeletedEventConsumer>(context);
//        });
//    });
//});
builder.Services.AddDbContext<BookingContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("sqlestateagentdata")));

builder.Services.AddCap(options =>
{
    options.UseEntityFramework<BookingContext>();
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlestateagentdata"));
    options.UseRabbitMQ(options =>
    {
        options.ConnectionFactoryOptions = options =>
        {
            options.Ssl.Enabled = false;
            options.HostName = "rabbitmq";
            options.UserName = "guest";
            options.Password = "guest";
            options.Port = 5672;
            //options.DispatchConsumersAsync = false;
            //options.ConsumerDispatchConcurrency = 1;
        };
    });
});

//builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddMassTransitHostedService();
builder.Services.AddScoped<PropertyDeletedEventSubscriber>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddEndpointsApiExplorer();

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

app.MapGet("/bookings", async (IBookingRepository bookingRepository) =>
    await bookingRepository.GetBookingsAsync());

app.MapGet("/bookings/{id}", async (int id, IBookingRepository bookingRepository) =>
    await bookingRepository.GetBookingByIdAsync(id)
        is Booking booking
            ? Results.Ok(booking)
            : Results.NotFound());

app.MapPost("/bookings", async (Booking booking, IBookingRepository bookingRepository) =>
{
    Booking b = await bookingRepository.AddBookingAsync(booking);
    return Results.Created($"/bookings/{booking.Id}", b);
});

app.MapPut("/bookings/{id}", async (int id, Booking inputBooking, IBookingRepository bookingRepository) =>
{
    return await bookingRepository.UpdateBookingAsync(inputBooking);
});

app.MapDelete("/bookings/{id}", async (int id, IBookingRepository bookingRepository, BookingContext context) =>
{
    var booking = await bookingRepository.GetBookingByIdAsync(id);
    if (booking == null)
    {
        return Results.NotFound();
    }

    await bookingRepository.DeleteBookingByBookingIdAsync(id, context);

    // Publish the PropertyDeletedEvent
    //await publishEndpoint.Publish(new PropertyDeletedEvent { PropertyId = id });

    return Results.NoContent();
});

app.Run();

