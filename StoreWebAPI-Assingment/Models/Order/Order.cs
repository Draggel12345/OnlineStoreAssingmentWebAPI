namespace StoreWebAPI_Assingment.Models.Order
{
    public class Order
    {
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = null!;
    }
}
