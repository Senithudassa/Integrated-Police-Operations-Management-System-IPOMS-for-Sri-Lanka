using System.ComponentModel.DataAnnotations;

namespace testproj.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public string HolderName { get; set; }
        public bool IsValid { get; set; }
    }
}
