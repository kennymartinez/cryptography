using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public static class RandomNumber
    {
        public static byte[] Generate(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}
