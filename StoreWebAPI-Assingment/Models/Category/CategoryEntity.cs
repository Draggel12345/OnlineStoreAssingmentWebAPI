using StoreWebAPI_Assingment.Models.Product;
using System.ComponentModel.DataAnnotations;

namespace StoreWebAPI_Assingment.Models.Category
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {

        }

        public CategoryEntity(Guid id, string name, ICollection<ProductEntity> products)
        {
            Id = id;
            Name = name;
            Products = products;
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
