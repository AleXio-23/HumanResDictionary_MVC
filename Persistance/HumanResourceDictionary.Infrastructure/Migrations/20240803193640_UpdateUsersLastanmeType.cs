using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResourceDictionary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsersLastanmeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                schema: "ums",
                table: "Users",
                type: "NVARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

      
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                schema: "ums",
                table: "Users",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(50)");

           
        }
    }
}
