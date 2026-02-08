using EmployeeTrack.Models.Common;

namespace EmployeeTrack.Models.Entities
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
