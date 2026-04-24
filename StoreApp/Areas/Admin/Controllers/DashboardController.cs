using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IServiceManager _manager;

        public DashboardController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            ViewBag.TotalProducts = _manager.ProductService.GetAllProducts(false).Count();
            ViewBag.TotalCategories = _manager.CategoryService.GetAllCategories(false).Count();
            ViewBag.TotalOrders = _manager.OrderService.Orders.Count();
            ViewBag.PendingOrders = _manager.OrderService.NumberOfInProcess;
            return View();
        }
    }
}
