using CarWash.Core.Entity;

namespace CarWash.Entity.Entities
{
    public class Brand : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
