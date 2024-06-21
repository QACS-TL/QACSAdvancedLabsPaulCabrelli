using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SetUpEstateAgentDBWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    BOOKING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BUYER_ID = table.Column<int>(type: "int", nullable: false),
                    PROPERTY_ID = table.Column<int>(type: "int", nullable: false),
                    TIME = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.BOOKING_ID);
                });

            migrationBuilder.CreateTable(
                name: "buyer",
                columns: table => new
                {
                    BUYER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    POSTCODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PHONE = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyer", x => x.BUYER_ID);
                });

            migrationBuilder.CreateTable(
                name: "property",
                columns: table => new
                {
                    PROPERTY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADDRESS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    POSTCODE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    NUMBER_OF_BEDROOMS = table.Column<int>(type: "int", nullable: false),
                    NUMBER_OF_BATHROOMS = table.Column<int>(type: "int", nullable: false),
                    GARDEN = table.Column<bool>(type: "bit", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    STATUS = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    SELLER_ID = table.Column<int>(type: "int", nullable: false),
                    BUYER_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property", x => x.PROPERTY_ID);
                });

            migrationBuilder.CreateTable(
                name: "seller",
                columns: table => new
                {
                    SELLER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    POSTCODE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seller", x => x.SELLER_ID);
                });

            migrationBuilder.InsertData(
                table: "booking",
                columns: new[] { "BOOKING_ID", "BUYER_ID", "PROPERTY_ID", "TIME" },
                values: new object[,]
                {
                    { 1, 2, 2, new DateTime(2024, 6, 27, 15, 41, 56, 646, DateTimeKind.Local).AddTicks(4916) },
                    { 2, 3, 3, new DateTime(2024, 7, 4, 15, 41, 56, 646, DateTimeKind.Local).AddTicks(4966) },
                    { 3, 1, 4, new DateTime(2024, 6, 28, 15, 41, 56, 646, DateTimeKind.Local).AddTicks(4969) }
                });

            migrationBuilder.InsertData(
                table: "buyer",
                columns: new[] { "BUYER_ID", "ADDRESS", "FIRST_NAME", "PHONE", "POSTCODE", "SURNAME" },
                values: new object[,]
                {
                    { 1, "1 the High Street", "Patel", "08700456789", "AV1 1VA", "Sadia" },
                    { 2, "2 the Low Street", "Kamran", "08700123654", "AV2 2VA", "Liaqat" },
                    { 3, "5 the Round Street", "Saeed", "08700555555", "AV5 5VA", "Mirza" }
                });

            migrationBuilder.InsertData(
                table: "property",
                columns: new[] { "PROPERTY_ID", "ADDRESS", "NUMBER_OF_BATHROOMS", "NUMBER_OF_BEDROOMS", "BUYER_ID", "GARDEN", "POSTCODE", "PRICE", "SELLER_ID", "STATUS", "TYPE" },
                values: new object[,]
                {
                    { 1, "3 the Avenue", 0, 4, null, true, "TA1 1AT", 450000m, 1, "FORSALE", "HOUSE" },
                    { 2, "Flat 4, the Avenue", 0, 2, null, false, "TA2 2AT", 300000m, 2, "FORSALE", "FLAT" },
                    { 3, "5 the Road", 0, 3, null, true, "TA2 2AT", 350000m, 3, "FORSALE", "BUNGALOW" },
                    { 4, "7 the Road", 0, 4, null, true, "TA2 2AT", 500000m, 4, "FORSALE", "HOUSE" }
                });

            migrationBuilder.InsertData(
                table: "seller",
                columns: new[] { "SELLER_ID", "ADDRESS", "FIRST_NAME", "PHONE", "POSTCODE", "SURNAME" },
                values: new object[,]
                {
                    { 1, "3 the Long Street", "Dilpreet", "08700333333", "AV3 3VA", "Baradaran" },
                    { 2, "2 the Short Street", "Kofi", "087004444444", "AV4 4VA", "Dhillon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "buyer");

            migrationBuilder.DropTable(
                name: "property");

            migrationBuilder.DropTable(
                name: "seller");
        }
    }
}
