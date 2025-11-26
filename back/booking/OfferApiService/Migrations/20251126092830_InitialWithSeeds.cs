using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OfferApiService.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "numeric", nullable: false),
                    PricePerWeek = table.Column<decimal>(type: "numeric", nullable: true),
                    PricePerMonth = table.Column<decimal>(type: "numeric", nullable: true),
                    Deposit = table.Column<decimal>(type: "numeric", nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    Tax = table.Column<decimal>(type: "numeric", nullable: true),
                    MinRentDays = table.Column<int>(type: "integer", nullable: false),
                    AllowPets = table.Column<bool>(type: "boolean", nullable: false),
                    AllowSmoking = table.Column<bool>(type: "boolean", nullable: false),
                    AllowChildren = table.Column<bool>(type: "boolean", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    RentObjId = table.Column<int>(type: "integer", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ParamsCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamsCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookedDates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OfferId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedDates", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookedDates_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParamItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    ValueType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ParamItems_ParamsCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ParamsCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentObjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    RoomCount = table.Column<int>(type: "integer", nullable: false),
                    BathroomCount = table.Column<int>(type: "integer", nullable: false),
                    Area = table.Column<double>(type: "double precision", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    TotalFloors = table.Column<int>(type: "integer", nullable: false),
                    RentObjType = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    BedroomsCount = table.Column<int>(type: "integer", nullable: false),
                    BedsCount = table.Column<int>(type: "integer", nullable: false),
                    HasBabyCrib = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentObjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_RentObjects_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentObjImage",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    RentObjId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentObjImage", x => x.id);
                    table.ForeignKey(
                        name: "FK_RentObjImage_RentObjects_RentObjId",
                        column: x => x.RentObjId,
                        principalTable: "RentObjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentObjParamValues",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RentObjId = table.Column<int>(type: "integer", nullable: false),
                    ParamItemId = table.Column<int>(type: "integer", nullable: false),
                    ValueBool = table.Column<bool>(type: "boolean", nullable: true),
                    ValueInt = table.Column<int>(type: "integer", nullable: true),
                    ValueString = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentObjParamValues", x => x.id);
                    table.ForeignKey(
                        name: "FK_RentObjParamValues_ParamItems_ParamItemId",
                        column: x => x.ParamItemId,
                        principalTable: "ParamItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentObjParamValues_RentObjects_RentObjId",
                        column: x => x.RentObjId,
                        principalTable: "RentObjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "Title" },
                values: new object[,]
                {
                    { 1, "United States" },
                    { 2, "Germany" },
                    { 3, "France" },
                    { 4, "United Kingdom" },
                    { 5, "Spain" },
                    { 6, "Poland" }
                });

            migrationBuilder.InsertData(
                table: "ParamsCategories",
                columns: new[] { "id", "Title" },
                values: new object[,]
                {
                    { 1, "General" },
                    { 2, "Building" },
                    { 3, "Location" },
                    { 4, "Outdoors" },
                    { 5, "Services" },
                    { 6, "Food & Drink" },
                    { 7, "Wellness & Recreation" },
                    { 8, "Room Facilities" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "id", "CountryId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "New York" },
                    { 2, 1, "Los Angeles" },
                    { 3, 1, "Chicago" },
                    { 4, 2, "Berlin" },
                    { 5, 2, "Munich" },
                    { 6, 2, "Hamburg" },
                    { 7, 3, "Paris" },
                    { 8, 3, "Lyon" },
                    { 9, 3, "Marseille" },
                    { 10, 4, "London" },
                    { 11, 4, "Manchester" },
                    { 12, 4, "Birmingham" },
                    { 13, 5, "Madrid" },
                    { 14, 5, "Barcelona" },
                    { 15, 5, "Valencia" },
                    { 16, 6, "Warsaw" },
                    { 17, 6, "Kraków" },
                    { 18, 6, "Poznań" }
                });

            migrationBuilder.InsertData(
                table: "ParamItems",
                columns: new[] { "id", "CategoryId", "Title", "ValueType" },
                values: new object[,]
                {
                    { 1, 1, "Free WiFi", 1 },
                    { 2, 1, "Non‑smoking rooms", 1 },
                    { 3, 1, "Air conditioning", 1 },
                    { 4, 1, "Heating", 1 },
                    { 5, 1, "Pets allowed", 1 },
                    { 6, 2, "Elevator", 1 },
                    { 7, 2, "24‑hour front desk", 1 },
                    { 8, 2, "Security", 1 },
                    { 9, 3, "Parking", 1 },
                    { 10, 4, "Garden", 1 },
                    { 11, 4, "Terrace", 1 },
                    { 12, 4, "BBQ / Picnic area", 1 },
                    { 13, 5, "Airport shuttle", 1 },
                    { 14, 5, "Laundry", 1 },
                    { 15, 5, "Dry cleaning", 1 },
                    { 16, 5, "Concierge", 1 },
                    { 17, 6, "Restaurant", 1 },
                    { 18, 6, "Bar", 1 },
                    { 19, 6, "Breakfast included", 1 },
                    { 20, 7, "Fitness center", 1 },
                    { 21, 7, "Sauna", 1 },
                    { 22, 7, "Outdoor pool", 1 },
                    { 23, 7, "Indoor pool", 1 },
                    { 24, 8, "Shower", 1 },
                    { 25, 8, "Bathtub", 1 },
                    { 26, 8, "Hair dryer", 1 },
                    { 27, 8, "TV", 1 },
                    { 28, 8, "Minibar", 1 },
                    { 29, 8, "Safe", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedDates_OfferId",
                table: "BookedDates",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ParamItems_CategoryId",
                table: "ParamItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RentObjects_CityId",
                table: "RentObjects",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RentObjImage_RentObjId",
                table: "RentObjImage",
                column: "RentObjId");

            migrationBuilder.CreateIndex(
                name: "IX_RentObjParamValues_ParamItemId",
                table: "RentObjParamValues",
                column: "ParamItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RentObjParamValues_RentObjId",
                table: "RentObjParamValues",
                column: "RentObjId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedDates");

            migrationBuilder.DropTable(
                name: "RentObjImage");

            migrationBuilder.DropTable(
                name: "RentObjParamValues");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "ParamItems");

            migrationBuilder.DropTable(
                name: "RentObjects");

            migrationBuilder.DropTable(
                name: "ParamsCategories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
