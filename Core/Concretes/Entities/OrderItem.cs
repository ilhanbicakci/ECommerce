using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class OrderItem : BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public virtual Product Product { get; set; }

    }

}
