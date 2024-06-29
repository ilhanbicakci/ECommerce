using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Models;

namespace Data.Repositories
{
    public class OrderRepo : GenericRepository<Order>, IOrderRepo
    {
        public OrderRepo(DogalSepetContext context) : base(context)
        {
        }
    }
}