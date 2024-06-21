using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

//using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


//using Microsoft.EntityFrameworkCore;

namespace SetUpEstateAgentDBWeb.Models
{
    public class EstateAgentContext : DbContext
    {
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        public EstateAgentContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed initial data
            modelBuilder.Entity<Buyer>().HasData(
                (new Buyer
                {
                    Id = 1,
                    FirstName = "Patel",
                    Surname = "Sadia",
                    Address = "1 the High Street",
                    Postcode = "AV1 1VA",
                    Phone = "08700456789"
                }),
                new Buyer
                {
                    Id = 2,
                    FirstName = "Kamran",
                    Surname = "Liaqat",
                    Address = "2 the Low Street",
                    Postcode = "AV2 2VA",
                    Phone = "08700123654"
                },
                new Buyer
                {
                    Id = 3,
                    FirstName = "Saeed",
                    Surname = "Mirza",
                    Address = "5 the Round Street",
                    Postcode = "AV5 5VA",
                    Phone = "08700555555"
                });
            modelBuilder.Entity<Seller>().HasData(
                new Seller
                {
                    Id = 1,
                    FirstName = "Dilpreet",
                    Surname = "Baradaran",
                    Address = "3 the Long Street",
                    Postcode = "AV3 3VA",
                    Phone = "08700333333"
                },
                new Seller
                {
                    Id = 2,
                    FirstName = "Kofi",
                    Surname = "Dhillon",
                    Address = "2 the Short Street",
                    Postcode = "AV4 4VA",
                    Phone = "087004444444"
                });
            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Address = "3 the Avenue",
                    Postcode = "TA1 1AT",
                    Type = "HOUSE",
                    Bedrooms = 4,
                    Garden = true,
                    Price = 450000m,
                    Status = "FORSALE",
                    SellerId = 1,
                    BuyerId = null

                },
                new Property
                {
                    Id = 2,
                    Address = "Flat 4, the Avenue",
                    Postcode = "TA2 2AT",
                    Type = "FLAT",
                    Bedrooms = 2,
                    Garden = false,
                    Price = 300000m,
                    Status = "FORSALE",
                    SellerId = 2,
                    BuyerId = null
                },
                new Property
                {
                    Id = 3,
                    Address = "5 the Road",
                    Postcode = "TA2 2AT",
                    Type = "BUNGALOW",
                    Bedrooms = 3,
                    Garden = true,
                    Price = 350000m,
                    Status = "FORSALE",
                    SellerId = 3,
                    BuyerId = null

                },
                new Property
                {
                    Id = 4,
                    Address = "7 the Road",
                    Postcode = "TA2 2AT",
                    Type = "HOUSE",
                    Bedrooms = 4,
                    Garden = true,
                    Price = 500000m,
                    Status = "FORSALE",
                    SellerId = 4,
                    BuyerId = null
                });
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BuyerId = 2,
                    PropertyId = 2,
                    Time = DateTime.Now.AddDays(7)
                },
                new Booking
                {
                    Id = 2,
                    BuyerId = 3,
                    PropertyId = 3,
                    Time = DateTime.Now.AddDays(14)
                },
                new Booking
                {
                    Id = 3,
                    BuyerId = 1,
                    PropertyId = 4,
                    Time = DateTime.Now.AddDays(8)
                });
        }

    }
}
