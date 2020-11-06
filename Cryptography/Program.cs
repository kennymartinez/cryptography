using System;
using System.Text;

namespace Cryptography
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"Random Number generated ({i}): {Convert.ToBase64String(RandomNumber.Generate(6))}");
            //}

            //RunHash();
            EncryptWithAes();
            Console.ReadLine();
        }

        static void RunHash()
        {
            const string originalMessage = "Original Message to hash";
            const string originalMessage2 = "This is another message to hash";

            Console.WriteLine("Secure HashData Demostration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Original Message 1: {originalMessage}");
            Console.WriteLine($"Original Message 2: {originalMessage2}");
            Console.WriteLine();
            
            var md5HashedMessage = HashData.ComputeHashMd5(Encoding.UTF8.GetBytes(originalMessage));
            var md5HashedMessage2 = HashData.ComputeHashMd5(Encoding.UTF8.GetBytes(originalMessage2));

            var sha1HashedMessage = HashData.ComputeHashSha1(Encoding.UTF8.GetBytes(originalMessage));
            var sha1HashedMessage2 = HashData.ComputeHashSha1(Encoding.UTF8.GetBytes(originalMessage2));

            var sha256HashedMessage = HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(originalMessage));
            var sha256HashedMessage2 = HashData.ComputeHashSha256(Encoding.UTF8.GetBytes(originalMessage2));

            var sha512HashedMessage = HashData.ComputeHashSha512(Encoding.UTF8.GetBytes(originalMessage));
            var sha512HashedMessage2 = HashData.ComputeHashSha512(Encoding.UTF8.GetBytes(originalMessage2));

            Console.WriteLine();
            Console.WriteLine("MD5 Hashes");
            Console.WriteLine($"Message 1 hash: {Convert.ToBase64String(md5HashedMessage)}");
            Console.WriteLine($"Message 2 hash: {Convert.ToBase64String(md5HashedMessage2)}");

            Console.WriteLine();
            Console.WriteLine("SHA1 Hashes");
            Console.WriteLine($"Message 1 hash: {Convert.ToBase64String(sha1HashedMessage)}");
            Console.WriteLine($"Message 2 hash: {Convert.ToBase64String(sha1HashedMessage2)}");

            Console.WriteLine();
            Console.WriteLine("SHA256 Hashes");
            Console.WriteLine($"Message 1 hash: {Convert.ToBase64String(sha256HashedMessage)}");
            Console.WriteLine($"Message 2 hash: {Convert.ToBase64String(sha256HashedMessage2)}");

            Console.WriteLine();
            Console.WriteLine("SHA512 Hashes");
            Console.WriteLine($"Message 1 hash: {Convert.ToBase64String(sha512HashedMessage)}");
            Console.WriteLine($"Message 2 hash: {Convert.ToBase64String(sha512HashedMessage2)}");
        }

        static void EncryptWithAes()
        {
            var aes = new AES();
            var key = aes.GenerateRandomNumber(32);
            var iv = aes.GenerateRandomNumber(16);
            const string original = "Text to encrypt";

            var encrypted = aes.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
            var decrypted = aes.Decrypt(encrypted, key, iv);

            var decryptedMessage = Encoding.UTF8.GetString(decrypted);

            Console.WriteLine("AES Encryption Demonstration in .NET");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted Text = " + decryptedMessage);
        }
    }
}
