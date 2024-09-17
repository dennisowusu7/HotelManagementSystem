

namespace BaseLibrary.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; } 
        public string? Name { get; set; }   

        ////Relationship: One to Many
        //public List<Employee>? Employees { get; set; }
        //public List<CompanyInfo>? CompanyInfos { get; set; }
        //public List<Customer>? Customers { get; set; }
        //public List<Check>? Checks { get; set; }
    }
}
