using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics13
{
    public interface IVoronoiCell
    {
        IPoint[] Points { get; }
        int Index { get; }
    }
}
