using Shop.Language;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0001")]
        [MaxLength(20,ErrorMessage ="O campo Username pode ter no maximo {0}")]
        [MinLength(3,ErrorMessage = "O campo Username pode ter no minimo {0}")]
        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0001")]
        [MaxLength(20,ErrorMessage = "O campo Password pode ter no maximo {0}")]
        [MinLength(3, ErrorMessage = "O campo Password pode ter no minimo {0}")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
