

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Bill_Plan
    {
        public DateTime? Create_On { get; set; } = DateTime.Now;
        public int Id { get; set; }
        public string Bill_Name { get; set; } = string.Empty;
        public string Bill_For { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Bill_Amount { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Bill_Discount { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Total_Bill { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Total_Amount_Due { get; set; }
    }
}
