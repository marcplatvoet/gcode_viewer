using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcode_viewer
{
    public class Segment
    {
        public Segment()
        {
            CuttingPoints = new List<CuttingPoint>();
        }
        public string From
        { get; set; }

        public string To
        { get; set; }


        public void deleteDoubleCuttingPoints()
        {
            for (int i = 0; i < CuttingPoints.Count; i++)
            {
                for (int n = 0; n < CuttingPoints.Count; n++)
                {
                    if (i != n)
                    {
                        if (CuttingPoints[i].equal(CuttingPoints[n]))
                        {
                            CuttingPoints.RemoveAt(i);
                            i = 0;
                        }
                    }
                }
            }
        }

        public void AddCuttingPoints(int Amount)
        {


            int Differerance = Amount - CuttingPoints.Count;
            int steps = (int)(CuttingPoints.Count / Differerance) + 1;


            for (int i = 0; i < Amount; i = i + steps)
            {
                double newX = 0;
                double newY = 0;
                double addX = (CuttingPoints[i].X - CuttingPoints[i + 1].X) / 2;
                double addY = (CuttingPoints[i].Y - CuttingPoints[i + 1].Y) / 2;
                if (CuttingPoints[i].X < CuttingPoints[i + 1].X && addX > 0)
                {
                    newX = CuttingPoints[i].X + addX;
                }
                else
                {
                    newX = CuttingPoints[i + 1].X + addX;
                }
                if (CuttingPoints[i].Y < CuttingPoints[i + 1].Y && addY > 0)
                {
                    newY = CuttingPoints[i].Y + addY;
                }
                else
                {
                    newY = CuttingPoints[i + 1].Y + addY;
                }
                CuttingPoint cuttingPoint = new CuttingPoint("cuttingpoint", newX, newY);
                CuttingPoints.Insert(i, cuttingPoint);

                if (CuttingPoints.Count == Amount)
                    break;

            }



        }

        public List<CuttingPoint> CuttingPoints;
        
    }
}
