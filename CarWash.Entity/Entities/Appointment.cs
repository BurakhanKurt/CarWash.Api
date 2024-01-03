using CarWash.Core.Entity;

namespace CarWash.Entity.Entities
{
    public class Appointment : EntityBase
    {
        public int CustomerId { get; set; }
        public int PackageId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public WashPackage WashPackage { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public WashProcess WashProcess { get; set; }
    }
}
