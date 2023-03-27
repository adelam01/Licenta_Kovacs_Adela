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

namespace Licenta_Kovacs_Adela.Pages.Boabe
{
    public class EditModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public EditModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
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

            var bob =  await _context.Bob.FirstOrDefaultAsync(m => m.ID == id);
            if (bob == null)
            {
                return NotFound();
            }
            Bob = bob;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // PENTRU IMAGINE -> transformam imaginea intr-un string de tipul base64-encoded
            byte[] bytes = null;
            if (Bob.BobImg != null)
            {
                using (Stream fisier = Bob.BobImg.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(fisier))
                    {
                        bytes = br.ReadBytes((Int32)fisier.Length);
                    }

                }
                Bob.Imagine = Convert.ToBase64String(bytes, 0, bytes.Length);

            }
            

            _context.Attach(Bob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BobExists(Bob.ID))
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

        private bool BobExists(int id)
        {
          return (_context.Bob?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
