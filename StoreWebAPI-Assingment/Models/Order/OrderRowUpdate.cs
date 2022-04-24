namespace StoreWebAPI_Assingment.Models.Order
{
    public class OrderRowUpdate
    {

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
