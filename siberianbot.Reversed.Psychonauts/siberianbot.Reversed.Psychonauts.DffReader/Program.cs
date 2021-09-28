using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace siberianbot.Reversed.Psychonauts.DffReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //           00h - FFFD, magic number;
            //                 === TABLE OF SYMBOLS ===
            //           04h - (possibly) length of symbols table, 4 bytes
            //           08h - (possibly) count of symbols, 4 bytes
            //      0Ch-10Bh - (possibly) table of symbols, (possibly) ASCII?
            //           .....
            //         010Ch - symbols locations, 2 bytes per integer:
            //                   0-3 - first (x, y);
            //                   4-7 - second (x, y);
            //                  8-11 - (possibly) symbol id
            //                 === BITMAP ===
            //          920h - bitmap height, 4 bytes;
            //          924h - bitmap width, 4 bytes;
            //          928h - bitmap.
            
            string path = @"C:\Program Files (x86)\Steam\steamapps\common\Psychonauts\WorkResource\Fonts\bagel_lin.dff";

            using Stream input = File.OpenRead(path);
            using BinaryReader reader = new BinaryReader(input);

            int magic = reader.ReadInt32();
            if (magic != 0x44464646)
            {
                throw new Exception("not a dff");
            }

            int tableSize = reader.ReadInt32();
            int symbolsCount = reader.ReadInt32();

            byte[] table = reader.ReadBytes(tableSize);
            char[] chars = Encoding.ASCII.GetChars(table);

            // read symbols locations
            List<Symbol> symbols = new List<Symbol>();

            for (int i = 0; i < symbolsCount; i++)
            {
                Symbol symbol = new Symbol
                {
                    FirstPoint = new Point
                    {
                        X = reader.ReadInt16(),
                        Y = reader.ReadInt16()
                    },
                    SecondPoint = new Point
                    {
                        X = reader.ReadInt16(),
                        Y = reader.ReadInt16()
                    },
                    Unknown = reader.ReadInt32()
                };

                symbols.Add(symbol);
            }

            int unknown1 = reader.ReadInt32();
            
            // read bitmap sizes and bitmap itself
            // TODO: apply transformations on file: rotate and flip horizontally
            int bitmapHeight = reader.ReadInt32();
            int bitmapWidth = reader.ReadInt32();

            using Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight);
            using Graphics graphics = Graphics.FromImage(bitmap);

            for (int x = 0; x < bitmapWidth; x++)
            {
                for (int y = 0; y < bitmapHeight; y++)
                {
                    int value = reader.ReadByte();
                    Color color = Color.FromArgb(0xFF, value, value, value);

                    bitmap.SetPixel(x, y, color);
                }
            }

            bitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
            
            bitmap.Save("output.bmp");

            using Stream outputStream = File.Create("output.txt");
            using TextWriter outputWriter = new StreamWriter(outputStream);
            
            outputWriter.WriteLine("CHARACTERS:");
            int onLine = 0;
            for (int i = 0; i < symbolsCount; i++)
            {
                char toPrint = !char.IsControl(chars[i]) ? chars[i] : ' ';
                outputWriter.Write($"{i,4}: 0x{table[i]:X2} {toPrint}\t");

                onLine++;
                if (onLine == 4)
                {
                    onLine = 0;
                    outputWriter.WriteLine();
                }
            }

            outputWriter.WriteLine();
            outputWriter.WriteLine("LOCATIONS:");

            for (int i = 0; i < symbols.Count; i++)
            {
                outputWriter.Write($"{i,4} ");
                outputWriter.Write($"({symbols[i].FirstPoint.X,6}; {symbols[i].FirstPoint.Y,6}) ");
                outputWriter.Write($"({symbols[i].SecondPoint.X,6}; {symbols[i].SecondPoint.Y,6}) ");
                outputWriter.WriteLine($"0x{symbols[i].Unknown:X2}");
            }

            outputWriter.Flush();
        }
    }
}