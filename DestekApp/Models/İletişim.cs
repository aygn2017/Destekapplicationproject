using System.ComponentModel.DataAnnotations;

namespace DestekApp.Models
{
    public class İletişim
    {
        [Key]
        public int İletişimID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }


        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Telefon Numarası"), StringLength(13, MinimumLength = 10, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string TelefonNo { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "İletişim Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string İletişimAdı { get; set; }
        public Kullanıcı Kullanıcı { get; set; }     
    }
}
