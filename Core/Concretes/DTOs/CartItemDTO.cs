﻿namespace Core.Concretes.DTOs
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductListItemDTO Product { get; set; }
    }
}
