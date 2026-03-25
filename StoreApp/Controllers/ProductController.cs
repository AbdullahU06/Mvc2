using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Repositories;
using Repositories.Contracts;
using Entities;
using Services.Contracts;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {


        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);

        }
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var product = _manager.ProductService.GetOneProduct(id, false);
            return View(product);
        }

    }


}
