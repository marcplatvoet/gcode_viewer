using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleDXF;


namespace gcode_viewer
{
    public partial class DXF_to_Gcode : Form
    {



        private List<Gcode> gCodeList;
        private Document DXF_Document;
        private Shape shape_AX1;
        private Shape shape_AX2;
        private Pen Black = new Pen(Color.Black);
        private Pen Red = new Pen(Color.Red);
        private Brush RedBrush = new SolidBrush(Color.Red);
        private Brush BlueBrush = new SolidBrush(Color.Blue);
        private Bitmap bmp;
        private Graphics g;
      
        public DXF_to_Gcode()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox_AX1.Width, pictureBox_AX1.Height);
            g = Graphics.FromImage(bmp);
        }

        private Bitmap DrawDXF(Shape shape)
        {

            bmp = new Bitmap(pictureBox_AX1.Width, pictureBox_AX1.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
 
            foreach (Vector v in shape.vectors)
            {
                // Draw line:

                float x1 = (float)(v.line.P1.X - shape.lowhigh.X_low);
                float y1 = (float)(v.line.P1.Y - shape.lowhigh.Y_low);
                float x2 = (float)(v.line.P2.X - shape.lowhigh.X_low);
                float y2 = (float)(v.line.P2.Y - shape.lowhigh.Y_low);

                if (chkFlipX.Checked)
                {
                    x1 = (float)(v.line.P1.X - shape.lowhigh.X_high);
                    x2 = (float)(v.line.P2.X - shape.lowhigh.X_high);

                    x1 = -x1;
                    x2 = -x2;
                }
                if (chkFlipY.Checked)
                {
                    y1 = (float)(v.line.P1.Y - shape.lowhigh.Y_high);
                    y2 = (float)(v.line.P2.Y - shape.lowhigh.Y_high);
                    y1 = -y1;
                    y2 = -y2;
                }

                g.DrawLine(Black, x1, y1, x2, y2);
            }

            foreach (SpecialPoint sp in shape.SpecialPoints)
            {

                float x = (float)(sp.X - shape.lowhigh.X_low);
                float y = (float)(sp.Y - shape.lowhigh.Y_low);

                if (chkFlipX.Checked)
                {
                    x = (float)(sp.X - shape.lowhigh.X_high);
                    x = -x;
                }
                if (chkFlipY.Checked)
                {
                    y = (float)(sp.Y - shape.lowhigh.Y_high);
                    y = -y;
                }


                if (sp.Name == "Angle")
                {
                    g.FillRectangle(BlueBrush, x, y, 6, 6);
                }
                else
                {
                    g.FillRectangle(RedBrush, x, y, 4, 4);
                }
            }
            return bmp;
        }

        private void ParchContent(string gCodeContent)
        {
            foreach (string line in gCodeContent.Split('\n'))
            {
                if (line.Trim().Length > 0)
                {
                    string sline = line.Replace("\r", "");
                    string[] items = sline.Split(' ');
                    Gcode item = new Gcode();
                    switch (items.Length)
                    {
                        case 1:
                            item.Command = items[0];
                            gCodeList.Add(item);
                            break;
                        case 11:
                            item.Command = items[0];
                            item.X = items[1];
                            item.Y = items[3];
                            item.Z = items[7];
                            item.U = items[5];
                            item.Speed = items[9];
                            gCodeList.Add(item);
                            break;
                    }

                    Console.WriteLine(line);
                }
            }
        }

        private void chkFlipX_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox_AX1.Image = DrawDXF(shape_AX1);
        }

        private void chkFlipY_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox_AX1.Image = DrawDXF(shape_AX1);
        }

        private void btnOpenFile_AX1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Text files (*.dxf)|*.dxf|All files (*.*)|*.*";
                openFileDialog1.Title = "open a dxf file  ";
                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtFilename_AX1.Text = openFileDialog1.FileName;

                    //Loads a file from the command line argument
                    DXF_Document = new Document(openFileDialog1.FileName);

                    //Parse the file
                    DXF_Document.Read();

                    shape_AX1 = new Shape();
                    Line PrevLine = null;
                    for (int i = 0; i < DXF_Document.Lines.Count; i++)
                    {
                        Vector vector = new Vector();
                        Line line = DXF_Document.Lines[i];
                        vector.line = line;
                        if (i > 0)
                        {
                            vector.PrevLine = PrevLine;
                        }
                        shape_AX1.vectors.Add(vector);
                        PrevLine = line;
                    }

                    shape_AX1.SortVectors();
                    shape_AX1.getHighLowPoints();
                    shape_AX1.FillSpecialPoints();
                    shape_AX1.ResetToZero();
                    pictureBox_AX1.Image = DrawDXF(shape_AX1);
                }
            }catch(Exception oE)
            {
                MessageBox.Show(oE.Message);
            }
        }

        private void btnOpenFile_AX2_Click(object sender, EventArgs e)
        {
            try
            { 
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.dxf)|*.dxf|All files (*.*)|*.*";
            openFileDialog1.Title = "open a dxf file  ";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilename_AX2.Text = openFileDialog1.FileName;

                //Loads a file from the command line argument
                DXF_Document = new Document(openFileDialog1.FileName);

                //Parse the file
                DXF_Document.Read();

                shape_AX2 = new Shape();
                Line PrevLine = null;
                for (int i = 0; i < DXF_Document.Lines.Count; i++)
                {
                    Vector vector = new Vector();
                    Line line = DXF_Document.Lines[i];
                    vector.line = line;
                    if (i > 0)
                    {
                        vector.PrevLine = PrevLine;
                    }
                    shape_AX2.vectors.Add(vector);
                    PrevLine = line;
                }

                shape_AX2.SortVectors();
                shape_AX2.getHighLowPoints();
                shape_AX2.FillSpecialPoints();
                shape_AX2.ResetToZero();
                pictureBox_AX2.Image = DrawDXF(shape_AX2);
            }
            }
            catch (Exception oE)
            {
                MessageBox.Show(oE.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateCuttingPoints();
        }

        private void CreateCuttingPoints()
        {
            try
            {
                bool doneAll = false;
                int totalPoint = int.Parse(txtPoints.Text);
                //check is there Special points are the same!
                if (shape_AX1.SpecialPoints.Count() != shape_AX2.SpecialPoints.Count())
                {
                    throw new Exception("The special points are not the same!");
                }

                shape_AX1.OrderSpecialPoints();
                shape_AX2.OrderSpecialPoints();
                shape_AX1.CreateCuttingPoints(totalPoint);
                shape_AX2.CreateCuttingPoints(totalPoint);

                int count = 0;
                foreach(Vector v in shape_AX1.vectors)
                {
                    count += v.cuttingPoints.Count;
                }

                Console.WriteLine("count AX1: " + count);
                count = 0;
                foreach (Vector v in shape_AX2.vectors)
                {
                    count += v.cuttingPoints.Count;
                }

                Console.WriteLine("count AX2: " + count);


                //Analyse and correct cutting points

                shape_AX1.createSegments();
                foreach(Segment s in shape_AX1.Segments)
                {
                    Console.WriteLine("shape_AX1 From: " + s.From + " To: " + s.To + " count: " + s.CuttingPoints.Count);
                }
                shape_AX2.createSegments();
                foreach (Segment s in shape_AX2.Segments)
                {
                    Console.WriteLine("shape_AX2 From: " + s.From + " To: " + s.To + " count: " + s.CuttingPoints.Count);
                }

                shape_AX1.DeleteDoubleCuttingPointsInSegments();
                shape_AX2.DeleteDoubleCuttingPointsInSegments();
                foreach (Segment s in shape_AX1.Segments)
                {
                    Segment CompaireSegment = shape_AX2.GetSegment(s.From,s.To);
                    if (s.CuttingPoints.Count != CompaireSegment.CuttingPoints.Count)
                    {
                        if (s.CuttingPoints.Count > CompaireSegment.CuttingPoints.Count)
                        {
                            CompaireSegment.AddCuttingPoints(s.CuttingPoints.Count);
                            Console.WriteLine(s.CuttingPoints.Count + " " + CompaireSegment.CuttingPoints.Count);
                        }
                        else
                        {
                            s.AddCuttingPoints(CompaireSegment.CuttingPoints.Count);
                            Console.WriteLine(s.CuttingPoints.Count + " " + CompaireSegment.CuttingPoints.Count);
                        }
                    }
                }


                shape_AX1.MoveSegmentsToCuttingPoints();
                shape_AX2.MoveSegmentsToCuttingPoints();


                //Analyse and correct cutting points
                Console.WriteLine();

            }
            catch (Exception ex)
            {

                string title = "Error";
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBoxSimulate.Width, pictureBoxSimulate.Height);
            g = Graphics.FromImage(bmp);
            
            g.Clear(Color.White);
            int totalPoints;
            if (shape_AX1.CuttingPoints.Count > shape_AX2.CuttingPoints.Count)
            {
                totalPoints = shape_AX2.CuttingPoints.Count;
            } else
            {
                totalPoints = shape_AX1.CuttingPoints.Count;
            }

            for (int i = 0; i < totalPoints; i++)
            {
                CuttingPoint cp_AX1 = shape_AX1.CuttingPoints[i];

                float x1 = (float)(cp_AX1.X - shape_AX1.lowhigh.X_low);
                float y1 = (float)(cp_AX1.Y - shape_AX1.lowhigh.Y_low);

                if (chkFlipX.Checked)
                {
                    x1 = (float)(cp_AX1.X - shape_AX1.lowhigh.X_high);
                    x1 = -x1;
                }
                if (chkFlipY.Checked)
                {
                    y1 = (float)(cp_AX1.Y - shape_AX1.lowhigh.Y_high);
                    y1 = -y1;
                }

                g.FillRectangle(RedBrush, x1, y1 + 50, 1, 1);

                CuttingPoint cp_AX2 = shape_AX2.CuttingPoints[i];

                float x2 = (float)(cp_AX2.X - shape_AX2.lowhigh.X_low);
                float y2 = (float)(cp_AX2.Y - shape_AX2.lowhigh.Y_low);

                if (chkFlipX.Checked)
                {
                    x2 = (float)(cp_AX2.X - shape_AX2.lowhigh.X_high);
                    x2 = -x2;
                }
                if (chkFlipY.Checked)
                {
                    y2 = (float)(cp_AX2.Y - shape_AX2.lowhigh.Y_high);
                    y2 = -y2;
                }

                g.FillRectangle(RedBrush, x2, y2 + 200, 1, 1);

                pictureBoxSimulate.Image = bmp;
                Application.DoEvents();
                Thread.Sleep(10);
            }
           

        }





        class Gcode
        {
            public Gcode()
            {

            }
            public Gcode(string command,string x,string y,string z, string u, string speed)
            {
                Command = command;
                X = x;
                Y = y;
                Z = z;
                U = u;
                Speed = speed;
            }
            public string Command
            { get; set; }
            public string X
            { get; set; }
            public string Y
            { get; set; }
            public string Z
            { get; set; }
            public string U
            { get; set; }
            public string Speed
            { get; set; }
        }


        private string roundg(double value)
        {
            return Math.Round(value, 3).ToString();
        }

        private void btnGcode_Click(object sender, EventArgs e)
        {
            gCodeList = new List<Gcode>();
            Gcode gcode = new Gcode("G90","","","","","");
            gCodeList.Add(gcode);
            gcode = new Gcode("M3", "", "", "", "", "");
            gCodeList.Add(gcode);
            if (shape_AX1.CuttingPoints.Count == shape_AX2.CuttingPoints.Count) { 
                for(int i = 0; i < shape_AX1.CuttingPoints.Count; i++)
                {
                    CuttingPoint CP1 = shape_AX1.CuttingPoints[i];
                    CuttingPoint CP2 = shape_AX2.CuttingPoints[i];
                    gcode = new Gcode("G1", roundg(CP1.X), roundg(CP1.Y), roundg(CP2.X), roundg(CP2.Y), txtCuttingSpeed.Text);
                    gCodeList.Add(gcode);
                }
            } else {
                throw new Exception("The cutting points are not the same!");
            }

            gcode = new Gcode("M5", "", "", "", "", "");
            gCodeList.Add(gcode);

        }
    }
}