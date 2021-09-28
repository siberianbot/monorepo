using System;

namespace Super8080.Runtime.Models
{
    public sealed class Opcode
    {
        public byte Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Pattern { get; set; }

        public int CycleCount { get; set; }

        public Action Action { get; set; }
    }
}