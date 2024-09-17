using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Customer 
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public string? Nationality { get; set; }
        [Required]
        public string IdentificationNumber { get; set; } = string.Empty;
        public string? Address {  get; set; }

        //Relationship: Many to One
        public Identification? Identification { get; set; }
        public int IdentificationId { get; set; }

        public Branch? Branch { get; set; }
        public int BranchId { get; set; }
    }
}
