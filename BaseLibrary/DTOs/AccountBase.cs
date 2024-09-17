

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
    public class AccountBase
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
