using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QlyPhatTu.Migrations
{
    /// <inheritdoc />
    public partial class update_daotrang_phattu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PhatTu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NguoiTruTri",
                table: "DaoTrang",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PhatTu");

            migrationBuilder.DropColumn(
                name: "NguoiTruTri",
                table: "DaoTrang");
        }
    }
}
