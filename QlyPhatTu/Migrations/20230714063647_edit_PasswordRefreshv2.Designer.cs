﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QlyPhatTu.Models;

#nullable disable

namespace QlyPhatTu.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230714063647_edit_PasswordRefreshv2")]
    partial class edit_PasswordRefreshv2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QlyPhatTu.Dto.PasswordRefresh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Expired")
                        .HasColumnType("bit");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<string>("RefreshCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhatTuId");

                    b.ToTable("PasswordRefresh");
                });

            modelBuilder.Entity("QlyPhatTu.Models.Chua", b =>
                {
                    b.Property<int>("ChuaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChuaId"));

                    b.Property<DateTime?>("CapNhap")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenChua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TruTri")
                        .HasColumnType("int");

                    b.HasKey("ChuaId");

                    b.ToTable("Chua");
                });

            modelBuilder.Entity("QlyPhatTu.Models.DaoTrang", b =>
                {
                    b.Property<int>("DaoTrangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DaoTrangId"));

                    b.Property<bool?>("DaKetThuc")
                        .HasColumnType("bit");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiToChuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoThanhVienThamGia")
                        .HasColumnType("int");

                    b.HasKey("DaoTrangId");

                    b.ToTable("DaoTrang");
                });

            modelBuilder.Entity("QlyPhatTu.Models.DonDangKy", b =>
                {
                    b.Property<int>("DonDangKyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonDangKyId"));

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayGuiDon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayXuLy")
                        .HasColumnType("datetime2");

                    b.Property<int>("NguoiXuLy")
                        .HasColumnType("int");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("TrangThaiDon")
                        .HasColumnType("int");

                    b.HasKey("DonDangKyId");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("DonDangKy");
                });

            modelBuilder.Entity("QlyPhatTu.Models.KieuThanhVien", b =>
                {
                    b.Property<int>("KieuThanhVienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KieuThanhVienId"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKieu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KieuThanhVienId");

                    b.ToTable("KieuThanhVien");
                });

            modelBuilder.Entity("QlyPhatTu.Models.PhatTu", b =>
                {
                    b.Property<int>("PhatTuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhatTuId"));

                    b.Property<string>("AnhChup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ChuaId")
                        .HasColumnType("int");

                    b.Property<bool?>("DaHoanTuc")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KieuThanhVienId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayHoanTuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXuatGia")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhapDanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhatTuId");

                    b.HasIndex("ChuaId");

                    b.HasIndex("KieuThanhVienId");

                    b.ToTable("PhatTu");
                });

            modelBuilder.Entity("QlyPhatTu.Models.PhatTuDaoTrang", b =>
                {
                    b.Property<int>("PhatTuDaoTrangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhatTuDaoTrangId"));

                    b.Property<bool>("DaThamGia")
                        .HasColumnType("bit");

                    b.Property<int>("DaoTrangId")
                        .HasColumnType("int");

                    b.Property<string>("LiDoKhongThamGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.HasKey("PhatTuDaoTrangId");

                    b.HasIndex("DaoTrangId");

                    b.HasIndex("PhatTuId");

                    b.ToTable("PhatTuDaoTrang");
                });

            modelBuilder.Entity("QlyPhatTu.Models.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PhatTuId")
                        .HasColumnType("int");

                    b.Property<int>("Revoked")
                        .HasColumnType("int");

                    b.Property<string>("Stoken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sxpired")
                        .HasColumnType("int");

                    b.Property<string>("TokenType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhatTuId");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("QlyPhatTu.Dto.PasswordRefresh", b =>
                {
                    b.HasOne("QlyPhatTu.Models.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QlyPhatTu.Models.DonDangKy", b =>
                {
                    b.HasOne("QlyPhatTu.Models.DaoTrang", "DaoTrang")
                        .WithMany("LstDondangkys")
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QlyPhatTu.Models.PhatTu", "PhatTu")
                        .WithMany("Dondangkys")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QlyPhatTu.Models.PhatTu", b =>
                {
                    b.HasOne("QlyPhatTu.Models.Chua", "Chua")
                        .WithMany("Phattus")
                        .HasForeignKey("ChuaId");

                    b.HasOne("QlyPhatTu.Models.KieuThanhVien", "KieuThanhVien")
                        .WithMany("Phattus")
                        .HasForeignKey("KieuThanhVienId");

                    b.Navigation("Chua");

                    b.Navigation("KieuThanhVien");
                });

            modelBuilder.Entity("QlyPhatTu.Models.PhatTuDaoTrang", b =>
                {
                    b.HasOne("QlyPhatTu.Models.DaoTrang", "DaoTrang")
                        .WithMany("LstPhattus")
                        .HasForeignKey("DaoTrangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QlyPhatTu.Models.PhatTu", "PhatTu")
                        .WithMany("Phattudaotrangs")
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaoTrang");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QlyPhatTu.Models.Token", b =>
                {
                    b.HasOne("QlyPhatTu.Models.PhatTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("PhatTuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QlyPhatTu.Models.Chua", b =>
                {
                    b.Navigation("Phattus");
                });

            modelBuilder.Entity("QlyPhatTu.Models.DaoTrang", b =>
                {
                    b.Navigation("LstDondangkys");

                    b.Navigation("LstPhattus");
                });

            modelBuilder.Entity("QlyPhatTu.Models.KieuThanhVien", b =>
                {
                    b.Navigation("Phattus");
                });

            modelBuilder.Entity("QlyPhatTu.Models.PhatTu", b =>
                {
                    b.Navigation("Dondangkys");

                    b.Navigation("Phattudaotrangs");
                });
#pragma warning restore 612, 618
        }
    }
}
