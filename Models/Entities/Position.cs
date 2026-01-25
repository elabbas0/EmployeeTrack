namespace EmployeeTrack.Models.Entities
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual IEnumerable<Employee>? Employees { get; set; }
    }
}
