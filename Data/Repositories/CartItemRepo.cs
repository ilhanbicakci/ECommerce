using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Models;

namespace Data.Repositories
{
    public class CartItemRepo : GenericRepository<CartItem>, ICartItemRepo
    {
        public CartItemRepo(DogalSepetContext context) : base(context)
        {
        }
    }
}