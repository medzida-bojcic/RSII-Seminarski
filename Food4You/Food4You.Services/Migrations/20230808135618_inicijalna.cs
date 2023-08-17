using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food4You.Services.Migrations
{
    /// <inheritdoc />
    public partial class inicijalna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Drzava__3214EC077B24F9AE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grad__3214EC0703D5B88E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kategori__3214EC07F4A4B1B1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusNarudzbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StatusNa__3214EC07AFE0E716", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uloga__3214EC07F993517F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GradId = table.Column<int>(type: "int", nullable: true),
                    DrzavaId = table.Column<int>(type: "int", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LozinkaHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__3214EC079965D60E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Korisnik__Drzava__71D1E811",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Korisnik__GradId__70DDC3D8",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Meni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<decimal>(type: "money", nullable: true),
                    KategorijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Meni__3214EC07AB24D271", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Meni__Kategorija__4E88ABD4",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorija",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    UlogaId = table.Column<int>(type: "int", nullable: true),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Korisnik__3214EC07396D9064", x => x.Id);
                    table.ForeignKey(
                        name: "FK__KorisnikU__Koris__76969D2E",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__KorisnikU__Uloga__778AC167",
                        column: x => x.UlogaId,
                        principalTable: "Uloga",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumNarudzbe = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusNarudzbeId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Narudzba__3214EC077DAAB08D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Narudzba__Korisn__7D439ABD",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Narudzba__Status__7C4F7684",
                        column: x => x.StatusNarudzbeId,
                        principalTable: "StatusNarudzbe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iznos = table.Column<decimal>(type: "money", nullable: true),
                    DatumTransakcije = table.Column<DateTime>(type: "datetime", nullable: true),
                    BrojTransakcije = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uplata__3214EC07FEFF0C35", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Uplata__Korisnik__07C12930",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<int>(type: "int", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeniId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Recenzij__3214EC0775C908A4", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Recenzije__Koris__04E4BC85",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Recenzije__MeniI__03F0984C",
                        column: x => x.MeniId,
                        principalTable: "Meni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: true),
                    Cijena = table.Column<decimal>(type: "money", nullable: true),
                    MeniId = table.Column<int>(type: "int", nullable: true),
                    NarudzbaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Narudzba__3214EC07CF813CCB", x => x.Id);
                    table.ForeignKey(
                        name: "FK__NarudzbaS__MeniI__00200768",
                        column: x => x.MeniId,
                        principalTable: "Meni",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__NarudzbaS__Narud__01142BA1",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_DrzavaId",
                table: "Korisnik",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_GradId",
                table: "Korisnik",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_KorisnikId",
                table: "KorisnikUloga",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogaId",
                table: "KorisnikUloga",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Meni_KategorijaId",
                table: "Meni",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KorisnikId",
                table: "Narudzba",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_StatusNarudzbeId",
                table: "Narudzba",
                column: "StatusNarudzbeId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavke_MeniId",
                table: "NarudzbaStavke",
                column: "MeniId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavke_NarudzbaId",
                table: "NarudzbaStavke",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_KorisnikId",
                table: "Recenzije",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_MeniId",
                table: "Recenzije",
                column: "MeniId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_KorisnikId",
                table: "Uplata",
                column: "KorisnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "NarudzbaStavke");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Meni");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "StatusNarudzbe");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.DropTable(
                name: "Grad");
        }
    }
}
