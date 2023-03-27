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

namespace Licenta_Kovacs_Adela.Pages.TipuriLapte
{
    public class EditModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public EditModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lapte Lapte { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lapte == null)
            {
                return NotFound();
            }

            var lapte =  await _context.Lapte.FirstOrDefaultAsync(m => m.ID == id);
            if (lapte == null)
            {
                return NotFound();
            }
            Lapte = lapte;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // PENTRU IMAGINE -> transformam imaginea intr-un string de tipul base64-encoded
            byte[] bytes = null;
            if (Lapte.LapteImg != null)
            {
                using (Stream fisier = Lapte.LapteImg.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fisier))
                    {
                        bytes = br.ReadBytes((Int32)fisier.Length);
                    }

                }
                Lapte.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }

            _context.Attach(Lapte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LapteExists(Lapte.ID))
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

        private bool LapteExists(int id)
        {
          return (_context.Lapte?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
