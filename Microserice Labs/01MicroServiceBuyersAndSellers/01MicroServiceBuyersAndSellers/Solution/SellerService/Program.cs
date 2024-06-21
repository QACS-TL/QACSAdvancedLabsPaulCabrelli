
using Microsoft.EntityFrameworkCore;
using SellerService.Infrastructure;
using SellerService.Models;

namespace SellerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SellerContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("sqlestateagentdata")));

            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/sellers", async (SellerContext db) =>
                await db.Sellers.ToListAsync());

            app.MapPost("/sellers", async (Seller seller, SellerContext db) =>
            {
                db.Sellers.Add(seller);
                await db.SaveChangesAsync();

                return Results.Created($"/sellers/{seller.Id}", seller);
            });

            app.Run();
        }
    }
}
