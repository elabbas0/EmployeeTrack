using EmployeeTrack.Models.Common;

namespace EmployeeTrack.Models.Entities
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;

        public DateOnly StartDate { get; set; }
        public DateOnly? StopDate { get; set; }

        public decimal Salary { get; set; }

        public int PositionId { get; set; }
        public virtual Position? Position { get; set; }

        public virtual Visit? Visit { get; set; }
    }
}
