using Shop.Language;
using Shop.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class User
    {
        [Column("UserId")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0001")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0002")]
        [MinLength(3, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0004")]
        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0001")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0002")]
        [MinLength(3, ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0004")]
        public string Password { get; set; }

        [DataType("TINYINT")]
        [EnumDataType(typeof(Role), ErrorMessageResourceType = typeof(ApiMsg), ErrorMessageResourceName = "ISE0014")]
        public Role Role { get; set; }
    }
}
