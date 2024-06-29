using Core.Abstracts.Bases;
using Core.Concretes.Constants;

namespace Core.Concretes.Entities
{
    public class Cargo : BaseEntity
    {
        public int OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public virtual Order Order { get; set; }
        public CargoStatus Status { get; set; } = CargoStatus.Shipped;
    }

}
