using System.ComponentModel.DataAnnotations;

namespace DestekApp.Models
{
    public class Frekans
    {
        [Key]
        public int FrekansID { get; set; }
        [Required(ErrorMessage = "{0} gerekli."), Display(Name = "Frekans Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} en az {2} en fazla {1} karakter olabilir.")]
        public string FrekansAdı { get; set; }
    }
}
