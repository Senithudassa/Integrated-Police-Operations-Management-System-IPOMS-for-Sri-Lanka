using System.ComponentModel.DataAnnotations;

namespace testproj.Models
{
    public class Accident
    {
        [Key]
        public int Id { get; set; }
        public string ReporterName { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public DateTime ReportDate { get; set; } = DateTime.Now;
    }
}

