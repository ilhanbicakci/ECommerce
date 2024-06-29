using Core.Abstracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepo ProductRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        IProductPhotoRepo ProductPhotoRepo { get; }
        IShoppingCartRepo ShoppingCartRepo { get; }
        ICartItemRepo CartItemRepo { get; }
        ICargoRepo CargoRepo { get; }
        IOrderRepo OrderRepo { get; }
        IOrderItemRepo OrderItemRepo { get; } 

        void Commit();
    }
}

