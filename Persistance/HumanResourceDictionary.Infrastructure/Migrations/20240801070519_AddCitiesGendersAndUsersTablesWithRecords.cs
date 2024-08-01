using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HumanResourceDictionary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCitiesGendersAndUsersTablesWithRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dictionary");

            migrationBuilder.EnsureSchema(
                name: "ums");

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedCityNames",
                schema: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedCityNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizedCityNames_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "dictionary",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedGenderNames",
                schema: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedGenderNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizedGenderNames_Genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "dictionary",
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "ums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Lastname = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    PersonalNumber = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "dictionary",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "dictionary",
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dictionary",
                table: "Cities",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "TBS" },
                    { 2, "KUT" },
                    { 3, "BAT" },
                    { 4, "RUS" },
                    { 5, "ZUG" },
                    { 6, "GOR" },
                    { 7, "TEL" },
                    { 8, "POT" },
                    { 9, "OZA" },
                    { 10, "SAM" },
                    { 11, "AKH" },
                    { 12, "KHA" }
                });

            migrationBuilder.InsertData(
                schema: "dictionary",
                table: "Genders",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "FE" },
                    { 2, "MA" }
                });

            migrationBuilder.InsertData(
                schema: "dictionary",
                table: "LocalizedCityNames",
                columns: new[] { "Id", "CityId", "LanguageCode", "Name" },
                values: new object[,]
                {
                    { 1, 1, "GE", "თბილისი" },
                    { 2, 1, "EN", "Tbilisi" },
                    { 3, 2, "GE", "ქუთაისი" },
                    { 4, 2, "EN", "Kutaisi" },
                    { 5, 3, "GE", "ბათუმი" },
                    { 6, 3, "EN", "Batumi" },
                    { 7, 4, "GE", "რუსთავი" },
                    { 8, 4, "EN", "Rustavi" },
                    { 9, 5, "GE", "ზუგდიდი" },
                    { 10, 5, "EN", "Zugdidi" },
                    { 11, 6, "GE", "გორი" },
                    { 12, 6, "EN", "Gori" },
                    { 13, 7, "GE", "თელავი" },
                    { 14, 7, "EN", "Telavi" },
                    { 15, 8, "GE", "ფოთი" },
                    { 16, 8, "EN", "Poti" },
                    { 17, 9, "GE", "ოზურგეთი" },
                    { 18, 9, "EN", "Ozurgeti" },
                    { 19, 10, "GE", "სამტრედია" },
                    { 20, 10, "EN", "Samtredia" },
                    { 21, 11, "GE", "ახალციხე" },
                    { 22, 11, "EN", "Akhaltsikhe" },
                    { 23, 12, "GE", "ხაშური" },
                    { 24, 12, "EN", "Khashuri" }
                });

            migrationBuilder.InsertData(
                schema: "dictionary",
                table: "LocalizedGenderNames",
                columns: new[] { "Id", "GenderId", "LanguageCode", "Name" },
                values: new object[,]
                {
                    { 1, 1, "GE", "ქალი" },
                    { 2, 1, "EN", "Female" },
                    { 3, 2, "GE", "კაცი" },
                    { 4, 2, "EN", "Male" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedCityNames_CityId",
                schema: "dictionary",
                table: "LocalizedCityNames",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedGenderNames_GenderId",
                schema: "dictionary",
                table: "LocalizedGenderNames",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                schema: "ums",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                schema: "ums",
                table: "Users",
                column: "GenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizedCityNames",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "LocalizedGenderNames",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "ums");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "dictionary");
        }
    }
}
