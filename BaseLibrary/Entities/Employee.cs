

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Employee : BaseEntity
    {
        [Required]
        [StringLength(100)]
        [MinLength(5)]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        [Required] 
        [StringLength(14)]
        public string? TelephoneNumber { get; set; }
        public string? Photo { get; set; }



        //Relationship : Many to one
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }

        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
