using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Models;

namespace Data.Repositories
{
    public class OrderItemRepo : GenericRepository<OrderItem>, IOrderItemRepo
    {
        public OrderItemRepo(DogalSepetContext context) : base(context)
        {
        }
    }
}