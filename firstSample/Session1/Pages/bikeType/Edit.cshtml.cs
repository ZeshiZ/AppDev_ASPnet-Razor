using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeStore.DataAccess;
using BikeStore.Models;
using BikeStore.DataAccess.Repository;
using BikeStore.DataAccess.Repository.IRepository;

namespace Session1.Pages.bikeType
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public BikeType BikeType { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            BikeType = _unitOfWork.BikeType.GetFirstOrDefault(bikeType=> bikeType.Id == id);
            //BikeType = _db.BikeType.FirstOrDefault(type => type.Id == id);
            //BikeType = _db.BikeType.SingleOrDefault(type => type.Id == id);
            //BikeType = _db.BikeType.Where(type => type.Id == id).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //custom validation
                if (BikeType.Name.Any(char.IsDigit))
                {
                    ModelState.AddModelError("BikeType.Name", "The Name of the bike Cannot have any digit");
                    return Page();
                }

                _unitOfWork.BikeType.Update(BikeType);
                _unitOfWork.Save();
                TempData["success"] = "Bike Type updated successfully";

                return RedirectToPage("Index");
            }

            return Page();

        }


    }
}
