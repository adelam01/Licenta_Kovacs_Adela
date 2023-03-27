using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Licenta_Kovacs_Adela.Models
{
    public class Bob
    {
        public int ID { get; set; }

        [Display(Name = "Boabe")]
        [RegularExpression(@"^[A-ZĂÎȘȚ]+[a-zăîșț\s]*$", ErrorMessage = "Denumirea boabelor trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3")]
        [StringLength(70, MinimumLength = 3)]
        public string DenumireBoabe { get; set; }

        //pentru imagine
        public string? Imagine { get; set; }

        [Display(Name = "Imagine")]
        [NotMapped]
        public IFormFile BobImg { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<CafeaClient>? CafeleClient { get; set; }
    }
}
