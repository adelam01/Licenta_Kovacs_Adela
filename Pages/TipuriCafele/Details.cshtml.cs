﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Licenta_Kovacs_Adela.Data;
using Licenta_Kovacs_Adela.Models;

namespace Licenta_Kovacs_Adela.Pages.TipuriCafele
{
    public class DetailsModel : PageModel
    {
        private readonly Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext _context;

        public DetailsModel(Licenta_Kovacs_Adela.Data.Licenta_Kovacs_AdelaContext context)
        {
            _context = context;
        }

      public TipCafea TipCafea { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TipCafea == null)
            {
                return NotFound();
            }

            var tipcafea = await _context.TipCafea.FirstOrDefaultAsync(m => m.ID == id);
            if (tipcafea == null)
            {
                return NotFound();
            }
            else 
            {
                TipCafea = tipcafea;
            }
            return Page();
        }
    }
}
