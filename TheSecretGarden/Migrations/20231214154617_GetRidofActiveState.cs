using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheSecretGarden.Migrations
{
    /// <inheritdoc />
    public partial class GetRidofActiveState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveState",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActiveState",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
