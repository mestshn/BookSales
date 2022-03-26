using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSalesWebServices.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateKullaniciID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateKullanıcıID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateKullaniciID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateKullanıcıID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.UrunID);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiparisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SiparisDurumu = table.Column<int>(type: "int", nullable: false),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KDVOrani = table.Column<double>(type: "float", nullable: false),
                    KDVFiyat = table.Column<double>(type: "float", nullable: false),
                    ToplamTutar = table.Column<double>(type: "float", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateKullaniciID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateKullanıcıID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.SiparisID);
                    table.ForeignKey(
                        name: "FK_Siparis_Kullanici_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stok",
                columns: table => new
                {
                    StokID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateKullaniciID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateKullanıcıID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stok", x => x.StokID);
                    table.ForeignKey(
                        name: "FK_Stok_Urun_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urun",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetay",
                columns: table => new
                {
                    SiparisDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    BirimFiyat = table.Column<double>(type: "float", nullable: false),
                    ToplamFiyat = table.Column<double>(type: "float", nullable: false),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateKullaniciID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateKullanıcıID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetay", x => x.SiparisDetayID);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Siparis_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparis",
                        principalColumn: "SiparisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Urun_UrunID",
                        column: x => x.UrunID,
                        principalTable: "Urun",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_KullaniciID",
                table: "Siparis",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_SiparisID",
                table: "SiparisDetay",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_UrunID",
                table: "SiparisDetay",
                column: "UrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_UrunID",
                table: "Stok",
                column: "UrunID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiparisDetay");

            migrationBuilder.DropTable(
                name: "Stok");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Kullanici");
        }
    }
}
