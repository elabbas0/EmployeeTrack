using EmployeeTrack.Models.Common;

namespace EmployeeTrack.Models.Entities
{
    public class Position : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual IEnumerable<Employee>? Employees { get; set; }
    }
}
