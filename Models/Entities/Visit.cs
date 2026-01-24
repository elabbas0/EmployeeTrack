namespace EmployeeTrack.Models.Entities
{
    public class Visit
    {   
        public int Id { get; set; }
        public int employeeId { get; set; }
        public Employee? employee { get; set; }

        public int countryId { get; set; }
        public Country? country { get; set; }

        public Category? category { get; set; }

        public DateOnly startDate { get; set; }
        public DateOnly? endDate { get; set; }
    }
}
