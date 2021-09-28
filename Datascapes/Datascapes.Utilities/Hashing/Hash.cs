using System;
using Datascapes.Utilities.Helpers;

namespace Datascapes.Utilities.Hashing
{
    /// <summary>
    /// A struct for storing hash.
    /// </summary>
    public readonly struct Hash : IEquatable<Hash>
    {
        private readonly byte[] _value;
        private readonly int _hashcode;

        public Hash(byte[] value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            _hashcode = HashHelper.CalculateHashCode(_value);
        }

        public Hash(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            _value = Convert.FromHexString(value);
            _hashcode = HashHelper.CalculateHashCode(_value);
        }

        public override string ToString()
        {
            return Convert.ToHexString(_value);
        }

        public override bool Equals(object obj)
        {
            return obj is Hash hash && Equals(hash);
        }

        public override int GetHashCode()
        {
            return _hashcode;
        }

        #region IEquatable<Hash>

        public bool Equals(Hash that)
        {
            if (_value.Length != that._value.Length)
            {
                return false;
            }

            for (int idx = 0; idx < _value.Length; idx++)
            {
                if (_value[idx] != that._value[idx])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}