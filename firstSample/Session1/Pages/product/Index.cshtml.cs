using BikeStore.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Session1.Pages.product
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public JsonResult OnGet()
        {
            //I need Json
            var productList = unitOfWork.Product.GetAll(includeProperties: "BikeType");
            //return Page();
            //return Json(new {data = productList}} //MVC Controller
            //return new JsonResult(productList); //Razor

            return new JsonResult(new
            {
                RecordsTotal = productList.Count(),
                RecordsFiltered = productList.Count(),
                Data = productList
            });
        }
    }
}
