using Core.Abstracts.Bases;
using Core.Concretes.Constants;
using System.Collections.Generic;

namespace Core.Concretes.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public string CustomerId { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        public ShoppingCartStatus Status { get; set; } = ShoppingCartStatus.Active;
    }

}
