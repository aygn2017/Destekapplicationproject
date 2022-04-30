using System.ComponentModel.DataAnnotations;

namespace DestekApp.Models
{
    public class Adres
    {
        [Key]
        public int AdresID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }
        public string AdresAdı { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Adres Bilgisi"), StringLength(200, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string AdresBilgisi { get; set; }


        public Kullanıcı Kullanıcı { get; set; }
    }
}
