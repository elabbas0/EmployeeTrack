namespace EmployeeTrack.Models.Entities
{
    public class Visit
    {   
        public int Id { get; set; }
        
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
