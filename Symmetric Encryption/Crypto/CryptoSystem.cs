
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AdminPanel.Crypto
{
    public class RSACryptoSystem
    {
        private static RSAParameters publicKey;
        private static RSAParameters privateKey;
        private  int size;
        static string CONTAINER_NAME = "MyContainerName";
        public enum KeySizes
        {
            SIZE_512 = 512,
            SIZE_1024 = 1024,
            SIZE_2048 = 2048
        };

        public RSACryptoSystem(int size)
        {
            this.size = size;
            generateKeys(size);
        }

        public static void generateKeys(int size)
        {
            var rsa = new RSACryptoServiceProvider(size);
            rsa.PersistKeyInCsp = false;
            publicKey = rsa.ExportParameters(false);
            privateKey = rsa.ExportParameters(true);
        }

        public byte[] EncryptString(string message)
        {
            return Encrypt(Encoding.UTF8.GetBytes(message), this.size);
        }
        public string ConvertEncryptString(byte[] convert)
        {
            return BitConverter.ToString(convert).Replace("-","");
        }

        public string DecryptString(byte[] message)
        {
            var decrypt = Decrypt(message, this.size);
            return Encoding.UTF8.GetString(decrypt);
        }

        private static byte[] Encrypt(byte[] input, int size)
        {
            byte[] encrypted;
            using (var rsa = new RSACryptoServiceProvider(size))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(publicKey);
                encrypted = rsa.Encrypt(input, false);
            }
            return encrypted;
        }
        private static byte[] Decrypt(byte[] input, int size)
        {
            byte[] decrypted;
            using (var rsa = new RSACryptoServiceProvider(size))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(privateKey);
                decrypted = rsa.Decrypt(input, false);
            }
            return decrypted;
        }
    }
}
