using System.Threading;
using System.Threading.Tasks;

namespace siberianbot.Tools.Encrypting
{
    public sealed class Encryptor
    {
        public Task EncryptAsync(byte[] data, byte[] key, byte[] pad, CancellationToken token = default)
        {
            ParallelOptions options = new ParallelOptions
            {
                CancellationToken = token
            };

            // It is unnecessary to cancel task if inner work depends on outer
            // cancellation token, so we just use default cancellation token
            // in hope that Parallel.For() will stop when our token will be 
            // cancelled.

            return Task.Run(() => Parallel.For(0, data.Length, options, idx =>
            {
                int keyIdx = idx % key.Length;
                int padIdx = idx % pad.Length;

                data[idx] = (byte) (data[idx] ^ key[keyIdx] ^ pad[padIdx]);
            }), default);
        }
    }
}