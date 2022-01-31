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

        [Display(Name = "Titulo")]
        [Required(ErrorMessage ="Necessario passar o campo Titulo.")]
        [MaxLength(length: 200,ErrorMessage = "Numero maximo de caracteres 200.")]
        [MinLength(length: 5,ErrorMessage = "Numero minimo de caracteres 5.")]
        [DataType("NVARCHAR(200)")]
        public string Title { get; set; }
    }
}
