namespace EmployeeTrack.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string fatherName { get; set; } = string.Empty;

        public DateOnly startTime { get; set; }
        public DateOnly? endTime { get; set; }

        public string position { get; set; } = string.Empty;
        public int positionId { get; set; }

        public float salary { get; set; }
    }
}
