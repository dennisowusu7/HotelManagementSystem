using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Bill_Creteria
    {
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int Id { get; set; }
        public string Bill_For { get; set; } = string.Empty;
    }
}
