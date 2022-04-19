using System.ComponentModel.DataAnnotations;

namespace StoreWebAPI_Assingment.Models.Order
{
    public class OrderEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string OrderStatus { get; set; } = null!;
        public virtual ICollection<OrderRowEntity> OrderRows { get; set; } = null!;
    }
}
