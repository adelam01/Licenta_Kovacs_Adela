using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licenta_Kovacs_Adela.Data;
using Licenta_Kovacs_Adela.Models;

namespace Licenta_Kovacs_Adela.Pages.CafeleClient
{
    public class IndexModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public IndexModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        public IList<CafeaClient> CafeaClient { get; set; } = default!;
        public CafeaDataClient CafeaDClient { get; set; }
        public int CafeaID { get; set; }
        public int ToppingID { get; set; }

        // PENTRU CAUTARE - SEARCH STRING
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, string searchString, int? toppingID)
        {
            CafeaDClient = new CafeaDataClient();
            CurrentFilter = searchString;

                CafeaDClient.CafeleClient = await _context.CafeaClient
                .Include(c => c.TipCafea)
                .Include(c => c.Bob)
                .Include(c => c.Lapte)
                .Include(c => c.Aroma)
                .Include(c => c.Marime)
                .Include(b => b.CafeaTipuriToppingClient)
                .ThenInclude(b => b.Topping)
                .AsNoTracking()
                .OrderBy(b => b.DenumireCafea)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                CafeaDClient.CafeleClient = CafeaDClient.CafeleClient.Where(s => s.TipCafea.Tip.Contains(searchString)

               || s.Bob.DenumireBoabe.Contains(searchString)
               || s.Lapte.DenumireLapte.Contains(searchString)
               || s.Aroma.DenumireAroma.Contains(searchString)
               || s.DenumireCafea.Contains(searchString));
            }

            if (id != null)
            {
                CafeaID = id.Value;
                CafeaClient cafea = CafeaDClient.CafeleClient
                .Where(i => i.ID == id.Value).Single();
                CafeaDClient.Topping = cafea.CafeaTipuriToppingClient.Select(s => s.Topping);

            }
        }
    }
}
