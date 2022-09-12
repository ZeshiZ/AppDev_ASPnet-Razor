using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.DataAccess;
using BikeStore.Models;
using BikeStore.DataAccess.Repository.IRepository;

namespace Session1.Pages.bikeType
{
    public class IndexModel : PageModel
    {
        //private readonly ApplicationDbContext _db;
        //private readonly IBikeTypeRepository _db;
        private readonly IUnitOfWork _db;
        
        public IEnumerable<BikeType> bikeTypes { get; set; }

        public int Counter { get; set; }

        public IndexModel(IUnitOfWork db)
        {
            _db = db;
        }

        public void OnGet()
        {
            bikeTypes = _db.BikeType.GetAll();
        }
    }
}
