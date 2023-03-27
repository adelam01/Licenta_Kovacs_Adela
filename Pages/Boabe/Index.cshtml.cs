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
    public class IndexModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public IndexModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

        public IList<Bob> Bob { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bob != null)
            {
                Bob = await _context.Bob.ToListAsync();
            }
        }
    }
}
