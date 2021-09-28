using System.Threading.Tasks;

namespace Asteroids
{
    internal static class Program
    {
        public static Task Main(string[] args)
        {
            Engine engine = new Engine(args);

            return engine.RunAsync();
        }
    }
}