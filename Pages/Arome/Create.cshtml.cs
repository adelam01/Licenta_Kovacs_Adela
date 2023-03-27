using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Licenta_Kovacs_Adela.Data;
using Licenta_Kovacs_Adela.Models;

namespace Licenta_Kovacs_Adela.Pages.Arome
{
    public class CreateModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public CreateModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Aroma Aroma { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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

            _context.Aroma.Add(Aroma);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
