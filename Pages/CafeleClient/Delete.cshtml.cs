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
    public class DeleteModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public DeleteModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CafeaClient CafeaClient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CafeaClient == null)
            {
                return NotFound();
            }

            var cafeaclient = await _context.CafeaClient
                .Include(c => c.TipCafea)
                .Include(c => c.Bob)
                .Include(c => c.Lapte)
                .Include(c => c.Aroma)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (cafeaclient == null)
            {
                return NotFound();
            }
            else 
            {
                CafeaClient = cafeaclient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CafeaClient == null)
            {
                return NotFound();
            }
            var cafeaclient = await _context.CafeaClient.FindAsync(id);

            if (cafeaclient != null)
            {
                CafeaClient = cafeaclient;
                _context.CafeaClient.Remove(CafeaClient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
