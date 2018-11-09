using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcOrange.Mould.Public
{
    public interface IMouldable<T> where T : struct, IComparable
    {
        T Value { get; set; }
    }
}
