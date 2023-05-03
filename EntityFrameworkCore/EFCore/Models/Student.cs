using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    internal class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public override string ToString()
        {
            return $"Student {Id} : {Firstname} {Lastname}";
        }
    }
}
