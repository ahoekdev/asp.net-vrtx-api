using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class MakeDatabaseRoleStringMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.Sql("UPDATE \"Users\" SET \"Role\" = 'Admin' WHERE \"Role\" = '0'");
            migrationBuilder.Sql("UPDATE \"Users\" SET \"Role\" = 'Manager' WHERE \"Role\" = '1'");
            migrationBuilder.Sql("UPDATE \"Users\" SET \"Role\" = 'User' WHERE \"Role\" = '2'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
