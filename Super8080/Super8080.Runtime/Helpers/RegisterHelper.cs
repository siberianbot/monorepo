namespace Super8080.Runtime.Helpers
{
    public static class RegisterHelper
    {
        public static ushort ToRegisterPair(byte high, byte low)
        {
            return (ushort) (high << 8 + low);
        }

        public static byte GetHigh(ushort registerPair)
        {
            return (byte) (registerPair >> 8);
        }

        public static byte GetLow(ushort registerPair)
        {
            return (byte) registerPair;
        }

        public static bool GetBit(byte register, int num)
        {
            return (register & 1 << num) != 0;
        }

        public static byte SetBit(byte register, int num, bool state)
        {
            byte modifiedRegister = register;
            byte modifiedBit = (byte) (1 << num);

            if (state)
            {
                modifiedRegister |= modifiedBit;
            }
            else
            {
                modifiedRegister &= (byte) ~modifiedBit;
            }

            return modifiedRegister;
        }
    }
}