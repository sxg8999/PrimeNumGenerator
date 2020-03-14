
using System.Security.Cryptography;

/**
 *@author Steven Guan
 */

namespace PrimeGen
{
    /// <summary>
    /// This class generates random byte for creating a BigInteger
    /// </summary>
    public static class Random
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        /// <summary>
        /// Returns a byte array of random bytes
        /// </summary>
        /// <param name="numOfByte"></param>
        /// <returns> a byte array of random byte</returns>
        public static byte[] generateBytes(int numOfByte)
        {
            var tmp = new byte[numOfByte];
            rngCsp.GetBytes(tmp);
            return tmp;
        }
    }
}
