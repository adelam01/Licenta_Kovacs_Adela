using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Licenta_Kovacs_Adela.Models
{
    public class Marime
    {
        public int ID { get; set; }

        [Display(Name = "Marime - ml")]
        public string MarimeMl { get; set; }

        //O sa contina referinta catre mai multe cafele
        public ICollection<CafeaClient>? CafeleClient { get; set; }
    }
}
