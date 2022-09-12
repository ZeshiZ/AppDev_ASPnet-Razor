using BikeStore.DataAccess.Repository.IRepository;
using BikeStore.Models;
using BikeStore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Session1.Pages.product
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public ProductVM ProductVM { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult OnGet(int? id)
        {
            ProductVM productVM = new();
            if (id == null || id == 0)
            {
                
                //IEnumerable<BikeType> biketypes = unitOfWork.BikeType.GetAll();
                //I will have a dropdown

                //different ways to pass this data to the frontend
                //ViewBag.biketypes = biketypes;
                //MVC -> VIEWBAG

                IEnumerable<SelectListItem> BikeTypeList = unitOfWork.BikeType.GetAll()
                    .Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                productVM.BikeTypeList = BikeTypeList;
                productVM.Product = new Product();

                ViewData["BikeTypes"] = BikeTypeList;
               
            }
            else
            {
                productVM.Product = unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
                
            }
            ProductVM = productVM;
            return Page();

        }

        //[HttpPost] => in the MVC controllers this is the directive to show
        // the type of action
        //[ValidateAntiForgeryToken]
        public IActionResult OnPost(IFormFile? file)
        {
            //????? why it is invalid
            //if (ModelState.IsValid)
            //{
                if (file != null)
                {
                    var product = ProductVM.Product;
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extension = Path.GetExtension(file.FileName);
                    string fileName = Guid.NewGuid().ToString();
                    if (product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }


                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    ProductVM.Product.ImageUrl = @"\images\products\" + fileName + extension;


                }
                unitOfWork.Product.Add(ProductVM.Product);
                unitOfWork.Save();
        //    }
            
            return Page();
        }
        
        public void Delete()
        {

        }
    }
}
