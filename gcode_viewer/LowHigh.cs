using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcode_viewer
{
    public class LowHigh
    {
        public LowHigh()
        {
            X_low = double.MaxValue;
            Y_low = double.MaxValue;
            X_high = double.MinValue;
            Y_high = double.MinValue;
        }

        public double X_low
        { get; set; }

        public double X_high
        { get; set; }

        public double Y_low
        { get; set; }

        public double Y_high
        { get; set; }
    }
}
