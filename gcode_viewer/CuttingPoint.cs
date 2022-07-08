using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcode_viewer
{
    public class CuttingPoint
    {
        public CuttingPoint()
        {

        }
        public CuttingPoint(string name, double x, double y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public string Name
        { get; set; }

        public double X
        { get; set; }

        public double Y
        { get; set; }

        public bool equal(CuttingPoint cpCompair)
        {
            if (cpCompair.Name == "cuttingpoint" && cpCompair.X == X && cpCompair.Y == Y)
            {
                return true;
            }
            return false;
        }
    }
}

