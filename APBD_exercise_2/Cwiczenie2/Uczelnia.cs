using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie2
{
    public class Uczelnia
    {
        public string CreatedAt { get; set; } = null!;
        public string Author { get; set; } = null!;
        public List<Student> Students { get; set; } = null!;
        public List<ActiveStudies> ActiveStudies { get; set; } = null!;
    }
}
