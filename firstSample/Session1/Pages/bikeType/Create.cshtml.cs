using BikeStore.DataAccess;
using BikeStore.DataAccess.Repository.IRepository;
using BikeStore.Models;
using BikeStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Session1.Pages.bikeType
{
    [Authorize(Roles = WebSiteRoles.Role_Admin)]
    public class CreateModel : PageModel
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public BikeType BikeType { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //add more logic here

            if (ModelState.IsValid)
            {
                //custom validation
                if (BikeType.Name.Any(char.IsDigit))
                {
                    ModelState.AddModelError("BikeType.Name", "The Name of the bike Cannot have any digit");
                    return Page();
                }
                _unitOfWork.BikeType.Add(BikeType);
                _unitOfWork.Save();
                //_db.BikeType.Add(BikeType); 
                //await _db.SaveChangesAsync();

                TempData["success"] = "Bike Type created successfully";

                return RedirectToPage("Index");
            }

            return Page();
           
        }

        //public IActionResult OnPost(BikeType bikeType)
        //{
        //    _db.BikeType.Add(bikeType);
        //    _db.SaveChanges();


        //    return RedirectToPage("Index");
        //}
    }
}
