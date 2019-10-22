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

            // read app data to get the path of the drawing config file to read
            var appDataPath = @"C:\Users\bolinger\Documents\SolidWorks Projects\Prefab Blob - Cover Blob\app data\rebuild.txt";
            var appDataLines = System.IO.File.ReadAllLines(appDataPath);
            var configPath = appDataLines[0];
            var configLines = System.IO.File.ReadAllLines(configPath);
            
            // read from config - assume "\"Drawing View <#> Scale\"= #:#"
            // get value
        }

        private static void displayLines(string[] lines)
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
