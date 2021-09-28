using System;
using System.Security.Cryptography;

namespace siberianbot.Tools.Encrypting
{
    public class PadGenerator : IDisposable
    {
        private readonly RandomNumberGenerator _rng;

        public PadGenerator()
        {
            _rng = RandomNumberGenerator.Create();
        }

        public byte[] Create(int size)
        {
            byte[] pad = new byte[size];

            _rng.GetBytes(pad);

            return pad;
        }

        #region IDisposable
        
        private bool _disposed = false;
        
        ~PadGenerator()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _rng.Dispose();
            _disposed = true;

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}