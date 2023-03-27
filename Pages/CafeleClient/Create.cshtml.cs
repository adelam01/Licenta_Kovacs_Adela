using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Licenta_Kovacs_Adela.Data;
using Licenta_Kovacs_Adela.Models;

namespace Licenta_Kovacs_Adela.Pages.CafeleClient
{
    public class CreateModel : CafeaTipuriToppingPageModelClient
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public CreateModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // POPULARE VIEWDATA - TIP CAFEA
            var listaMarime = _context.Marime.Select(x => new
            {
                x.ID,
                x.MarimeMl
            });
            ViewData["MarimeID"] = new SelectList(listaMarime, "ID", "MarimeMl");

            // POPULARE VIEWDATA - TIP CAFEA
            var listaTipCafea = _context.TipCafea.Select(x => new
            {
                x.ID,
                x.Tip
            });
            ViewData["TipCafeaID"] = new SelectList(listaTipCafea, "ID", "Tip");

            // POPULARE VIEWDATA - TIP BOABE
            var listaTipBoabe = _context.Bob.Select(x => new
            {
                x.ID,
                x.DenumireBoabe
            });
            ViewData["BobID"] = new SelectList(listaTipBoabe, "ID", "DenumireBoabe");

            // POPULARE VIEWDATA - TIP LAPTE
            var listaTipLapte = _context.Lapte.Select(x => new
            {
                x.ID,
                x.DenumireLapte
            });
            ViewData["LapteID"] = new SelectList(listaTipLapte, "ID", "DenumireLapte");

            // POPULARE VIEWDATA - TIP AROMA
            var listaTipAroma = _context.Aroma.Select(x => new
            {
                x.ID,
                x.DenumireAroma
            });
            ViewData["AromaID"] = new SelectList(listaTipAroma, "ID", "DenumireAroma");

            // POPULARE VIEWDATA - TIP TOPPING
            var listaTipTopping = _context.Topping.Select(x => new
            {
                x.ID,
                x.DenumireTopping
            });
            ViewData["ToppingID"] = new SelectList(listaTipTopping, "ID", "DenumireTopping");

            var cafea = new CafeaClient();
            cafea.CafeaTipuriToppingClient = new List<CafeaTipuriToppingClient>();
            PopulateToppingAtribuitCafeleiData(_context, cafea);
            return Page();
        }

        [BindProperty]
        public CafeaClient CafeaClient { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedToppings)
        {
            var newCafea = new CafeaClient();
            if (selectedToppings != null)
            {
                newCafea.CafeaTipuriToppingClient = new List<CafeaTipuriToppingClient>();
                foreach (var cat in selectedToppings)
                {
                    var catToAdd = new CafeaTipuriToppingClient
                    {
                        ToppingID = int.Parse(cat)
                    };
                    newCafea.CafeaTipuriToppingClient.Add(catToAdd);
                }
            }

            CafeaClient.CafeaTipuriToppingClient = newCafea.CafeaTipuriToppingClient;
            _context.CafeaClient.Add(CafeaClient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
