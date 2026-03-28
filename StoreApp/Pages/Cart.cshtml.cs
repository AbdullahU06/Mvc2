using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductService _productService;
        
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IProductService productService, Cart cart)
        {
            _productService = productService;
            Cart = cart;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            var product = _productService.GetOneProduct(productId, false);
            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        
        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            var product = _productService.GetOneProduct(productId, false);
            if (product != null)
            {
                Cart.RemoveLine(product);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
