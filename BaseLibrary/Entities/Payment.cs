

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime? PaymentDateTime { get; set; } = DateTime.Now;
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal? TotalFee { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Paid { get; set; }
        [DataType(DataType.Currency)]
        [DefaultValue(0.00)]
        public decimal Balance { get; set;}
        public ModeOfPayment? ModeOfPayment { get; set; }
        public int ModeOfPaymentID { get; set; }
        [DefaultValue("N/A")]
        public string TransactionID { get; set; } = string.Empty;
        public string ReceiptNo { get; set; } = string.Empty;
        public string PaymentDescription { get; set; } = string.Empty;
    }
}
