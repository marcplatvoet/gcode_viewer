using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcode_viewer
{
    public class SpecialPoint
    {      
        public string Name
        { get; set; }

        public double X
        { get; set; }

        public double Y
        { get; set; }

        public int Order
        { get; set; }

        public bool equal(Vector vector)
        {
            if (vector.line.P1.X == X && vector.line.P1.Y == Y || vector.line.P2.X == X && vector.line.P2.Y == Y)
            {
                return true;
            }

            return false;
        }

        public bool Done
        { get; set; }
    }
}

