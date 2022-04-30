using System.ComponentModel.DataAnnotations;

namespace DestekApp.Models
{
    public class İhtiyaç
    {
        [Key]
        public int İhtiyaçID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "İhtiyaç Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string  İhtiyaçAdı { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "İhtiyaç Açıklama"), StringLength(400, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string   İhtiyaçAçıklama { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Frekans"),Range(1,100,ErrorMessage ="{0} Seçilmeli.")]
        public int FrekansID { get; set; }

        [Required(ErrorMessage ="{0} gerekli."),Display(Name ="Kayıt Tarihi"),DataType(DataType.Date),DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime KayıtTarihi { get; set; }






        public Frekans Frekans { get; set; }
        public Kullanıcı Kullanıcı { get; set; }

    }
}
