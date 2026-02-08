using EmployeeTrack.Models.Common;

namespace EmployeeTrack.Models.Entities
{
    public class VisitIssue : BaseEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string content { get; set; } = string.Empty;

    }
}
