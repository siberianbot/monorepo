using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Datascapes.POC.SchemaModels;

namespace Datascapes.POC.SchemaWriter
{
    public class DataWriter : IDisposable, IAsyncDisposable
    {
        private readonly Stream _stream;
        private readonly Encoding _encoding;

        public DataWriter(Stream stream, Encoding encoding)
        {
            _stream = stream;
            _encoding = encoding;
        }

        public async Task WriteAsync(object instance)
        {
            switch (instance)
            {
                case string str:
                    await _stream.WriteAsync(BitConverter.GetBytes(_encoding.GetByteCount(str)));
                    await _stream.WriteAsync(_encoding.GetBytes(str));
                    break;
               
                case long l:
                    await _stream.WriteAsync(BitConverter.GetBytes(l));
                    break;
                
                case Enum @enum:
                    await WriteEnumAsync(@enum);
                    break;
                
                default:
                    await WriteObjectAsync(instance);
                    break;
            }
        }

        private async Task WriteEnumAsync(Enum @enum)
        {
            Type underlyingType = Enum.GetUnderlyingType(@enum.GetType());

            if (underlyingType == typeof(int))
            {
                // TODO: cast wtf
                await _stream.WriteAsync(BitConverter.GetBytes((int)(object) @enum));
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private async Task WriteObjectAsync(object instance)
        {
            PropertyInfo[] orderedProps = instance.GetType().GetProperties()
                .OrderBy(x => x.GetCustomAttribute<OrderAttribute>()?.Idx ?? throw new InvalidOperationException("no order"))
                .ToArray();

            foreach (PropertyInfo prop in orderedProps)
            {
                await WriteAsync(prop.GetValue(instance));
            }
        }

        #region Dispose

        public void Dispose()
        {
            _stream?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _stream.DisposeAsync();
        }

        #endregion
    }
}