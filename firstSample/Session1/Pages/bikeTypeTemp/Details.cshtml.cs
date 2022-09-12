using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeStore.DataAccess;
using BikeStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Session1.Pages.bikeTypeTemp
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public BikeType BikeType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BikeType == null)
            {
                return NotFound();
            }

            var biketype = await _context.BikeType.FirstOrDefaultAsync(m => m.Id == id);
            if (biketype == null)
            {
                return NotFound();
            }
            else 
            {
                BikeType = biketype;
            }
            return Page();
        }
    }
}
