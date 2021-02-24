using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BridgeApp.Services.Crypto
{
    public sealed class Encryptor
    {
        private string key = "h%76@#fsCw412";
        private readonly Aes _encryptor; 
        public Encryptor(SHA512 encryptor)
        {
            _encryptor = new AesManaged();
        }
        public Task<string> Encrypt(string password)
        {
            _encryptor.KeySize = 128;
            _encryptor.BlockSize = 128;
            _encryptor.Key = Encoding.Unicode.GetBytes(key);
            using (_encryptor.CreateEncryptor())
            {
                using(var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, _encryptor.CreateEncryptor(), CryptoStreamMode.Write ))
                    {
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(password);
                            var encrypted = Encoding.Unicode.GetString(ms.ToArray());
                            return Task.FromResult(encrypted);
                        }
                    }
                }
            }
        }

        public async Task<bool> MatchesEncryption(string password, string encryptedPassword)
        {
            var current = await Encrypt(password);
            return Equals(encryptedPassword, current);
        }
    }
}
