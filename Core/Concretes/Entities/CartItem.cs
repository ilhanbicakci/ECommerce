using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class CartItem : BaseEntity
    {
        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }

}
