using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public IEnumerable<CartItemDTO> Items { get; set; }
        public int ItemCount => Items.Count();
    }


}
