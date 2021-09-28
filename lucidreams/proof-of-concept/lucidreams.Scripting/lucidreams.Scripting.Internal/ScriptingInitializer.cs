using System.Runtime.InteropServices;

namespace lucidreams.Scripting.Internal
{
    internal sealed class ScriptingHost
    {
        [UnmanagedCallersOnly]
        public static void Run();
    }

    internal struct ScriptingHostRunArgs
    {
        // TODO
    }
}