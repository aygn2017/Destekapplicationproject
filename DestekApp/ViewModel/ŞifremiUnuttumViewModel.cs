using System.ComponentModel.DataAnnotations;

namespace DestekApp.ViewModel
{
    public class ŞifremiUnuttumViewModel
    {
        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "E-posta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string EpostaKapalıı { get; set; }

        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Şifre"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir."), DataType(DataType.Password), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "Şifre en az bir küçük harf bir büyük harf ve bir rakam içermelidir.")]
        public string Şifre { get; set; }

        [Display(Name = "Şifre Tekrarı"), DataType(DataType.Password), Compare("Şifre", ErrorMessage = "Şifre ve tekrarı uyuşmuyor.")]
        public string ŞifreTekrarı { get; set; }

    }
}
