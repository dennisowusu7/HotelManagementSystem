

namespace BaseLibrary.Entities
{
    public class Logs
    {
        public DateTime CreateOn { get; set; }
        public int Id { get; set; }
        public string Operation { get; set; } = string.Empty;
        public Employee? Employee { get; set; }
        public int EmployeeId {  get; set; }
        public ApplicationUser? User { get; set; }
        public int UserId { get; set; }
    }
}
