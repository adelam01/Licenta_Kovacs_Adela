namespace Licenta_Kovacs_Adela.Models
{
    public class CafeaDataClient
    {
        public IEnumerable<CafeaClient> CafeleClient { get; set; }
        public IEnumerable<Topping> Topping { get; set; }
        public IEnumerable<CafeaTipuriToppingClient> CafeaTipuriToppingClient { get; set; }
    }
}
