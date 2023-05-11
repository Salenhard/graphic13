﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics13.Models
{
    public struct VoronoiCell : IVoronoiCell
    {
        public IPoint[] Points { get; set; }
        public int Index { get; set; }
        public VoronoiCell(int triangleIndex, IPoint[] points)
        {
            Points = points;
            Index = triangleIndex;
        }
    }
}
