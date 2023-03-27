using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Licenta_Kovacs_Adela.Models
{
    public class Aroma
    {
        public int ID { get; set; }

        [Display(Name = "Aroma")]
        [RegularExpression(@"^[A-ZĂÎȘȚ]+[a-zăîșț\s]*$", ErrorMessage = "Denumirea aromei trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3")]
        [StringLength(70, MinimumLength = 3)]
        public string DenumireAroma { get; set; }

        //pentru imagine
        public string? Imagine { get; set; }

        [Display(Name = "Imagine")]
        [NotMapped]
        public IFormFile AromaImg { get; set; }

        [StringLength(8, MinimumLength = 5, ErrorMessage = "Capacitatea maximă a pozei încarcate este de 28.6 MB")]

        //O sa contina referinta catre mai multe cafele create de client
        public ICollection<CafeaClient>? CafeleClient { get; set; }
    }
}
