using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Models;

namespace Data.Repositories
{
    public class ShoppingCartRepo : GenericRepository<ShoppingCart>, IShoppingCartRepo
    {
        public ShoppingCartRepo(DogalSepetContext context) : base(context)
        {
        }
    }
}