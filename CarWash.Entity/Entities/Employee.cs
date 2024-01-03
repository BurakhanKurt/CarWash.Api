namespace CarWash.Entity.Entities
{
    public class Employee : User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public EmployeeAttendance EmployeeAttendance { get; set; }
        public ICollection<EmployeeWashProcess> WashProcesses { get; set; }
    }
}
