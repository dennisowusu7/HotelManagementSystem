using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class CompanyInfo : BaseEntity
    {
        public string? RegistrationNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? WebsiteAddress { get; set; }
        public string? Logo { get; set; }
        public string? FaxNumber { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
