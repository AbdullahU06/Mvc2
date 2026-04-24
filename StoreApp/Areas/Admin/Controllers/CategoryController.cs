namespace StoreApp.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Store.Entities.Models;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

            _categoryService.CreateOneCategory(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetOneCategory(id, trackChanges: false);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Category model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _categoryService.UpdateOneCategory(id, model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteOneCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
