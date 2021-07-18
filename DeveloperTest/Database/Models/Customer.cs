using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Database.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
