using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Threading.Tasks;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;

        public ProductController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment env)
        {
            _productService = productService;
            _categoryService = categoryService;
            _env = env;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts(trackChanges: false);
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetOneProduct(id, trackChanges: false);
            return View(product);
        }

        public IActionResult Create()
        {
            LoadCategoriesIntoViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDtoForInsertion model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategoriesIntoViewBag(model.CategoryId);
                return View(model);
            }

            if (model.File != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                }
                model.ImageUrl = "/images/" + uniqueFileName;
            }

            _productService.CreateProduct(model);
            TempData["SuccessMessage"] = "Ürün başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var productDto = _productService.GetOneProductForUpdate(id, false);
            LoadCategoriesIntoViewBag(productDto.CategoryId);
            return View(productDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductDtoForUpdate model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategoriesIntoViewBag(model.CategoryId);
                return View(model);
            }

            if (model.File != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                }
                model.ImageUrl = "/images/" + uniqueFileName;
            }

            _productService.UpdateOneProduct(model);
            TempData["SuccessMessage"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _productService.DeleteOneProduct(id);
            TempData["SuccessMessage"] = "Ürün başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

        private void LoadCategoriesIntoViewBag(int? selectedId = null)
        {
            var categories = _categoryService.GetAllCategories(trackChanges: false);
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", selectedId);
        }
    }
}
