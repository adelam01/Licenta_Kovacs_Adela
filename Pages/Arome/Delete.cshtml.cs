using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licenta_Kovacs_Adela.Data;
using Licenta_Kovacs_Adela.Models;

namespace Licenta_Kovacs_Adela.Pages.Arome
{
    public class DeleteModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public DeleteModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Aroma Aroma { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Aroma == null)
            {
                return NotFound();
            }

            var aroma = await _context.Aroma.FirstOrDefaultAsync(m => m.ID == id);

            if (aroma == null)
            {
                return NotFound();
            }
            else 
            {
                Aroma = aroma;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Aroma == null)
            {
                return NotFound();
            }
            var aroma = await _context.Aroma.FindAsync(id);

            if (aroma != null)
            {
                Aroma = aroma;
                _context.Aroma.Remove(Aroma);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
