using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Utilities.Models;

namespace Data.Repositories
{
    public class ProductRepo : GenericRepository<Product>, IProductRepo
    {
        public ProductRepo(DogalSepetContext context) : base(context)
        {
        }
    }
}