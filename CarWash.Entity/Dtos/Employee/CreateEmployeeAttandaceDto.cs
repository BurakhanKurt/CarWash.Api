using CarWash.Entity.Enums;

namespace CarWash.Entity.Dtos.Employee
{
    public record CreateEmployeeAttandaceDto
    {
        public int UserId { get; init; }
        public List<Days>? OffDays { get; init; }
        public TimeSpan? BreakDuration { get; init; }
        public DateTime ClockOutDate { get; init; }
        public DateTime ClockInDate { get; init; }
        public DateTime HireDate { get; init; }
    }
}
