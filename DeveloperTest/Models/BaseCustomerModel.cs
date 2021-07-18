using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Models
{
    public class BaseCustomerModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be at least 5 characters long.")]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
