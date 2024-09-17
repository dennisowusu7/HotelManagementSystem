using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class SecurityQuestion
    {
        public DateTime CreateOn { get; set; }
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
    }
}
