

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string RoomName { get; set; } = string.Empty;
        [DefaultValue("Available")]
        public string? Status { get; set; }
        public string? Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal? Rate { get; set; }
    }
}
