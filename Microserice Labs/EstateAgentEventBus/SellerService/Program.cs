using Microsoft.EntityFrameworkCore;
using SellerService.Infrastructure;
using SellerService.Models;

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

builder.Services.AddDbContext<SellerContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("sqlestateagentdata")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var sellerContext = scope.ServiceProvider.GetRequiredService<SellerContext>();
        sellerContext.Database.EnsureCreated();
        sellerContext.Seed();
    }
}

app.MapGet("/sellers", async (SellerContext db) =>
    await db.Sellers.ToListAsync());

app.MapGet("/sellers/{id}", async (int id, SellerContext db) =>
    await db.Sellers.FindAsync(id)
        is Seller seller
            ? Results.Ok(seller)
            : Results.NotFound());

app.MapPost("/sellers", async (Seller seller, SellerContext db) =>
{
    db.Sellers.Add(seller);
    await db.SaveChangesAsync();

    return Results.Created($"/sellers/{seller.Id}", seller);
});

app.MapPut("/sellers/{id}", async (int id, Seller inputSeller, SellerContext db) =>
{
    var seller = await db.Sellers.FindAsync(id);

    if (seller is null) return Results.NotFound();

    seller.Surname = inputSeller.Surname;
    seller.FirstName = inputSeller.FirstName;
    seller.Address = inputSeller.Address;
    seller.Postcode = inputSeller.Postcode;
    seller.Phone = inputSeller.Phone;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/sellers/{id}", async (int id, SellerContext db) =>
{
    if (await db.Sellers.FindAsync(id) is Seller seller)
    {
        db.Sellers.Remove(seller);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();

