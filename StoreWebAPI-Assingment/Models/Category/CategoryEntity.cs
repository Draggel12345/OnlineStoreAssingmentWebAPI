using StoreWebAPI_Assingment.Models.Product;
using System.ComponentModel.DataAnnotations;

namespace StoreWebAPI_Assingment.Models.Category
{
    public class CategoryEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
