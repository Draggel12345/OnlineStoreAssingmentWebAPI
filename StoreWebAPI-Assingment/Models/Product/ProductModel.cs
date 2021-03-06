namespace StoreWebAPI_Assingment.Models.Product
{
    public class ProductModel
    {
        public Guid ArticleNumber { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
