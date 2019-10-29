using SldWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingViewScale
{
    class Program
    {
        static void Main(string[] args)
        {
            var swInstance = new SldWorks.SldWorks();
            var model = (ModelDoc2)swInstance.ActiveDoc;
            var drawing = (DrawingDoc)swInstance.ActiveDoc;

            // read app data to get the path of the drawing config file to read
            var appDataPath = @"C:\Users\bolinger\Documents\SolidWorks Projects\Prefab Blob - Cover Blob\app data\rebuild.txt";
            var appDataLines = System.IO.File.ReadAllLines(appDataPath);

            // references: "C:\Users\bolinger\Documents\SolidWorks Projects\Prefab Blob - Cover Blob\base blob - L1\blob.coverDrawing.txt"
            var configPath = appDataLines[0];
            var configLines = System.IO.File.ReadAllLines(configPath);

            // get requested drawing view scale value from config
            var drawingView1ScaleString = configLines[0].Split('=')[1].Trim();
            var drawingView1ScaleArray = new double[2];
            drawingView1ScaleArray[0] = Double.Parse(drawingView1ScaleString.ToCharArray()[0] + "");
            drawingView1ScaleArray[1] = Double.Parse(drawingView1ScaleString.ToCharArray()[2] + "");
            var drawingView1Scale = drawingView1ScaleArray[0] / drawingView1ScaleArray[1];

            // get drawing active view sheet
            var activeView = (View)drawing.GetFirstView();

            // get first drawing view
            activeView = (View)activeView.GetNextView();

            // set View::ScaleRatio value
            activeView.ScaleDecimal = drawingView1Scale;

            // get reference to Drawing View2
            activeView = (View)activeView.GetNextView();
            // set if not null
            if (activeView != null)
            {
                activeView.ScaleDecimal = drawingView1Scale;
            }

            // rebuild to reflect changes
            model.EditRebuild3();
        }
        private static void displayLines(bool line)
        {
            Console.WriteLine(line);
        }
        private static void displayLines(string[] lines)
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        private static void displayLines(string line)
        {
            Console.WriteLine(line);
        }
        private static void displayLines(int line)
        {
            Console.WriteLine(line);
        }
        private static void displayLines(double line)
        {
            Console.WriteLine(line);
        }
        private static void displayLines(double[] lines)
        {
            foreach (double number in lines)
            {
                Console.WriteLine(number);
            }
        }
    }
}
