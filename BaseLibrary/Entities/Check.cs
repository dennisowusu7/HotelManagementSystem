

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Check
    {
        public int Id { get; set; }
        public DateTime CheckedInDateTime { get; set; }
        public DateTime CheckedOutDateTime { get; set; }
        [DefaultValue(0.00)]
        [DataType(DataType.Currency)] 
        public decimal? AmountPaid { get; set; }
        [DefaultValue(0.00)]
        [DataType(DataType.Currency)]
        public decimal? Balance { get; set; }
        [DefaultValue("N/A")]
        public string? TransactionNumber {  get; set; }

        [DefaultValue("Checked-In")]
        public string? Status { get; set; }

        //Relationship: Many to one
        public CheckType? CheckType { get; set; }
        public int CheckTypeId { get; set; }

        public Room? Room { get; set; }
        public int RoomId { get; set; }

        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }

        public ModeOfPayment? ModeOfPayment { get; set; }
        public int ModeOfPaymentId { get; set; }

        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
