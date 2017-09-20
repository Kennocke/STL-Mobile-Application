using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            double[] normal = new double[3];
            double[] vertex1 = new double[3];
            double[] vertex2 = new double[3];
            double[] vertex3 = new double[3];
            ushort count;
            double sum = 0;
            byte[] header = new byte[80];
            
            using (BinaryReader reader = new BinaryReader(File.Open("file.stl", FileMode.Open)))
            {
                FileStream file1 = new FileStream("test.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(file1);
                reader.BaseStream.Seek(84,SeekOrigin.Begin);
                //number = reader.ReadUInt32();
                while(reader.BaseStream.Position != reader.BaseStream.Length)
                {
                        for (int i = 0; i < 3; i++) normal[i] = reader.ReadSingle() * 10;
                        for (int i = 0; i < 3; i++) vertex1[i] = reader.ReadSingle() * 0.01;
                        for (int i = 0; i < 3; i++) vertex2[i] = reader.ReadSingle() * 0.01;
                        for (int i = 0; i < 3; i++) vertex3[i] = reader.ReadSingle() * 0.01;
                        count = reader.ReadUInt16();
                        sum =+ ((-1) * vertex3[0] * vertex2[1] * vertex1[2] + vertex2[0] * vertex3[1] * vertex1[2] + vertex3[0] * vertex1[1] * vertex2[2] - vertex1[0] * vertex3[1] * vertex2[2] - vertex2[0] * vertex1[1] * vertex3[2] + vertex1[0] * vertex2[1] * vertex3[2]) / 6;
                        writer.WriteLine("  facet normal " + normal[0] + " " + normal[1] + " " + normal[2]);
                        writer.WriteLine("    outer loop");
                        writer.WriteLine("      vertex " + vertex1[0] + " " + vertex1[1] + " " + vertex1[2]);
                        writer.WriteLine("      vertex " + vertex2[0] + " " + vertex2[1] + " " + vertex2[2]);
                        writer.WriteLine("      vertex " + vertex3[0] + " " + vertex3[1] + " " + vertex3[2]);
                        writer.WriteLine("    endloop");
                        writer.WriteLine("  endfacet");
                }
                
                Console.WriteLine(sum*1.25);
                Console.ReadLine();
                writer.Close();
            }

        }
    }
}
