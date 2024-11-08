using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace App.lib.utils
{
    public class LoadCoordinates
    {
        public static List<Point> Get( string fileName = "coordinates.txt")
        {
            List<Point> points = new List<Point>();

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(currentDirectory, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] list = line.Split(',');

                            float x = float.Parse( list[0].Trim() );
                            float y = float.Parse( list[1].Trim() );
                            float z = float.Parse( list[2].Trim() );

                            Point point = new Point(x , y , z, Color.Red);
                            points.Add(point);
                            
                        }
                    }
                    //Console.WriteLine("Coordinates copied!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            } else
            {
                Console.WriteLine("Fisierul nu exista !");
            }

            return points;
        }
    }
}
