using Super8080.Runtime.Helpers;

namespace Super8080.Runtime.Models
{
    public sealed class RegisterSet
    {
        #region Register pairs

        public ushort PSW { get; set; }

        public ushort BC { get; set; }

        public ushort DE { get; set; }

        public ushort HL { get; set; }

        public ushort SP { get; set; }

        public ushort PC { get; set; }

        #endregion

        #region Registers

        public byte A
        {
            get => RegisterHelper.GetHigh(PSW);
            set => PSW = RegisterHelper.ToRegisterPair(value, F);
        }

        public byte F
        {
            get => RegisterHelper.GetLow(PSW);
            set => PSW = RegisterHelper.ToRegisterPair(A, value);
        }

        public byte B
        {
            get => RegisterHelper.GetHigh(BC);
            set => BC = RegisterHelper.ToRegisterPair(value, C);
        }

        public byte C
        {
            get => RegisterHelper.GetLow(BC);
            set => BC = RegisterHelper.ToRegisterPair(B, value);
        }

        public byte D
        {
            get => RegisterHelper.GetHigh(DE);
            set => DE = RegisterHelper.ToRegisterPair(value, E);
        }

        public byte E
        {
            get => RegisterHelper.GetLow(DE);
            set => DE = RegisterHelper.ToRegisterPair(D, value);
        }

        public byte H
        {
            get => RegisterHelper.GetHigh(HL);
            set => HL = RegisterHelper.ToRegisterPair(value, L);
        }

        public byte L
        {
            get => RegisterHelper.GetLow(HL);
            set => HL = RegisterHelper.ToRegisterPair(H, value);
        }

        #endregion

        #region Flags

        public bool Carry
        {
            get => RegisterHelper.GetBit(F, 0);
            set => F = RegisterHelper.SetBit(F, 0, value);
        }

        public bool Parity
        {
            get => RegisterHelper.GetBit(F, 2);
            set => F = RegisterHelper.SetBit(F, 2, value);
        }

        public bool AuxiliaryCarry
        {
            get => RegisterHelper.GetBit(F, 4);
            set => F = RegisterHelper.SetBit(F, 4, value);
        }

        public bool Zero
        {
            get => RegisterHelper.GetBit(F, 6);
            set => F = RegisterHelper.SetBit(F, 6, value);
        }

        public bool Sign
        {
            get => RegisterHelper.GetBit(F, 7);
            set => F = RegisterHelper.SetBit(F, 7, value);
        }

        #endregion
    }
}