using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {
        public Employees Employees { get; set; }
        [Key][ForeignKey("Employees")]
        public int UserId { get; set; }

        public string UserPassword { get; set; }
    }
}
