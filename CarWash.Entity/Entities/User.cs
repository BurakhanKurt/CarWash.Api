using CarWash.Core.Entity;

namespace CarWash.Entity.Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
