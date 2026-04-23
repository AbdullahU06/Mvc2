using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public record ProductDtoForInsertion
{
    [Required(ErrorMessage = "Product name is required! / Ürün adı zorunludur!")]
    public string ProductName { get; init; } = string.Empty;

    [Required(ErrorMessage = "Price is required! / Fiyat zorunludur!")]
    public decimal Price { get; init; }

    public string? ImageUrl { get; set; }
    public IFormFile? File { get; set; }

    [Required(ErrorMessage = "Category is required! / Kategori seçimi zorunludur!")]
    public int? CategoryId { get; init; }
}
