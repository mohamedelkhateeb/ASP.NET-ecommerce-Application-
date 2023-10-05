using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]        
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,500 , ErrorMessage = "Display Order Must Be Between 1 : 500")]
        public int DisplayOrder { get; set; }
    }
}
