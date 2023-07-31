using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QlyPhatTu.Migrations
{
    /// <inheritdoc />
    public partial class edit_phattu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_PhatTuId",
                table: "UserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_PhatTuId",
                table: "UserRoles",
                column: "PhatTuId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoles_PhatTuId",
                table: "UserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_PhatTuId",
                table: "UserRoles",
                column: "PhatTuId");
        }
    }
}
