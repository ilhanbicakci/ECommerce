using System.Collections.Generic;

namespace Core.Concretes.DTOs
{
    public class ProductDetailDTO
    {
        public int ProductId { get; set; }
        public IEnumerable<string> Photo { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public decimal ListPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal DiscountRatio { get; set; }
    }
}
