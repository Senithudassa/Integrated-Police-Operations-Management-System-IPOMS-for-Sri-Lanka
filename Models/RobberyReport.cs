

namespace testproj.Models
{
    public class RobberyReport
    {
        public int Id { get; set; } // Primary Key
        public string Location { get; set; }
        public DateTime DateOfIncident { get; set; }
        public string Description { get; set; }
        public string CaseStatus { get; set; } // Open, Closed, Under Investigation
    }
}
