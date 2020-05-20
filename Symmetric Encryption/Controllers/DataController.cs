using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AdminPanel.Crypto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Symmetric_Encryption.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private static byte[] Key;
        private static byte[] IV;
        public DataController()
        {
            using (Aes myAes = Aes.Create())
            {
                Key = myAes.Key;
                IV = myAes.IV;
            }
        }

        [HttpGet("reinitializeKeys")]
        public string reinitializeKeys()
        {
            using (Aes myAes = Aes.Create())
            {
                Key = myAes.Key;
                IV = myAes.IV;
            }
            return "success";
        }

        [HttpGet("getKeys")]
        public string getKeys()
        {
            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("key", Key);
            json.Add("IV", IV);
            return JsonConvert.SerializeObject(json);
        }

        [HttpGet("rsa")]
        public string rsa(string shortMessagetoEncrypt)
        {
            RSACryptoSystem cryptoSystem = new RSACryptoSystem(2048);
            string msg = shortMessagetoEncrypt;
            byte[] encypt = cryptoSystem.EncryptString(msg);
            string decrypt = cryptoSystem.DecryptString(encypt);

            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("data", msg);
            json.Add("encrypt", cryptoSystem.ConvertEncryptString(encypt));
            json.Add("decrypt", decrypt);
            return JsonConvert.SerializeObject(json);
        }
        [HttpGet("aes")]
        public string aes(string messageToEncrypt)
        {
            string msg = messageToEncrypt;

            byte[] encrypted;
            string roundtrip;

            // Encrypt the string to an array of bytes.
            encrypted = AESCryptoSystem.Encrypt(msg, Key, IV);
            // Decrypt the bytes to a string.
            roundtrip = AESCryptoSystem.Decrypt(encrypted, Key, IV);

            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("data", msg);
            json.Add("encrypt", encrypted);
            json.Add("decrypt", roundtrip);
            return JsonConvert.SerializeObject(json);
        }

        [HttpGet("getencrypt")]
        public string getencrypt(string data)
        {
            string msg = data;
            byte[] encrypted;
            // Encrypt the string to an array of bytes.
            encrypted = AESCryptoSystem.Encrypt(msg, Key, IV);

            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("encrypt", encrypted);
            return JsonConvert.SerializeObject(json);
        }
        [HttpGet("getdecrypt")]
        public string getdecrypt(byte[] encryptedMessage)
        {

            byte[] encrypted;
            string roundtrip;
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).

            // Decrypt the string to an array of bytes.
            roundtrip = AESCryptoSystem.Decrypt(encryptedMessage, Key, IV);

            Dictionary<string, object> json = new Dictionary<string, object>();
            json.Add("encrypt", roundtrip);
            return JsonConvert.SerializeObject(json);
        }


    }
}