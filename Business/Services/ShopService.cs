using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.Constants;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork unitOfWork;

        public ShopService()
        {
            unitOfWork = new UnitOfWork();
        }


        public static int GetCartItemCount(string uid)
        {
            IShopService service = new ShopService();
            return service.GetCart(uid).ItemCount;
        }

        public CartDTO AddToCart(int product_id, string user_id, int qty)
        {
            var cart = GetCart(user_id);
            var item = unitOfWork.CartItemRepo.ReadFirst(x => x.ShoppingCartId == cart.Id && x.ProductId == product_id);
            if(item==null)
            {
                item = new CartItem
                {
                    ProductId = product_id,
                    Quantity = qty,
                    ShoppingCartId = cart.Id
                };
                unitOfWork.CartItemRepo.CreateOne(item);
            }
            else
            {
                item.Quantity += qty;
                unitOfWork.CartItemRepo.UpdateOne(item);
            }
            unitOfWork.Commit();
            return GetCart(user_id);

        }

        public CartDTO GetCart(string user_id)
        {
            var cart = unitOfWork.ShoppingCartRepo.ReadFirst(x => x.Active && !x.Deleted && x.Status == ShoppingCartStatus.Active && x.CustomerId == user_id);
            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    CustomerId = user_id,
                    Status = ShoppingCartStatus.Active
                };
                unitOfWork.ShoppingCartRepo.CreateOne(cart);
                unitOfWork.Commit();
            }
            var items = unitOfWork.CartItemRepo.ReadMany(x => x.ShoppingCartId == cart.Id);
            var cartItems = from i in items
                   select new CartItemDTO
                   {
                       Id = i.Id,
                       ProductId = i.ProductId,
                       Quantity = i.Quantity,
                       Product = GetProducts(x => x.Id == i.ProductId).FirstOrDefault()
                   };
            return new CartDTO { Id = cart.Id, Items = cartItems };
        }


        public ProductDetailDTO GetProduct(int id)
        {
            var p = unitOfWork.ProductRepo.ReadOne(id);
            return new ProductDetailDTO
            {
                ProductId = p.Id,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                ListPrice = p.Price * (100 + p.TaxRatio) / 100,
                DiscountedPrice = p.Discounted ? p.Price * ((100 + p.TaxRatio) / 100) * ((100 - p.DiscountRatio) / 100) : 0,
                DiscountRatio = p.Discounted ? p.DiscountRatio : 0,
                Name = p.Name,
                Photo = p.ProductPhoto.Select(x => x.PhotoUrl)

            };
        }

        public IEnumerable<ProductListItemDTO> GetProducts(Expression<Func<Product, bool>> expression = null)
        {
            var data = unitOfWork.ProductRepo.ReadMany(expression);
            return from p in data
                   select new ProductListItemDTO
                   {
                       ProductId = p.Id,
                       Name = p.Name,
                       CategoryName = p.Category.Name,
                       Photo = p.ProductPhoto.FirstOrDefault() != null ? p.ProductPhoto.FirstOrDefault().PhotoUrl : "https://via.placeholder.com/400x600?text=No%2BImage",
                       ListPrice = p.Price * (100 + p.TaxRatio) / 100,
                       DiscountedPrice = p.Discounted ? p.Price * ((100 + p.TaxRatio) / 100) * ((100 - p.DiscountRatio) / 100) : 0
                   };
        }
    }
}
