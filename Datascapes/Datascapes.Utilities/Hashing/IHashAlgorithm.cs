using System;

namespace Datascapes.Utilities.Hashing
{
    public interface IHashAlgorithm : IDisposable
    {
        Hash Calculate(byte[] data);
    }
}