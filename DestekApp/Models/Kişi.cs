using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DestekApp.Models
{
    public class Kişi
    {
        [Key]
        public int KişiID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "Kullanıcı")]
        public int KullanıcıID { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "AD"), StringLength(40, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string AD { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "SoyAD"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string SoyAD { get; set; }

        [Required(ErrorMessage = "{0} Gerekli."), Display(Name = "Cinsiyet")]
        public int CinsiyetID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Doğum Tarihi"), DataType(DataType.Date), Column(TypeName = "Date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DoğumTarih { get; set; }

        [NotMapped]
        public string TamAdı
        {
            get
            {
                return AD + " " + SoyAD;
            }
        }


        public Cinsiyet Cinsiyet { get; set; }
        public Kullanıcı Kullanıcı { get; set; }

    }
}
