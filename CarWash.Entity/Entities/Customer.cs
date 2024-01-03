using CarWash.Core.Entity;

namespace CarWash.Entity.Entities
{
    public class Customer : User
    {
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
