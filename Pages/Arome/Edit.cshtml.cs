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

namespace Licenta_Kovacs_Adela.Pages.Arome
{
    public class EditModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public EditModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
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

            var aroma =  await _context.Aroma.FirstOrDefaultAsync(m => m.ID == id);
            if (aroma == null)
            {
                return NotFound();
            }
            Aroma = aroma;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // PENTRU IMAGINE -> transformam imaginea intr-un string de tipul base64-encoded
            byte[] bytes = null;
            if (Aroma.AromaImg != null)
            {
                using (Stream fisier = Aroma.AromaImg.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fisier))
                    {
                        bytes = br.ReadBytes((Int32)fisier.Length);
                    }

                }
                Aroma.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }

            _context.Attach(Aroma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AromaExists(Aroma.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AromaExists(int id)
        {
          return (_context.Aroma?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
