using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HumanResourceDictionary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDictionariesForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneNumberTypes",
                schema: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationTypes",
                schema: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: " PhoneNumberDictionary",
                schema: "ums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NumberTypeId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ PhoneNumberDictionary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ PhoneNumberDictionary_PhoneNumberTypes_NumberTypeId",
                        column: x => x.NumberTypeId,
                        principalSchema: "dictionary",
                        principalTable: "PhoneNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ PhoneNumberDictionary_Users_NumberTypeId",
                        column: x => x.NumberTypeId,
                        principalSchema: "ums",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedPhoneNumberTypeNames",
                schema: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumberTypeId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    TypeName = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedPhoneNumberTypeNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizedPhoneNumberTypeNames_PhoneNumberTypes_PhoneNumberTypeId",
                        column: x => x.PhoneNumberTypeId,
                        principalSchema: "dictionary",
                        principalTable: "PhoneNumberTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedRelationTypeNames",
                schema: "dictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationTypeId = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedRelationTypeNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizedRelationTypeNames_RelationTypes_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalSchema: "dictionary",
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dictionary",
                table: "RelationTypes",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "COW" },
                    { 2, "FA" },
                    { 3, "REL" },
                    { 4, "OTH" }
                });

            migrationBuilder.InsertData(
                schema: "dictionary",
                table: "LocalizedRelationTypeNames",
                columns: new[] { "Id", "LanguageCode", "Name", "RelationTypeId" },
                values: new object[,]
                {
                    { 1, "GE", "თანამშრომელი", 1 },
                    { 2, "EN", "Co-Worker", 1 },
                    { 3, "GE", "ნაცნობი", 2 },
                    { 4, "EN", "Familiar", 2 },
                    { 5, "GE", "ნათესავი", 3 },
                    { 6, "EN", "Relative", 3 },
                    { 7, "GE", "სხვა", 4 },
                    { 8, "EN", "Other", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ PhoneNumberDictionary_NumberTypeId",
                schema: "ums",
                table: " PhoneNumberDictionary",
                column: "NumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedPhoneNumberTypeNames_PhoneNumberTypeId",
                schema: "dictionary",
                table: "LocalizedPhoneNumberTypeNames",
                column: "PhoneNumberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRelationTypeNames_RelationTypeId",
                schema: "dictionary",
                table: "LocalizedRelationTypeNames",
                column: "RelationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: " PhoneNumberDictionary",
                schema: "ums");

            migrationBuilder.DropTable(
                name: "LocalizedPhoneNumberTypeNames",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "LocalizedRelationTypeNames",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "PhoneNumberTypes",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "RelationTypes",
                schema: "dictionary");
        }
    }
}
