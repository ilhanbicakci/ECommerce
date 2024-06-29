using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Models;

namespace Data.Repositories
{
    public class CargoRepo : GenericRepository<Cargo>, ICargoRepo
    {
        public CargoRepo(DogalSepetContext context) : base(context)
        {
        }
    }
}