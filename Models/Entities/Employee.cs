namespace EmployeeTrack.Models.Entities
{
    public class Employee
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
        public int? CountryId { get; set; }
        public virtual Country? Country { get; set; }
    }
}
