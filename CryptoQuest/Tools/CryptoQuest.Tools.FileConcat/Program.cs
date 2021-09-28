using System;
using System.IO;
using System.Threading.Tasks;

namespace CryptoQuest.Tools.FileConcat
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("specify output file name and at least two files to concatenate");
                
                return;
            }

            await using Stream outputStream = File.Create(args[0]);

            for (int i = 1; i < args.Length; i++)
            {
                await using Stream fileStream = File.OpenRead(args[i]);

                await fileStream.CopyToAsync(outputStream);
            }

            await outputStream.FlushAsync();
        }
    }
}