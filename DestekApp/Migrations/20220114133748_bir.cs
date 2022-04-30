using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DestekApp.Migrations
{
    public partial class bir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinsiyetler",
                columns: table => new
                {
                    CinsiyetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsiyetAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyetler", x => x.CinsiyetID);
                });

            migrationBuilder.CreateTable(
                name: "Frekanslar",
                columns: table => new
                {
                    FrekansID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrekansAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frekanslar", x => x.FrekansID);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false),
                    RolAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullanıcıID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eposta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Şifre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullanıcıID);
                    table.ForeignKey(
                        name: "FK_Kullanıcılar_Roller_RolID",
                        column: x => x.RolID,
                        principalTable: "Roller",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresler",
                columns: table => new
                {
                    AdresID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    AdresAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresBilgisi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresler", x => x.AdresID);
                    table.ForeignKey(
                        name: "FK_Adresler_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İhtiyaçlar",
                columns: table => new
                {
                    İhtiyaçID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    İhtiyaçAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    İhtiyaçAçıklaması = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    FrekansID = table.Column<int>(type: "int", nullable: false),
                    KayıtTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İhtiyaçlar", x => x.İhtiyaçID);
                    table.ForeignKey(
                        name: "FK_İhtiyaçlar_Frekanslar_FrekansID",
                        column: x => x.FrekansID,
                        principalTable: "Frekanslar",
                        principalColumn: "FrekansID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_İhtiyaçlar_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "İletişimler",
                columns: table => new
                {
                    İletişimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    İletişimAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İletişimler", x => x.İletişimID);
                    table.ForeignKey(
                        name: "FK_İletişimler_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kişiler",
                columns: table => new
                {
                    KişiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    AD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SoyAD = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CinsiyetID = table.Column<int>(type: "int", nullable: false),
                    DoğumTarih = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kişiler", x => x.KişiID);
                    table.ForeignKey(
                        name: "FK_Kişiler_Cinsiyetler_CinsiyetID",
                        column: x => x.CinsiyetID,
                        principalTable: "Cinsiyetler",
                        principalColumn: "CinsiyetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kişiler_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cinsiyetler",
                columns: new[] { "CinsiyetID", "CinsiyetAdı" },
                values: new object[,]
                {
                    { 1, "Erkek" },
                    { 2, "Kadın" }
                });

            migrationBuilder.InsertData(
                table: "Frekanslar",
                columns: new[] { "FrekansID", "FrekansAdı" },
                values: new object[,]
                {
                    { 1, "Tek Seferlik" },
                    { 2, "Günlük" },
                    { 3, "Haftalık" },
                    { 4, "Aylık" }
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "RolID", "RolAdı" },
                values: new object[,]
                {
                    { 1, "UserCandidate" },
                    { 2, "UserNormal" },
                    { 3, "Admin" },
                    { 4, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "KullanıcıID", "Eposta", "RolID", "Şifre" },
                values: new object[,]
                {
                    { 1, "sinan@outlook.com", 1, "Qwe123" },
                    { 2, "ali@hotmail.com", 1, "Qwe123" },
                    { 3, "mahmut@hotmail.com", 3, "Qwe123" },
                    { 4, "mansurkürşad@icloud.com", 2, "Qwe123" },
                    { 5, "gamze@gmail.com", 4, "Qwe123" },
                    { 6, "miraç@hotmail.com", 3, "Qwe123" },
                    { 7, "yücel@outlook.com", 1, "Qwe123" },
                    { 8, "kubilay@gmail.com", 4, "Qwe123" },
                    { 9, "hayati@hotmail.com", 3, "Qwe123" },
                    { 10, "bedriyemüge@hotmail.com", 2, "Qwe123" },
                    { 11, "birsen@icloud.com", 1, "Qwe123" },
                    { 12, "serdal@gmail.com", 2, "Qwe123" },
                    { 13, "bünyamin@gmail.com", 3, "Qwe123" },
                    { 14, "özgür@gmail.com", 2, "Qwe123" },
                    { 15, "ferdi@gmail.com", 1, "Qwe123" },
                    { 16, "reyhan@outlook.com", 2, "Qwe123" },
                    { 17, "ilhan@gmail.com", 2, "Qwe123" },
                    { 18, "gülşah@icloud.com", 4, "Qwe123" },
                    { 19, "nalan@outlook.com", 3, "Qwe123" },
                    { 20, "semih@outlook.com", 2, "Qwe123" },
                    { 21, "ergün@outlook.com", 1, "Qwe123" },
                    { 22, "fatih@hotmail.com", 3, "Qwe123" },
                    { 23, "şenay@gmail.com", 4, "Qwe123" },
                    { 24, "serkan@outlook.com", 4, "Qwe123" },
                    { 25, "emre@icloud.com", 4, "Qwe123" },
                    { 26, "bahattin@gmail.com", 4, "Qwe123" },
                    { 27, "irazca@gmail.com", 1, "Qwe123" },
                    { 28, "hatice@icloud.com", 3, "Qwe123" },
                    { 29, "bariş@icloud.com", 3, "Qwe123" },
                    { 30, "rezan@hotmail.com", 3, "Qwe123" },
                    { 31, "fatih@gmail.com", 2, "Qwe123" },
                    { 32, "fuat@outlook.com", 1, "Qwe123" },
                    { 33, "gökhan@icloud.com", 1, "Qwe123" },
                    { 34, "orhan@outlook.com", 4, "Qwe123" },
                    { 35, "mehmet@hotmail.com", 3, "Qwe123" },
                    { 36, "evren@hotmail.com", 3, "Qwe123" },
                    { 37, "oktay@gmail.com", 1, "Qwe123" },
                    { 38, "harun@gmail.com", 1, "Qwe123" },
                    { 39, "yavuz@hotmail.com", 4, "Qwe123" },
                    { 40, "pinar@hotmail.com", 4, "Qwe123" },
                    { 41, "mehmet@icloud.com", 2, "Qwe123" },
                    { 42, "umut@outlook.com", 2, "Qwe123" }
                });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "KullanıcıID", "Eposta", "RolID", "Şifre" },
                values: new object[,]
                {
                    { 43, "mesude@hotmail.com", 4, "Qwe123" },
                    { 44, "hüseyincahit@gmail.com", 4, "Qwe123" },
                    { 45, "haşimonur@gmail.com", 2, "Qwe123" },
                    { 46, "eyyupsabri@gmail.com", 3, "Qwe123" },
                    { 47, "mustafa@icloud.com", 2, "Qwe123" },
                    { 48, "mustafa@icloud.com", 2, "Qwe123" },
                    { 49, "ufuk@icloud.com", 1, "Qwe123" },
                    { 50, "ahmetali@hotmail.com", 2, "Qwe123" },
                    { 51, "mediha@icloud.com", 2, "Qwe123" },
                    { 52, "hasan@icloud.com", 3, "Qwe123" },
                    { 53, "kamil@icloud.com", 3, "Qwe123" },
                    { 54, "nebi@icloud.com", 1, "Qwe123" },
                    { 55, "özcan@gmail.com", 4, "Qwe123" },
                    { 56, "nagihan@gmail.com", 3, "Qwe123" },
                    { 57, "ceren@gmail.com", 2, "Qwe123" },
                    { 58, "serkan@hotmail.com", 3, "Qwe123" },
                    { 59, "hasan@icloud.com", 3, "Qwe123" },
                    { 60, "yusufkenan@gmail.com", 4, "Qwe123" },
                    { 61, "çetin@icloud.com", 1, "Qwe123" },
                    { 62, "tarkan@gmail.com", 2, "Qwe123" },
                    { 63, "meralleman@hotmail.com", 2, "Qwe123" },
                    { 64, "ergün@icloud.com", 4, "Qwe123" },
                    { 65, "kenanahmet@icloud.com", 4, "Qwe123" },
                    { 66, "ural@icloud.com", 4, "Qwe123" },
                    { 67, "yahya@icloud.com", 2, "Qwe123" },
                    { 68, "bengü@outlook.com", 2, "Qwe123" },
                    { 69, "fatihnazmi@hotmail.com", 2, "Qwe123" },
                    { 70, "dilek@outlook.com", 1, "Qwe123" },
                    { 71, "mehmet@icloud.com", 1, "Qwe123" },
                    { 72, "tufanakin@hotmail.com", 4, "Qwe123" },
                    { 73, "mehmet@hotmail.com", 1, "Qwe123" },
                    { 74, "turgayyilmaz@icloud.com", 4, "Qwe123" },
                    { 75, "güldehen@icloud.com", 4, "Qwe123" },
                    { 76, "gökmen@hotmail.com", 2, "Qwe123" },
                    { 77, "bülent@gmail.com", 2, "Qwe123" },
                    { 78, "erol@icloud.com", 2, "Qwe123" },
                    { 79, "bahri@icloud.com", 1, "Qwe123" },
                    { 80, "özenözlem@gmail.com", 2, "Qwe123" },
                    { 81, "selma@icloud.com", 3, "Qwe123" },
                    { 82, "tuğsem@hotmail.com", 1, "Qwe123" },
                    { 83, "teslimenazli@gmail.com", 4, "Qwe123" },
                    { 84, "gülçin@hotmail.com", 3, "Qwe123" }
                });

            migrationBuilder.InsertData(
                table: "Kullanıcılar",
                columns: new[] { "KullanıcıID", "Eposta", "RolID", "Şifre" },
                values: new object[,]
                {
                    { 85, "ismail@icloud.com", 3, "Qwe123" },
                    { 86, "murat@gmail.com", 4, "Qwe123" },
                    { 87, "ebru@icloud.com", 2, "Qwe123" },
                    { 88, "tümay@gmail.com", 2, "Qwe123" },
                    { 89, "ahmet@gmail.com", 4, "Qwe123" },
                    { 90, "ebru@icloud.com", 2, "Qwe123" },
                    { 91, "hüseyinyavuz@gmail.com", 3, "Qwe123" },
                    { 92, "başak@outlook.com", 1, "Qwe123" },
                    { 93, "ayşegül@hotmail.com", 1, "Qwe123" },
                    { 94, "evrim@icloud.com", 4, "Qwe123" },
                    { 95, "yaser@hotmail.com", 3, "Qwe123" },
                    { 96, "ülkü@icloud.com", 3, "Qwe123" },
                    { 97, "özhan@icloud.com", 1, "Qwe123" },
                    { 98, "ufuk@gmail.com", 4, "Qwe123" },
                    { 99, "aksel@hotmail.com", 3, "Qwe123" },
                    { 100, "fulya@icloud.com", 3, "Qwe123" },
                    { 101, "burcu@icloud.com", 3, "Qwe123" },
                    { 102, "taylan@hotmail.com", 4, "Qwe123" },
                    { 103, "yilmaz@icloud.com", 2, "Qwe123" },
                    { 104, "zeynep@gmail.com", 4, "Qwe123" },
                    { 105, "bayram@icloud.com", 3, "Qwe123" },
                    { 106, "gülay@hotmail.com", 3, "Qwe123" },
                    { 107, "rabia@outlook.com", 1, "Qwe123" },
                    { 108, "sevda@outlook.com", 2, "Qwe123" },
                    { 109, "serhat@hotmail.com", 2, "Qwe123" },
                    { 110, "engin@icloud.com", 3, "Qwe123" },
                    { 111, "asli@hotmail.com", 2, "Qwe123" },
                    { 112, "tuba@icloud.com", 2, "Qwe123" },
                    { 113, "bariş@hotmail.com", 4, "Qwe123" },
                    { 114, "sevgi@hotmail.com", 4, "Qwe123" },
                    { 115, "kalender@outlook.com", 3, "Qwe123" },
                    { 116, "halil@icloud.com", 4, "Qwe123" },
                    { 117, "bilge@icloud.com", 1, "Qwe123" },
                    { 118, "ferda@gmail.com", 4, "Qwe123" },
                    { 119, "ezgi@hotmail.com", 2, "Qwe123" },
                    { 120, "aysun@outlook.com", 4, "Qwe123" }
                });

            migrationBuilder.InsertData(
                table: "Adresler",
                columns: new[] { "AdresID", "AdresAdı", "AdresBilgisi", "KullanıcıID" },
                values: new object[,]
                {
                    { 1, "ev", "Menekşe Mah. Petek Sk. No:31 Kat:3 Daire:6", 12 },
                    { 2, "ev", "Küpçüler Mah. Sema Sk. No:28 Kat:2 Daire:2", 17 },
                    { 3, "ev", "Eskiler Cad. Fırın Sk. No:38 Pendik", 17 },
                    { 4, "ev", "Çakmak Cad. Turgut Özal Sk. No:16 Kat:1 Daire:13", 16 },
                    { 5, "ev", "Yedi İklim Mah. Güngören Cad. Lacivert Sk. No:45 Kat:3 Daire:7", 57 }
                });

            migrationBuilder.InsertData(
                table: "Kişiler",
                columns: new[] { "KişiID", "AD", "CinsiyetID", "DoğumTarih", "KullanıcıID", "SoyAD" },
                values: new object[,]
                {
                    { 1, "Serdal", 1, new DateTime(1976, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Tanrıverdi" },
                    { 2, "İlhan", 1, new DateTime(1991, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Gündoğdu" },
                    { 3, "Reyhan", 2, new DateTime(1993, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Balta" },
                    { 4, "Ceren", 2, new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, "Bıçak" }
                });

            migrationBuilder.InsertData(
                table: "İhtiyaçlar",
                columns: new[] { "İhtiyaçID", "FrekansID", "KayıtTarihi", "KullanıcıID", "İhtiyaçAdı", "İhtiyaçAçıklaması" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Ev", "Market" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Okul", "Kırtasiye" },
                    { 3, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Ev", "Fatura" },
                    { 4, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, "Ev", "Market" }
                });

            migrationBuilder.InsertData(
                table: "İletişimler",
                columns: new[] { "İletişimID", "KullanıcıID", "TelefonNo", "İletişimAdı" },
                values: new object[,]
                {
                    { 1, 12, "05303303030", "ev" },
                    { 2, 17, "05313313131", "ev" },
                    { 3, 17, "05123456789", "ev" },
                    { 4, 16, "05545545454", "ev" },
                    { 5, 57, "05343343434", "ev" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_KullanıcıID",
                table: "Adresler",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_İhtiyaçlar_FrekansID",
                table: "İhtiyaçlar",
                column: "FrekansID");

            migrationBuilder.CreateIndex(
                name: "IX_İhtiyaçlar_KullanıcıID",
                table: "İhtiyaçlar",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_İletişimler_KullanıcıID",
                table: "İletişimler",
                column: "KullanıcıID");

            migrationBuilder.CreateIndex(
                name: "IX_Kişiler_CinsiyetID",
                table: "Kişiler",
                column: "CinsiyetID");

            migrationBuilder.CreateIndex(
                name: "IX_Kişiler_KullanıcıID",
                table: "Kişiler",
                column: "KullanıcıID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcılar_RolID",
                table: "Kullanıcılar",
                column: "RolID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresler");

            migrationBuilder.DropTable(
                name: "İhtiyaçlar");

            migrationBuilder.DropTable(
                name: "İletişimler");

            migrationBuilder.DropTable(
                name: "Kişiler");

            migrationBuilder.DropTable(
                name: "Frekanslar");

            migrationBuilder.DropTable(
                name: "Cinsiyetler");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "Roller");
        }
    }
}
