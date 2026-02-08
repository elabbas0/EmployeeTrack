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

        public int? PositionId { get; set; }
        public virtual Position? Position { get; set; }
<<<<<<< HEAD

        public virtual Visit? Visit { get; set; }
=======
        public int? CountryId { get; set; }
        public virtual Country? Country { get; set; }
>>>>>>> 9d8db6c58a43ab538732866f46d758c10c3ca2c4
    }
}
