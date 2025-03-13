using System.ComponentModel.DataAnnotations;

namespace testproj.Models
{
    public class Violation
    {
        [Key]
        public int Id { get; set; }
        public string OffenderName { get; set; }
        public string ViolationType { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
