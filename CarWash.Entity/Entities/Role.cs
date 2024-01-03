using CarWash.Core.Entity;

namespace CarWash.Entity.Entities
{
    public class Role : EntityBase
    {
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
