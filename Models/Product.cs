using Shop.Language;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0001")]
        [MaxLength(60, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0002")]
        [MinLength(3, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0004")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0002")]

        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0001")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0005")]
        public decimal Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0001")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0005")]
        public int CategoryId { get; set; }

        public Category Category { get; set; } 
    }
}
