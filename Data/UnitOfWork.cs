using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DogalSepetContext context;

        public UnitOfWork()
        {
            context = DogalSepetContext.Instance;
        }

        private IProductRepo productRepo;
        private ICategoryRepo categoryRepo;
        private IProductPhotoRepo productPhotoRepo;
        private IShoppingCartRepo shoppingCartRepo;
        private ICartItemRepo cartItemRepo;
        private ICargoRepo cargoRepo;
        private IOrderRepo orderRepo;
        private IOrderItemRepo orderItemRepo;

        public IProductRepo ProductRepo => productRepo = productRepo ?? new ProductRepo(context);
        public ICategoryRepo CategoryRepo => categoryRepo = categoryRepo ?? new CategoryRepo(context);
        public IProductPhotoRepo ProductPhotoRepo => productPhotoRepo = productPhotoRepo ?? new ProductPhotoRepo(context);
        public IShoppingCartRepo ShoppingCartRepo => shoppingCartRepo = shoppingCartRepo ?? new ShoppingCartRepo(context);
        public ICartItemRepo CartItemRepo => cartItemRepo = cartItemRepo ?? new CartItemRepo(context);
        public ICargoRepo CargoRepo => cargoRepo = cargoRepo ?? new CargoRepo(context);
        public IOrderRepo OrderRepo => orderRepo = orderRepo ?? new OrderRepo(context);
        public IOrderItemRepo OrderItemRepo => orderItemRepo = orderItemRepo ?? new OrderItemRepo(context);


        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Dispose();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
