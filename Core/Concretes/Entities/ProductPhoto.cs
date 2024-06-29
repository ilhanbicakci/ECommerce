using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class ProductPhoto : BaseEntity
    {
        public int ProductPhotoId { get; set; }
        public string PhotoUrl { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

}
