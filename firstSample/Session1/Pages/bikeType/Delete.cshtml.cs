using BikeStore.DataAccess;
using BikeStore.DataAccess.Repository.IRepository;
using BikeStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Session1.Pages.bikeType
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public BikeType BikeType { get; set; }

        public DeleteModel(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public void OnGet(int id)
        {
            BikeType = _unitOfWork.BikeType.GetFirstOrDefault(type => type.Id == id);
            //BikeType = _db.BikeType.FirstOrDefault(type => type.Id == id);
            //BikeType = _db.BikeType.SingleOrDefault(type => type.Id == id);
            //BikeType = _db.BikeType.Where(type => type.Id == id).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            var bikeTypeFromDb = _unitOfWork.BikeType.GetFirstOrDefault(type => type.Id == BikeType.Id);
            _unitOfWork.BikeType.Remove(bikeTypeFromDb);
            _unitOfWork.Save();

            TempData["delete"] = "Bike Type Deleted successfully";


            return RedirectToPage("Index");

        }


    }
}
