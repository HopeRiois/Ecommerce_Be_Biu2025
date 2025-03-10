using System.Security.Cryptography;
using System.Text;

namespace ecommerce_biu.Utils
{
    public class Encryption
    {
        public static string DecryptAES256(string cipherData, string keyString)
        {
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = new byte[16];
            try
            {
                using var aes = Aes.Create();
                aes.Key = key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                using var memoryStream =
                   new MemoryStream(Convert.FromBase64String(cipherData));
                using var cryptoStream =
                       new CryptoStream(memoryStream,
                           aes.CreateDecryptor(key, iv),
                           CryptoStreamMode.Read);
                return new StreamReader(cryptoStream).ReadToEnd();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return "";
            }
        }

        public static string EncryptAES256(string message, string KeyString)
        {
            byte[] Key = ASCIIEncoding.UTF8.GetBytes(KeyString);
            byte[] IV = new byte[16];

            string encrypted = "";
            var rj = Aes.Create();
            rj.Key = Key;
            rj.IV = IV;
            rj.Mode = CipherMode.CBC;

            try
            {
                MemoryStream ms = new();

                using (CryptoStream cs = new(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new(cs))
                    {
                        sw.Write(message);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);

                ms.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return encrypted;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return encrypted;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: {0}", e.Message);
            }
            finally
            {
                rj.Clear();
            }
            return encrypted;
        }

    }
}
