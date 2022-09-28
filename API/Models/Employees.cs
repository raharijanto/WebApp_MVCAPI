using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public Jobs Jobs { get; set; }
        [ForeignKey("Jobs")]
        public int IdJob { get; set; }

        public Salary Salary { get; set; }
        [ForeignKey("Salary")]
        public int Idsalary { get; set; }
    }
}
