using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeStore.DataAccess;
using BikeStore.Models;

namespace Session1.Pages.tire
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tire Tire { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tire == null)
            {
                return NotFound();
            }

            var tire = await _context.Tire.FirstOrDefaultAsync(m => m.Id == id);

            if (tire == null)
            {
                return NotFound();
            }
            else 
            {
                Tire = tire;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tire == null)
            {
                return NotFound();
            }
            var tire = await _context.Tire.FindAsync(id);

            if (tire != null)
            {
                Tire = tire;
                _context.Tire.Remove(Tire);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
