using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Challenge.Models
{
    public class Plant
    {
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;


    }
}
