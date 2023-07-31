using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QlyPhatTu.Migrations
{
    /// <inheritdoc />
    public partial class edit_PasswordRefreshv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Expired",
                table: "PasswordRefresh",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expired",
                table: "PasswordRefresh");
        }
    }
}
