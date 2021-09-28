namespace Datascapes.Utilities.Helpers
{
    public static class HashHelper
    {
        public static int CalculateHashCode(byte[] byteArray)
        {
            int hash = 13;

            for (int idx = 0; idx < byteArray.Length; idx++)
            {
                hash = unchecked(hash * 7 + byteArray[idx]);
            }

            return hash;
        }
    }
}