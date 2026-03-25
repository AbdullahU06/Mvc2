namespace StoreApp.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Store.Entities.Models;

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories(trackChanges: false);
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = _categoryService.GetOneCategory(id, trackChanges: false);
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Todo: Db ekleme için service/repository'de metot yazın (Add, Save) ve çağırın
            return RedirectToAction(nameof(Index));
        }
    }
}