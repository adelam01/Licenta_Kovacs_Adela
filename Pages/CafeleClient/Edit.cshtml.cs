using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Licenta_Kovacs_Adela.Data;
using Licenta_Kovacs_Adela.Models;
using System.Data;


namespace Licenta_Kovacs_Adela.Pages.CafeleClient
{
    public class EditModel : CafeaTipuriToppingPageModelClient
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public EditModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CafeaClient CafeaClient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CafeaClient =  await _context.CafeaClient
                .Include(b => b.TipCafea)
                .Include(b => b.Bob)
                .Include(b => b.Lapte)
                .Include(b => b.Aroma)
                .Include(b => b.Marime)
                .Include(b => b.CafeaTipuriToppingClient)
                .ThenInclude(b => b.Topping)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            PopulateToppingAtribuitCafeleiData(_context, CafeaClient);


            if (CafeaClient == null)
            {
                return NotFound();
            }

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

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedToppings)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeaActualizare = await _context.CafeaClient
                .Include(i => i.TipCafea)
                .Include(i => i.Bob)
                .Include(i => i.Lapte)
                .Include(i => i.Aroma)
                .Include(i => i.Marime)
                .Include(i => i.CafeaTipuriToppingClient)
                .ThenInclude(i => i.Topping)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (cafeaActualizare == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<CafeaClient>(
            cafeaActualizare,
            "CafeaClient",
            i => i.DenumireCafea, i => i.TipCafeaID, i => i.BobID,
            i => i.LapteID, i => i.AromaID, i => i.MarimeID))
            {
                UpdateCafeaTipuriTopping(_context, selectedToppings, cafeaActualizare);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateCafeaTipuriTopping(_context, selectedToppings, cafeaActualizare);
            PopulateToppingAtribuitCafeleiData(_context, cafeaActualizare);

           
            return Page();
        }

    }
}
