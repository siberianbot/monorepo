using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLogParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                //
            }
        
            string path = @"D:\server-infrastructure\.git\logs\refs\heads\master";

            foreach (string line in File.ReadLines(path))
            {
                Console.WriteLine(line);
            }
        }
    }
}