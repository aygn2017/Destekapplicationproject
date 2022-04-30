using DestekApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DestekApp.Data
{
    public class DestekAppDBContext : DbContext
    {
        public DestekAppDBContext(DbContextOptions<DestekAppDBContext> options) : base(options) { }


        public DbSet<Rol> Roller { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<Kişi> Kişiler { get; set; }
        public DbSet<Cinsiyet> Cinsiyetler { get; set; }
        public DbSet<İletişim> İletişimler { get; set; }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Frekans> Frekanslar { get; set; } 
        public DbSet<İhtiyaç> İhtiyaçlar { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<İhtiyaç>().HasData(
                                                   new İhtiyaç { İhtiyaçID = 1, KullanıcıID = 12, FrekansID = 4, İhtiyaçAdı = "Ev", İhtiyaçAçıklama = "Market" },
                                                   new İhtiyaç { İhtiyaçID = 2, KullanıcıID = 17, FrekansID = 1, İhtiyaçAdı = "Okul", İhtiyaçAçıklama = "Kırtasiye" },
                                                   new İhtiyaç { İhtiyaçID = 3, KullanıcıID = 16, FrekansID = 4, İhtiyaçAdı = "Ev", İhtiyaçAçıklama = "Fatura" },
                                                   new İhtiyaç { İhtiyaçID = 4, KullanıcıID = 57, FrekansID = 3, İhtiyaçAdı = "Ev", İhtiyaçAçıklama = "Market" }
                                                   );
            modelBuilder.Entity<Frekans>().HasData(
                                                   new Frekans { FrekansID = 1, FrekansAdı = "Tek Seferlik" },
                                                   new Frekans { FrekansID = 2, FrekansAdı = "Günlük" },
                                                   new Frekans { FrekansID = 3, FrekansAdı = "Haftalık" },
                                                   new Frekans { FrekansID = 4, FrekansAdı = "Aylık" }
                                                  );
            modelBuilder.Entity<Kişi>().HasData(
                                                new Kişi { KişiID = 1, KullanıcıID = 12, AD = "Serdal", SoyAD = "Tanrıverdi", CinsiyetID = 1, DoğumTarih = Convert.ToDateTime("17/06/1976") },
                                                new Kişi { KişiID = 2, KullanıcıID = 17, AD = "İlhan", SoyAD = "Gündoğdu", CinsiyetID = 1, DoğumTarih = Convert.ToDateTime("13/01/1991") },
                                                new Kişi { KişiID = 3, KullanıcıID = 16, AD = "Reyhan", SoyAD = "Balta", CinsiyetID = 2, DoğumTarih = Convert.ToDateTime("22/12/1993") },
                                                new Kişi { KişiID = 4, KullanıcıID = 57, AD = "Ceren", SoyAD = "Bıçak", CinsiyetID = 2, DoğumTarih = Convert.ToDateTime("12/12/2012") }

                                               );
            modelBuilder.Entity<Cinsiyet>().HasData(
                                                new Cinsiyet { CinsiyetID = 1, CinsiyetAdı = "Erkek", },
                                                new Cinsiyet { CinsiyetID = 2, CinsiyetAdı = "Kadın", }

                                               );
            modelBuilder.Entity<İletişim>().HasData(
                                                new İletişim { İletişimID = 1, KullanıcıID = 12, İletişimAdı = "ev", TelefonNo = "05303303030" },
                                                new İletişim { İletişimID = 2, KullanıcıID = 17, İletişimAdı = "ev", TelefonNo = "05313313131" },
                                                new İletişim { İletişimID = 3, KullanıcıID = 17, İletişimAdı = "ev", TelefonNo = "05123456789" },
                                                new İletişim { İletişimID = 4, KullanıcıID = 16, İletişimAdı = "ev", TelefonNo = "05545545454" },
                                                new İletişim { İletişimID = 5, KullanıcıID = 57, İletişimAdı = "ev", TelefonNo = "05343343434" }

                                               );
            modelBuilder.Entity<Adres>().HasData(
                                                new Adres { AdresID = 1, KullanıcıID = 12, AdresAdı = "ev", AdresBilgisi = "Menekşe Mah. Petek Sk. No:31 Kat:3 Daire:6" },
                                                new Adres { AdresID = 2, KullanıcıID = 17, AdresAdı = "ev", AdresBilgisi = "Küpçüler Mah. Sema Sk. No:28 Kat:2 Daire:2" },
                                                new Adres { AdresID = 3, KullanıcıID = 17, AdresAdı = "ev", AdresBilgisi = "Eskiler Cad. Fırın Sk. No:38 Pendik" },
                                                new Adres { AdresID = 4, KullanıcıID = 16, AdresAdı = "ev", AdresBilgisi = "Çakmak Cad. Turgut Özal Sk. No:16 Kat:1 Daire:13" },
                                                new Adres { AdresID = 5, KullanıcıID = 57, AdresAdı = "ev", AdresBilgisi = "Yedi İklim Mah. Güngören Cad. Lacivert Sk. No:45 Kat:3 Daire:7" }

                                               );

            modelBuilder.Entity<Rol>().HasData(
                                                new Rol { RolID = 1, RolAdı = "UserCandidate" },
                                                new Rol { RolID = 2, RolAdı = "UserNormal" },
                                                new Rol { RolID = 3, RolAdı = "Admin" },
                                                new Rol { RolID = 4, RolAdı = "Supervisor" }

                                               );
            modelBuilder.Entity<Kullanıcı>().HasData(
                                                new Kullanıcı { KullanıcıID = 1, Eposta = "sinan@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 2, Eposta = "ali@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 3, Eposta = "mahmut@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 4, Eposta = "mansurkürşad@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 5, Eposta = "gamze@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 6, Eposta = "miraç@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 7, Eposta = "yücel@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 8, Eposta = "kubilay@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 9, Eposta = "hayati@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 10, Eposta = "bedriyemüge@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 11, Eposta = "birsen@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 12, Eposta = "serdal@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 13, Eposta = "bünyamin@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 14, Eposta = "özgür@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 15, Eposta = "ferdi@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 16, Eposta = "reyhan@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 17, Eposta = "ilhan@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 18, Eposta = "gülşah@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 19, Eposta = "nalan@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 20, Eposta = "semih@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 21, Eposta = "ergün@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 22, Eposta = "fatih@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 23, Eposta = "şenay@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 24, Eposta = "serkan@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 25, Eposta = "emre@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 26, Eposta = "bahattin@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 27, Eposta = "irazca@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 28, Eposta = "hatice@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 29, Eposta = "bariş@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 30, Eposta = "rezan@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 31, Eposta = "fatih@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 32, Eposta = "fuat@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 33, Eposta = "gökhan@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 34, Eposta = "orhan@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 35, Eposta = "mehmet@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 36, Eposta = "evren@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 37, Eposta = "oktay@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 38, Eposta = "harun@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 39, Eposta = "yavuz@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 40, Eposta = "pinar@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 41, Eposta = "mehmet@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 42, Eposta = "umut@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 43, Eposta = "mesude@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 44, Eposta = "hüseyincahit@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 45, Eposta = "haşimonur@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 46, Eposta = "eyyupsabri@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 47, Eposta = "mustafa@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 48, Eposta = "mustafa@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 49, Eposta = "ufuk@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 50, Eposta = "ahmetali@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 51, Eposta = "mediha@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 52, Eposta = "hasan@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 53, Eposta = "kamil@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 54, Eposta = "nebi@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 55, Eposta = "özcan@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 56, Eposta = "nagihan@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 57, Eposta = "ceren@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 58, Eposta = "serkan@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 59, Eposta = "hasan@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 60, Eposta = "yusufkenan@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 61, Eposta = "çetin@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 62, Eposta = "tarkan@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 63, Eposta = "meralleman@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 64, Eposta = "ergün@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 65, Eposta = "kenanahmet@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 66, Eposta = "ural@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 67, Eposta = "yahya@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 68, Eposta = "bengü@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 69, Eposta = "fatihnazmi@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 70, Eposta = "dilek@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 71, Eposta = "mehmet@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 72, Eposta = "tufanakin@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 73, Eposta = "mehmet@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 74, Eposta = "turgayyilmaz@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 75, Eposta = "güldehen@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 76, Eposta = "gökmen@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 77, Eposta = "bülent@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 78, Eposta = "erol@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 79, Eposta = "bahri@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 80, Eposta = "özenözlem@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 81, Eposta = "selma@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 82, Eposta = "tuğsem@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 83, Eposta = "teslimenazli@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 84, Eposta = "gülçin@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 85, Eposta = "ismail@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 86, Eposta = "murat@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 87, Eposta = "ebru@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 88, Eposta = "tümay@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 89, Eposta = "ahmet@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 90, Eposta = "ebru@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 91, Eposta = "hüseyinyavuz@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 92, Eposta = "başak@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 93, Eposta = "ayşegül@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 94, Eposta = "evrim@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 95, Eposta = "yaser@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 96, Eposta = "ülkü@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 97, Eposta = "özhan@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 98, Eposta = "ufuk@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 99, Eposta = "aksel@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 100, Eposta = "fulya@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 101, Eposta = "burcu@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 102, Eposta = "taylan@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 103, Eposta = "yilmaz@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 104, Eposta = "zeynep@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 105, Eposta = "bayram@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 106, Eposta = "gülay@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 107, Eposta = "rabia@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 108, Eposta = "sevda@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 109, Eposta = "serhat@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 110, Eposta = "engin@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 111, Eposta = "asli@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 112, Eposta = "tuba@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 113, Eposta = "bariş@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 114, Eposta = "sevgi@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 115, Eposta = "kalender@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 3 },
                                    new Kullanıcı { KullanıcıID = 116, Eposta = "halil@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 117, Eposta = "bilge@icloud.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 1 },
                                    new Kullanıcı { KullanıcıID = 118, Eposta = "ferda@gmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 },
                                    new Kullanıcı { KullanıcıID = 119, Eposta = "ezgi@hotmail.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 2 },
                                    new Kullanıcı { KullanıcıID = 120, Eposta = "aysun@outlook.com", Şifre = "Qwe123", ŞifreTekrarı = "Qwe123", RolID = 4 }
                                               );



        }
    }
}
