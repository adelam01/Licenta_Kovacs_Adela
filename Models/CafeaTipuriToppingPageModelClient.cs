using Microsoft.AspNetCore.Mvc.RazorPages;
using Licenta_Kovacs_Adela.Data;

namespace Licenta_Kovacs_Adela.Models
{
    public class CafeaTipuriToppingPageModelClient : PageModel
    {
        public List<ToppingAtribuitCafeleiData> AtribuireToppingDataList;
        public void PopulateToppingAtribuitCafeleiData(Licenta_Kovacs_AdelaContext context, CafeaClient cafea)
        {
            var allToppings = context.Topping;
            var cafeaTopping = new HashSet<int>(
            cafea.CafeaTipuriToppingClient.Select(c => c.ToppingID)); 
            AtribuireToppingDataList = new List<ToppingAtribuitCafeleiData>();
            foreach (var cat in allToppings)
            {
                AtribuireToppingDataList.Add(new ToppingAtribuitCafeleiData
                {
                    ToppingID = cat.ID,
                    Denumire = cat.DenumireTopping,
                    Atribuire = cafeaTopping.Contains(cat.ID)
                });
            }
        }
        public void UpdateCafeaTipuriTopping(Licenta_Kovacs_AdelaContext context, string[] selectedToppings, CafeaClient cafeaToUpdate)
        {
            if (selectedToppings == null)
            {
                cafeaToUpdate.CafeaTipuriToppingClient = new List<CafeaTipuriToppingClient>();
                return;
            }
            var selectedToppingsHS = new HashSet<string>(selectedToppings);
            var CafeaTipuriTopping = new HashSet<int>
            (cafeaToUpdate.CafeaTipuriToppingClient.Select(c => c.Topping.ID));
            foreach (var cat in context.Topping)
            {
                if (selectedToppingsHS.Contains(cat.ID.ToString()))
                {
                    if (!CafeaTipuriTopping.Contains(cat.ID))
                    {
                        cafeaToUpdate.CafeaTipuriToppingClient.Add(
                        new CafeaTipuriToppingClient
                        {
                            CafeaClientID = cafeaToUpdate.ID,
                            ToppingID = cat.ID
                        });
                    }
                }
                else
                {
                    if (CafeaTipuriTopping.Contains(cat.ID))
                    {
                        CafeaTipuriToppingClient courseToRemove = cafeaToUpdate
                        .CafeaTipuriToppingClient
                        .SingleOrDefault(i => i.ToppingID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
