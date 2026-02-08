using EmployeeTrack.Models.Common;

namespace EmployeeTrack.Models.Entities
{
    public class Category : BaseEntity
    { 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
