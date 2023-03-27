using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licenta_Kovacs_Adela.Data;
using Licenta_Kovacs_Adela.Models;

namespace Licenta_Kovacs_Adela.Pages.Marimi
{
    public class DeleteModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public DeleteModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Marime Marime { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marime == null)
            {
                return NotFound();
            }

            var marime = await _context.Marime.FirstOrDefaultAsync(m => m.ID == id);

            if (marime == null)
            {
                return NotFound();
            }
            else 
            {
                Marime = marime;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Marime == null)
            {
                return NotFound();
            }
            var marime = await _context.Marime.FindAsync(id);

            if (marime != null)
            {
                Marime = marime;
                _context.Marime.Remove(Marime);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
