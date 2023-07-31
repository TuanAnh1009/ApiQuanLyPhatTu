using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QlyPhatTu.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chua",
                columns: table => new
                {
                    ChuaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThanhLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenChua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruTri = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chua", x => x.ChuaId);
                });

            migrationBuilder.CreateTable(
                name: "DaoTrang",
                columns: table => new
                {
                    DaoTrangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaKetThuc = table.Column<bool>(type: "bit", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiToChuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoThanhVienThamGia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaoTrang", x => x.DaoTrangId);
                });

            migrationBuilder.CreateTable(
                name: "KieuThanhVien",
                columns: table => new
                {
                    KieuThanhVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenKieu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KieuThanhVien", x => x.KieuThanhVienId);
                });

            migrationBuilder.CreateTable(
                name: "PhatTu",
                columns: table => new
                {
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnhChup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaHoanTuc = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHoanTuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayXuatGia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhapDanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuaId = table.Column<int>(type: "int", nullable: false),
                    KieuThanhVienId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTu", x => x.PhatTuId);
                    table.ForeignKey(
                        name: "FK_PhatTu_Chua_ChuaId",
                        column: x => x.ChuaId,
                        principalTable: "Chua",
                        principalColumn: "ChuaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhatTu_KieuThanhVien_KieuThanhVienId",
                        column: x => x.KieuThanhVienId,
                        principalTable: "KieuThanhVien",
                        principalColumn: "KieuThanhVienId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonDangKy",
                columns: table => new
                {
                    DonDangKyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayGuiDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayXuLy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiXuLy = table.Column<int>(type: "int", nullable: false),
                    TrangThaiDon = table.Column<int>(type: "int", nullable: false),
                    DaoTrangId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDangKy", x => x.DonDangKyId);
                    table.ForeignKey(
                        name: "FK_DonDangKy_DaoTrang_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "DaoTrang",
                        principalColumn: "DaoTrangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonDangKy_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "PhatTuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhatTuDaoTrang",
                columns: table => new
                {
                    PhatTuDaoTrangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaThamGia = table.Column<bool>(type: "bit", nullable: false),
                    LiDoKhongThamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaoTrangId = table.Column<int>(type: "int", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhatTuDaoTrang", x => x.PhatTuDaoTrangId);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrang_DaoTrang_DaoTrangId",
                        column: x => x.DaoTrangId,
                        principalTable: "DaoTrang",
                        principalColumn: "DaoTrangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhatTuDaoTrang_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "PhatTuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stoken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sxpired = table.Column<int>(type: "int", nullable: false),
                    Revoked = table.Column<int>(type: "int", nullable: false),
                    SokenType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhatTuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_PhatTu_PhatTuId",
                        column: x => x.PhatTuId,
                        principalTable: "PhatTu",
                        principalColumn: "PhatTuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKy_DaoTrangId",
                table: "DonDangKy",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_DonDangKy_PhatTuId",
                table: "DonDangKy",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTu_ChuaId",
                table: "PhatTu",
                column: "ChuaId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTu_KieuThanhVienId",
                table: "PhatTu",
                column: "KieuThanhVienId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrang_DaoTrangId",
                table: "PhatTuDaoTrang",
                column: "DaoTrangId");

            migrationBuilder.CreateIndex(
                name: "IX_PhatTuDaoTrang_PhatTuId",
                table: "PhatTuDaoTrang",
                column: "PhatTuId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_PhatTuId",
                table: "Token",
                column: "PhatTuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonDangKy");

            migrationBuilder.DropTable(
                name: "PhatTuDaoTrang");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "DaoTrang");

            migrationBuilder.DropTable(
                name: "PhatTu");

            migrationBuilder.DropTable(
                name: "Chua");

            migrationBuilder.DropTable(
                name: "KieuThanhVien");
        }
    }
}
