using SimpleDXF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcode_viewer
{
    public class Vector
    {
        public Vector()
        {
            cuttingPoints = new List<CuttingPoint>();
            PrevLine = null;
            line = null;
            done = false;
        }

        public string Name
        { get; set; }

        public Line PrevLine
        { get; set; }

        public Line line
        { get; set; }

        public double length
        {
            get { return Math.Sqrt(Math.Pow((line.P1.Y - line.P2.Y), 2) + Math.Pow((line.P1.X - line.P2.X), 2)); }
        }

        public double angle
        {
            get
            {
                //
                // calculate the angle between the line from p1 to p2
                // and the line from p3 to p4
                //
                // uses the theorem :
                //
                // given directional vectors v = ai + bj and w = ci + di
                //
                // then cos(angle) = (ac + bd) / ( |v| * |w| )
                //

                double cos_angle, angle;
                angle = 0;

                //same points
                if (PrevLine != null)
                {

                    //bool dir_x1 = false;
                    //bool dir_x2 = false;
                    //double LX1 = (float)line.P1.X;
                    //double LY1 = (float)line.P1.Y;
                    //double LX2 = (float)line.P2.X;
                    //double LY2 = (float)line.P2.Y;
                    //double PX1 = (float)PrevLine.P1.X;
                    //double PY1 = (float)PrevLine.P1.Y;
                    //double PX2 = (float)PrevLine.P2.X;
                    //double PY2 = (float)PrevLine.P2.Y;
                    //if (LX1 == PX2 && LY1 == PY2)
                    //{
                    //    dir_x1 = true;
                    //}
                    //if (LX2 == PX1 && LY2 == PY1)
                    //{
                    //    dir_x2 = true;
                    //}

                    double X1 = (float)line.P1.X - line.P2.X;
                    double Y1 = (float)line.P1.Y - line.P2.Y;
                    double X2 = (float)PrevLine.P1.X - PrevLine.P2.X;
                    double Y2 = (float)PrevLine.P1.Y - PrevLine.P2.Y;
                    //

                    double mag_v1 = Math.Sqrt(X1 * X1 + Y1 * Y1);
                    double mag_v2 = Math.Sqrt(X2 * X2 + Y2 * Y2);
                    //
                    cos_angle = (X1 * X2 + Y1 * Y2) / (mag_v1 * mag_v2);
                    angle = Math.Acos(cos_angle);
                    angle = angle * 180.0 / 3.14159; // convert to degrees ???
                }
                return angle;
            }
        }

        public double dX
        {
            get
            {
                if (line.P1.X > line.P2.X)
                {
                    return line.P2.X - line.P1.X;
                }
                else
                {
                    return line.P1.X - line.P2.X;
                }

            }
        }
        public double dY
        {
            get
            {
                if (line.P1.Y > line.P2.Y)
                {
                    return line.P2.Y - line.P1.Y;
                }
                else
                {
                    return line.P1.Y - line.P2.Y;
                }
            }
        }

        //public bool compareX(Line nextVector)
        //{
        //    if (nextVector.P1.X == line.P1.X && nextVector.P1.Y == line.P1.Y)
        //    {
        //        return true;
        //    }
        //    if (nextVector.P2.X == line.P2.X && nextVector.P2.Y == line.P2.Y)
        //    {
        //        return true;
        //    }
        //    if (nextVector.P1.X == line.P2.X && nextVector.P1.Y == line.P2.Y)
        //    {
        //        return true;
        //    }
        //    if (nextVector.P2.X == line.P1.X && nextVector.P2.Y == line.P1.Y)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public void makePoints(int nrOfPoints)
        {
            cuttingPoints = new List<CuttingPoint>();
            double calcXPoint = line.P1.X;
            double calcYPoint = line.P1.Y;

            double deltaX = dX / nrOfPoints;
            double deltaY = dY / nrOfPoints;
            for (int i = 0; i < nrOfPoints; i++)
            {
                if (line.P1.X < line.P2.X)
                {
                    calcXPoint -= deltaX;
                }
                else
                {
                    calcXPoint += deltaX;
                }
                if (line.P1.Y < line.P2.Y)
                {
                    calcYPoint -= deltaY;
                }
                else
                {
                    calcYPoint += deltaY;
                }
                CuttingPoint cp = new CuttingPoint();
                cp.X = calcXPoint;
                cp.Y = calcYPoint;
                cp.Name = "cuttingpoint";
                cuttingPoints.Add(cp);
            }


            if (nrOfPoints == 0)
                return;

        }

        public List<CuttingPoint> cuttingPoints;

        public bool done
        { get; set; }
    }
}
