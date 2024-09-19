

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class SecurityQuestion
    {
        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string? Question { get; set; }
    }
}
