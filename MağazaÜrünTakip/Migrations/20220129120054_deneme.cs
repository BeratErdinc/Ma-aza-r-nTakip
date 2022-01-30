using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MağazaÜrünTakip.Migrations
{
    public partial class deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Musterıs",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriSehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriBakıye = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musterıs", x => x.MusteriId);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelDepartman = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelId);
                });

            migrationBuilder.CreateTable(
                name: "Uruns",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunMarka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunStok = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlısFıyat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatısFıyat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    KategorıId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uruns", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_Uruns_Kategoris_KategorıId",
                        column: x => x.KategorıId,
                        principalTable: "Kategoris",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Satıslars",
                columns: table => new
                {
                    SatısId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fİyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrunlerUrunId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satıslars", x => x.SatısId);
                    table.ForeignKey(
                        name: "FK_Satıslars_Musterıs_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "Musterıs",
                        principalColumn: "MusteriId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Satıslars_Personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Satıslars_Uruns_UrunlerUrunId",
                        column: x => x.UrunlerUrunId,
                        principalTable: "Uruns",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Satıslars_MusteriId",
                table: "Satıslars",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Satıslars_PersonelId",
                table: "Satıslars",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Satıslars_UrunlerUrunId",
                table: "Satıslars",
                column: "UrunlerUrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Uruns_KategorıId",
                table: "Uruns",
                column: "KategorıId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Satıslars");

            migrationBuilder.DropTable(
                name: "Musterıs");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Uruns");

            migrationBuilder.DropTable(
                name: "Kategoris");
        }
    }
}
