namespace testproj.Models
{
    public class NarcoticActivity
    {
        public int Id { get; set; } // Primary Key
        public string Activity { get; set; }
        public string Suspect { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
    }
}

