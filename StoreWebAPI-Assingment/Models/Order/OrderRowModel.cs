namespace StoreWebAPI_Assingment.Models.Order
{
    public class OrderRowModel
    {
        public string ArticleNumber { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
