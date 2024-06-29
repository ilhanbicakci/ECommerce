using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IShopService
    {
        ProductDetailDTO GetProduct(int id);
        IEnumerable<ProductListItemDTO> GetProducts(Expression<Func<Product, bool>> expression = null);    

        CartDTO GetCart(string user_id);
        CartDTO AddToCart(int product_id, string user_id, int qty);
    }
}
