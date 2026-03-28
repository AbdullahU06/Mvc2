using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Entities.Models;

public class Order
{
    [BindNever]
    public int OrderId { get; set; }

    [BindNever]
    public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Line 1 is required")]
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }

    [Required(ErrorMessage = "City is required")]
    public string? City { get; set; }

    public bool GiftWrap { get; set; }

    [BindNever]
    public bool Shipped { get; set; }
}
