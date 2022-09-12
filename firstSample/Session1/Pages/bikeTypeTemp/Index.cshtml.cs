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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BikeType> BikeType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BikeType != null)
            {
                BikeType = await _context.BikeType.ToListAsync();
            }
        }
    }
}
