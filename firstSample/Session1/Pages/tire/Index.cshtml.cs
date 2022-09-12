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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Tire> Tire { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tire != null)
            {
                Tire = await _context.Tire.ToListAsync();
            }
        }
    }
}
