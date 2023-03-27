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
    public class DetailsModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public DetailsModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

      public CafeaClient CafeaClient { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CafeaClient == null)
            {
                return NotFound();
            }

            var cafeaclient = await _context.CafeaClient.FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
