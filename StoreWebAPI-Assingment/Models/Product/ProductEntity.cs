using StoreWebAPI_Assingment.Models.Category;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreWebAPI_Assingment.Models.Product
{
    public class ProductEntity
    {
        public ProductEntity()
        {

        }

        public ProductEntity
            (Guid articleNumber,
            string name,
            string description,
            decimal price,
            Guid categoryId,
            CategoryEntity category)
        {
            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Category = category;
        }

        [Key]
        public Guid ArticleNumber { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; } = null!;
    }
}
