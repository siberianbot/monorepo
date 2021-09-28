using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Datascapes.POC.SchemaModels;

namespace Datascapes.POC.SchemaReader
{
    public class DataReader : IDisposable, IAsyncDisposable
    {
        private readonly Stream _stream;
        private readonly Encoding _encoding;

        public DataReader(Stream stream, Encoding encoding)
        {
            _stream = stream;
            _encoding = encoding;
        }

        public async Task<T> ReadAsync<T>()
        {
            return (T) await ReadAsync(typeof(T));
        }
        
        public async Task<object> ReadAsync(Type type)
        {
            if (type == typeof(string))
            {
                int byteLength = await ReadIntAsync();
                return await ReadStringAsync(byteLength);
            }
            else if (type == typeof(int))
            {
                return await ReadIntAsync();
            }
            else if (type == typeof(long))
            {
                return await ReadLongAsync();
            }
            else if (type.IsEnum)
            {
                return await ReadEnumAsync(type);
            }
            else
            {
                return await ReadObjectAsync(type);
            }
        }

        private async Task<object> ReadEnumAsync(Type type)
        {
            Type underlyingType = Enum.GetUnderlyingType(type);

            if (underlyingType == typeof(int))
            {
                return Enum.ToObject(type, await ReadIntAsync());
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private async Task<object> ReadObjectAsync(Type type)
        {
            PropertyInfo[] orderedProps = type.GetProperties()
                .OrderBy(x => x.GetCustomAttribute<OrderAttribute>()?.Idx ?? throw new InvalidOperationException("no order"))
                .ToArray();

            object instance = Activator.CreateInstance(type);
            
            foreach (PropertyInfo prop in orderedProps)
            {
                object value = await ReadAsync(prop.PropertyType);

                prop.SetValue(instance, value);
            }

            return instance;
        }

        private async Task<int> ReadIntAsync()
        {
            byte[] buffer = new byte[sizeof(int)];
            await _stream.ReadAsync(buffer);

            return BitConverter.ToInt32(buffer);
        }

        private async Task<long> ReadLongAsync()
        {
            byte[] buffer = new byte[sizeof(long)];
            await _stream.ReadAsync(buffer);

            return BitConverter.ToInt64(buffer);
        }

        private async Task<string> ReadStringAsync(int byteLength)
        {
            byte[] buffer = new byte[byteLength];
            await _stream.ReadAsync(buffer);

            return _encoding.GetString(buffer);
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