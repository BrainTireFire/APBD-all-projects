using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenie2
{
    public class StudiesComparer :IEqualityComparer<Studies>
    {
        public bool Equals(Studies? x, Studies? y)
        {
            if(x is null && y is null) return true;
            if (x is null || y is null) return false;

            return x.Name == y.Name
                && x.Mode == y.Mode;
        }

        public int GetHashCode([DisallowNull] Studies obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}