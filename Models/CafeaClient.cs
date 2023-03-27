using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Licenta_Kovacs_Adela.Models
{
    public class CafeaClient
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Cafea")]
        [RegularExpression(@"^[A-ZĂÎȘȚ]+[a-zăîșț\s]*$", ErrorMessage = "Denumirea cafelei trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3")]
        public string? DenumireCafea { get; set; }

        //Cheie straina si navigation propery pentru TipCafea
        public int? TipCafeaID { get; set; }
        [Display(Name = "Tip Cafea")]
        public TipCafea? TipCafea { get; set; }

        //Cheie straina si navigation propery pentru TipBoabe
        public int? BobID { get; set; }
        [Display(Name = "Tip Boabe")]
        public Bob? Bob { get; set; }

        //Cheie straina si navigation propery pentru Lapte
        public int? LapteID { get; set; }
        [Display(Name = "Tip Lapte")]
        public Lapte? Lapte { get; set; }

        //Cheie straina si navigation propery pentru Arome
        public int? AromaID { get; set; }
        [Display(Name = "Tip Aroma")]
        public Aroma? Aroma { get; set; }

        //Cheie straina si navigation propery pentru Marime
        public int? MarimeID { get; set; }
        [Display(Name = "Marime")]
        public Marime? Marime { get; set; }

        //Navigation propery pentru Topping
        public ICollection<CafeaTipuriToppingClient>? CafeaTipuriToppingClient { get; set; }

    }
}
