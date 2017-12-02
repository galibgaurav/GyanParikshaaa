using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyanPariksha.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public DateTime YearOfEstb { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
