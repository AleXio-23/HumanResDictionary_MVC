using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResourceDictionary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationsStruct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRelations",
                schema: "ums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RelatedUserId = table.Column<int>(type: "int", nullable: false),
                    RelationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRelations_RelationTypes_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalSchema: "dictionary",
                        principalTable: "RelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRelations_Users_RelatedUserId",
                        column: x => x.RelatedUserId,
                        principalSchema: "ums",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRelations_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ums",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRelations_RelatedUserId",
                schema: "ums",
                table: "UserRelations",
                column: "RelatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelations_RelationTypeId",
                schema: "ums",
                table: "UserRelations",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelations_UserId",
                schema: "ums",
                table: "UserRelations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRelations",
                schema: "ums");
        }
    }
}
