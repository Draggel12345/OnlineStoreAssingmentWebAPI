using System.ComponentModel.DataAnnotations;

namespace StoreWebAPI_Assingment.Models.Order
{
    public class OrderEntity
    {
        public OrderEntity()
        {

        }

        public OrderEntity
            (Guid id,
            Guid customerId,
            string customerName,
            string address,
            DateTime orderDate,
            string orderStatus,
            ICollection<OrderRowEntity> orderRows)
        {
            Id = id;
            CustomerId = customerId;
            CustomerName = customerName;
            Address = address;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            OrderRows = orderRows;
        }

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
        public string OrderStatus { get; set; } = null!;
        public virtual ICollection<OrderRowEntity> OrderRows { get; set; } = null!;
    }
}
