using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licenta_Kovacs_Adela.Data;
using Licenta_Kovacs_Adela.Models;

namespace Licenta_Kovacs_Adela.Pages.Boabe
{
    public class DeleteModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public DeleteModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Bob Bob { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bob == null)
            {
                return NotFound();
            }

            var bob = await _context.Bob.FirstOrDefaultAsync(m => m.ID == id);

            if (bob == null)
            {
                return NotFound();
            }
            else 
            {
                Bob = bob;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bob == null)
            {
                return NotFound();
            }
            var bob = await _context.Bob.FindAsync(id);

            if (bob != null)
            {
                Bob = bob;
                _context.Bob.Remove(Bob);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
