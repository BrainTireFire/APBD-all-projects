using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie2
{
    public class Student
    {
        public string IndexNumber { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public DateOnly Birthdate { get; set; }
        public string Email { get; set; } = null!;
        public string MothersName { get; set; } = null!;
        public string FathersName { get; set; } = null!;
        public Studies Studies { get; set; } = null!;
    }
}
