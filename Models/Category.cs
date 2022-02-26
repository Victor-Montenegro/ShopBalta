using Shop.Language;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Column("CategoryId")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0001")]
        [MaxLength(60, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0002")]
        [MinLength(3, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0004")]
        [DataType("NVARCHAR(200)")]
        public string Title{ get; set; }
    }
}
