using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Ad zorunludur.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
