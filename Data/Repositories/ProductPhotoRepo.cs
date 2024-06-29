using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Models;

namespace Data.Repositories
{
    public class ProductPhotoRepo : GenericRepository<ProductPhoto>, IProductPhotoRepo
    {
        public ProductPhotoRepo(DogalSepetContext context) : base(context)
        {
        }
    }
}