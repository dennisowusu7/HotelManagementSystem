using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Relationship
    {
        //Relationship: One to Many
        public List<Employee>? Employees { get; set; }
        public List<CompanyInfo>? CompanyInfos { get; set; }
        public List<Customer>? Customers { get; set; }
        public List<Check>? Checks { get; set; }
        
        public List<GeneralDepartment>? GeneralDepartments { get; set; }
    }
}
