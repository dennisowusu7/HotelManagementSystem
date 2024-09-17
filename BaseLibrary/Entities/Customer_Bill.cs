

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Customer_Bill
    {
        public int Id { get; set; }
        public string ReceiptN_No { get; set; } = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Customer? Customer { get; set; }
        public int? CustomerId { get; set; }
        public Bill_Plan? Bill { get; set; }
        public int? BillId { get; set; }
        public string Bill_Name { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Bill_Amount { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Bill_Discount { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Total_Amount_Due { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Previous_Balance { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Total_Balance { get; set; }
    }
}
