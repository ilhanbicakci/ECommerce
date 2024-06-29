using Core.Abstracts.Bases;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhoto { get; set; } = new HashSet<ProductPhoto>();
        public bool Discounted { get; set; } = false;
        public decimal DiscountRatio { get; set; }
        public decimal TaxRatio { get; set; }
    }
}


