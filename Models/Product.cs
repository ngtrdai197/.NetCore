namespace NetCoreUsingVsCode.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string UrlPhoto { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public virtual Category Category { get; set; }
    }
}