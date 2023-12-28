using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie2
{
    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if(x is null && y is null) return true;
            if (x is null || y is null) return false;

            return x.IndexNumber == y.IndexNumber
                && x.Fname == y.Fname
                && x.Lname == y.Lname;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.IndexNumber.GetHashCode();
        }
    }
}
