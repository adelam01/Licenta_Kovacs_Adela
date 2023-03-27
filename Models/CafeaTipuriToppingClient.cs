namespace Licenta_Kovacs_Adela.Models
{
    public class CafeaTipuriToppingClient
    {
        public int ID { get; set; }

        // Cheie straina pt cafea
        public int CafeaClientID { get; set; }
        public CafeaClient CafeaClient { get; set; }

        // Cheie straina pentru Tip Topping
        public int ToppingID { get; set; }
        public Topping Topping { get; set; }
    }
}
