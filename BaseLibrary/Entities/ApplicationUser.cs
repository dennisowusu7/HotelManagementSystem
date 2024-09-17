

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(10)]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(8)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [StringLength(250)]
        public string Answer { get; set; } = string.Empty;
        public SecurityQuestion? SecurityQuestion { get; set; }
        public int SecurityQuestionId { get; set; }
    }
}
