using System.Security.Cryptography;
using System.Text;

namespace LoginService.Services.Hash
{
    public class HashingServices : IHashingServices
    {
        public string hashing(string str)
        {

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convierte la cadena en una matriz de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str));

                // Convierte los bytes en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }

        }
        public bool verifyHash(string str)
        {
            return false;
        }
    }
}
