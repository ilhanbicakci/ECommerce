using Core.Abstracts.Bases;
using Core.Concretes.Constants;
using System;
using System.Collections.Generic;

namespace Core.Concretes.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }

}
