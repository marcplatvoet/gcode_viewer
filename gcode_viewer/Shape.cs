using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcode_viewer
{
    public class Shape
    {
        private double lenght = 0;

        public Shape()
        {
            Segments = new List<Segment>();
            vectors = new List<Vector>();
            SpecialPoints = new List<SpecialPoint>();
            lowhigh = new LowHigh();
            CuttingPoints = new List<CuttingPoint>();
        }

        public LowHigh lowhigh
        { get; set; }

        public List<Vector> vectors
        { get; set; }

        public List<Segment> Segments
        { get; set; }

        public List<SpecialPoint> SpecialPoints
        { get; set; }

        public List<CuttingPoint> CuttingPoints;
        public double length
        {
            get
            {
                lenght = 0;
                foreach (Vector v in vectors)
                {
                    lenght = lenght + v.length;
                }

                return lenght;
            }
            //set
            //{
            //    length = 0;
            //}
        }

        public void MoveSegmentsToCuttingPoints()
        {
            CuttingPoints = new List<CuttingPoint>();
            foreach (Segment segment in Segments)
            {
                foreach (CuttingPoint cuttingPoint in segment.CuttingPoints)
                {
                    CuttingPoints.Add(cuttingPoint);
                }
            }
        }

        public Segment GetSegment(string From, string To)
        {
            foreach (Segment s in Segments)
            {
                if (s.From == From && s.To == To)
                    return s;
            }
            return null;
        }

        public void DeleteDoubleCuttingPointsInSegments()
        {
            for (int i = 0; i < Segments.Count; i++)
            {
                Segment s = Segments[i];
                s.deleteDoubleCuttingPoints();
            }
        }

        public void createSegments()
        {
            Segments = new List<Segment>();
            for (int i = 0; i < CuttingPoints.Count; i++)
            {
                CuttingPoint cuttingPoint = CuttingPoints[i];
                if (cuttingPoint.Name != "cuttingpoint")
                {
                    if (Segments.Count > 0)
                    {
                        Segments[Segments.Count - 1].To = cuttingPoint.Name;
                    }

                    Segment segment = new Segment();
                    segment.From = cuttingPoint.Name;
                    Segments.Add(segment);
                }
                if (Segments.Count > 0)
                {
                    Segments[Segments.Count - 1].CuttingPoints.Add(cuttingPoint);
                }
            }

            for (int i = 0; i < CuttingPoints.Count; i++)
            {
                CuttingPoint cuttingPoint = CuttingPoints[i];
                if (cuttingPoint.Name != "cuttingpoint")
                {
                    if (Segments.Count > 0)
                    {
                        Segments[Segments.Count - 1].To = cuttingPoint.Name;
                    }
                    break;
                }
                Segments[Segments.Count - 1].CuttingPoints.Add(cuttingPoint);
            }

        }

        public void ResetToZero()
        {
            double RootX = 0;
            double RootY = 0;
            foreach (SpecialPoint sp in SpecialPoints)
            {
                if (sp.Name == "Xlow")
                {
                    RootX = sp.X;
                    RootY = sp.Y;
                }
            }

            lowhigh.X_high = lowhigh.X_high - RootX;
            lowhigh.Y_high = lowhigh.Y_high - RootY;
            lowhigh.X_low = lowhigh.X_low - RootX;
            lowhigh.Y_low = lowhigh.Y_low - RootY;

            for (int i = 0; i < SpecialPoints.Count; i++)
            {
                SpecialPoint sp = SpecialPoints[i];
                sp.X = sp.X - RootX;
                sp.Y = sp.Y - RootY;
            }


            for (int i = 0; i < vectors.Count; i++)
            {
                vectors[i].line.P1.X = vectors[i].line.P1.X - RootX;
                vectors[i].line.P1.Y = vectors[i].line.P1.Y - RootY;
                vectors[i].line.P2.X = vectors[i].line.P2.X - RootX;
                vectors[i].line.P2.Y = vectors[i].line.P2.Y - RootY;
            }
        }

        public void OrderSpecialPoints()
        {
            int order = 0;
            foreach (Vector vector in vectors)
            {
                foreach (SpecialPoint sp in SpecialPoints)
                {
                    if (sp.equal(vector) && sp.Order == 0)
                    {
                        sp.Order = order;
                        order++;
                    }
                }
            }
        }

        public int FindVector(string SPName)
        {
            for (int s = 0; s < SpecialPoints.Count; s++)
            {
                if (SpecialPoints[s].Name == SPName)
                {
                    for (int v = 0; v < vectors.Count; v++)
                    {
                        if (Math.Round(vectors[v].line.P1.X, 4) == Math.Round(SpecialPoints[s].X, 4) && Math.Round(vectors[v].line.P1.Y, 4) == Math.Round(SpecialPoints[s].Y, 4))
                        {
                            return v;
                        }
                    }
                }
            }
            return -1;
        }

        public void CreateCuttingPoints(int totalPoint)
        {
            CuttingPoints = new List<CuttingPoint>();
            bool doneAll = false;
            resetVectorDone();
            double distance = length / totalPoint;

            int currentVector = FindVector("Xhigh");
            while (doneAll != true)
            {
                Vector vector = vectors[currentVector];

                double dpoints = Math.Round(vector.length / distance, 0);
                int DeltaPoints = (int)dpoints;
                vector.makePoints(DeltaPoints);

                CuttingPoint cuttingPointBegin = new CuttingPoint(vector.Name, vector.line.P1.X, vector.line.P1.Y);
                CuttingPoints.Add(cuttingPointBegin);

                foreach (CuttingPoint cuttingPoint in vector.cuttingPoints)
                {
                    CuttingPoints.Add(cuttingPoint);
                }

                CuttingPoint cuttingPointEnd = new CuttingPoint("cuttingpoint", vector.line.P2.X, vector.line.P2.Y);
                CuttingPoints.Add(cuttingPointEnd);


                vectors[currentVector].done = true;
                currentVector++;

                if (currentVector > vectors.Count - 1)
                {
                    currentVector = 0;
                }
                if (vectors[currentVector].done)
                {
                    doneAll = true;
                }


            }
            //foreach (CuttingPoint cuttingPoint in CuttingPoints)
            //{
            //    Console.WriteLine("Name: " + cuttingPoint.Name + " X: " + cuttingPoint.X + " Y: " + cuttingPoint.Y);
            //}
            //Console.WriteLine();
        }

        public void getHighLowPoints()
        {
            SpecialPoint LowPointX = new SpecialPoint();
            LowPointX.Name = "Xlow";
            SpecialPoint HighPointX = new SpecialPoint();
            HighPointX.Name = "Xhigh";
            SpecialPoint LowPointY = new SpecialPoint();
            LowPointY.Name = "Ylow";
            SpecialPoint HighPointY = new SpecialPoint();
            HighPointY.Name = "Yhigh";
            //SpecialPoint MiddlePoint = new SpecialPoint();
            //HighPointY.Name = "MiddlePoint";


            foreach (Vector v in vectors)
            {
                if (lowhigh.X_high < v.line.P1.X)
                {
                    lowhigh.X_high = v.line.P1.X;
                    HighPointX.X = v.line.P1.X;
                    HighPointX.Y = v.line.P1.Y;
                }
                if (lowhigh.X_high < v.line.P2.X)
                {
                    lowhigh.X_high = v.line.P2.X;
                    HighPointX.X = v.line.P2.X;
                    HighPointX.Y = v.line.P2.Y;

                }

                if (lowhigh.X_low > v.line.P1.X)
                {
                    lowhigh.X_low = v.line.P1.X;
                    LowPointX.X = v.line.P1.X;
                    LowPointX.Y = v.line.P1.Y;
                }
                if (lowhigh.X_low > v.line.P2.X)
                {
                    lowhigh.X_low = v.line.P2.X;
                    LowPointX.X = v.line.P2.X;
                    LowPointX.Y = v.line.P2.Y;

                }


                if (lowhigh.Y_high < v.line.P1.Y)
                {
                    lowhigh.Y_high = v.line.P1.Y;
                    HighPointY.X = v.line.P1.X;
                    HighPointY.Y = v.line.P1.Y;
                }
                if (lowhigh.Y_high < v.line.P2.Y)
                {
                    lowhigh.Y_high = v.line.P2.Y;
                    HighPointY.X = v.line.P2.X;
                    HighPointY.Y = v.line.P2.Y;

                }
                if (lowhigh.Y_low > v.line.P1.Y)
                {
                    lowhigh.Y_low = v.line.P1.Y;
                    LowPointY.X = v.line.P1.X;
                    LowPointY.Y = v.line.P1.Y;
                }
                if (lowhigh.Y_low > v.line.P2.Y)
                {
                    lowhigh.Y_low = v.line.P2.Y;
                    LowPointY.X = v.line.P2.X;
                    LowPointY.Y = v.line.P2.Y;
                }
            }

            //MiddlePoint.Y = (lowhigh.Y_high - lowhigh.Y_low) / 2;
            //MiddlePoint.X = (lowhigh.X_high - lowhigh.X_low) / 2; 
            //SpecialPoints.Add(MiddlePoint);
            SpecialPoints.Add(LowPointX);
            SpecialPoints.Add(HighPointX);
            SpecialPoints.Add(LowPointY);
            SpecialPoints.Add(HighPointY);
        }

        public void FillSpecialPoints()
        {

            //Get extra special points of the object
            int angleCount = 0;
            vectors[0].PrevLine = vectors[vectors.Count - 1].line;
            for (int i = 0; i < vectors.Count; i++)
            {
                if (vectors[i].angle > 30)
                {
                    bool newPoint = true;
                    SpecialPoint sp = new SpecialPoint();
                    sp.Name = "Angle" + angleCount.ToString();
                    angleCount++;
                    sp.X = vectors[i].line.P1.X;
                    sp.Y = vectors[i].line.P1.Y;
                    foreach (SpecialPoint specialPoints in SpecialPoints)
                    {
                        double X1 = Math.Round(specialPoints.X, 4);
                        double X2 = Math.Round(sp.X, 4);
                        double Y1 = Math.Round(specialPoints.Y, 4);
                        double Y2 = Math.Round(sp.Y, 4);

                        if (X1 == X2 && Y1 == Y2)
                        {
                            angleCount--;
                            newPoint = false;
                        }
                    }
                    if (newPoint)
                    {
                        SpecialPoints.Add(sp);
                    }
                }
                //Get extra special points of the object
            }
            for (int i = 0; i < vectors.Count; i++)
            {
                Vector vector = vectors[i];
                vector.Name = "";
                foreach (SpecialPoint specialPoint in SpecialPoints)
                {

                    if (vector.line.P1.X == specialPoint.X && vector.line.P1.Y == specialPoint.Y)
                    {
                        vector.Name = specialPoint.Name;
                    }
                    else
                    {
                        if (vector.Name == "")
                        {
                            vector.Name = "cuttingpoint";
                        }
                    }
                }
            }

            //for (int i = 0; i < vectors.Count; i++)
            //{
            //    Console.WriteLine("X1: " + vectors[i].line.P1.X + " Y1: " + vectors[i].line.P1.Y + "X2: " + vectors[i].line.P2.X + " Y2: " + vectors[i].line.P2.Y + " Angle: " + vectors[i].angle + " Name: " + vectors[i].Name);
            //}
            //Console.ReadLine();
        }

        public void SortVectors()
        {

            for (int i = 0; i < vectors.Count; i++)
            {
                Vector vector = vectors[i];
                Console.WriteLine("X1: " + vector.line.P1.X + " Y1: " + vector.line.P1.Y + " X2: " + vector.line.P2.X + " Y2: " + vector.line.P2.Y + " Angle: " + vector.angle);
            }


            List<Vector> vectorsList = new List<Vector>();

            int next = 0;
            Vector tempvector = null;
            while (vectorsList.Count <= vectors.Count)
            {
                tempvector = vectors[next];
                vectors[next].done = true;
                vectorsList.Add(tempvector);
                next = FindNextVector(tempvector);
                if (vectorsList.Count == vectors.Count)
                {
                    break;
                }
                Console.WriteLine("Next: " + next + "X1: " + tempvector.line.P1.X + " Y1: " + tempvector.line.P1.Y + "X2: " + tempvector.line.P2.X + " Y2: " + tempvector.line.P2.Y + " Angle: " + tempvector.angle);
                if (next == -1)
                {
                    throw new Exception("There is no next point from this point, the object imported is not complete!");
                }
            }
            Vector v = vectors[0];

            double X1 = Math.Round(v.line.P1.X, 4);
            double X2 = Math.Round(tempvector.line.P2.X, 4);
            double Y1 = Math.Round(v.line.P1.Y, 4);
            double Y2 = Math.Round(tempvector.line.P2.Y, 4);

            if (X1 == X2 && Y1 == Y2)
            {
                Console.WriteLine("done");
            }
            else
            {
                throw new Exception("The last peace of the line is not interconnecting!");
            }

            for (int i = 1; i < vectorsList.Count; i++)
            {
                vectorsList[i].PrevLine = vectorsList[i - 1].line;
            }
            vectorsList[0].PrevLine = vectorsList[vectorsList.Count - 1].line;

            vectors = new List<Vector>(); //Empty vector list
            foreach (Vector sorted in vectorsList)
            {
                vectors.Add(sorted); //Add sorted vectors
            }
            Console.WriteLine("Sorted");

        }

        private int FindNextVector(Vector vector)
        {
            for (int i = 0; i < vectors.Count; ++i)
            {
                Vector v = vectors[i];

                double X1 = Math.Round(v.line.P1.X, 4);
                double X2 = Math.Round(vector.line.P2.X, 4);
                double Y1 = Math.Round(v.line.P1.Y, 4);
                double Y2 = Math.Round(vector.line.P2.Y, 4);

                if (X1 == X2 && Y1 == Y2 && !v.done)
                {
                    return i;
                }
            }
            return -1;
        }

        public void resetVectorDone()
        {
            foreach (Vector vector in vectors)
            {
                vector.done = false;
            }
        }
    }
 }

