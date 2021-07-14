using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public int Age { get; set; }

        public int Gender { get; set; } // 1-Ж, 2-М
    }
}
