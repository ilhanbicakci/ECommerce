using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class ProductListItemDTO
    {
        public int ProductId { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal ListPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
