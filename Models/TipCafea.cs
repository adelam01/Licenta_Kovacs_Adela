using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Licenta_Kovacs_Adela.Models
{
    public class TipCafea
    {
        public int ID { get; set; }

        [Display(Name = "Tip de cafea")]
        [RegularExpression(@"^[A-ZĂÎȘȚ]+[a-zăîșț\s]*$", ErrorMessage = "Denumirea tipului de cafea trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3")]
        [StringLength(70, MinimumLength = 3)]
        public string Tip { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<CafeaClient>? CafeleClient { get; set; }
    }
}
