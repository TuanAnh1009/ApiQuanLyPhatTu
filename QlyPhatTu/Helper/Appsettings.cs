using System.Security.Cryptography;

namespace QlyPhatTu.Helper
{
    public class Appsettings
    {
        private string secretkey = GenerateSecretKey(32);
        public string SecretKey 
        {
            get
            {
                return secretkey;
            }
            set
            {
                secretkey = value;
            }
        }
        private static string GenerateSecretKey(int length)
        {
            var randomBytes = new byte[length];
            using (var ran = RandomNumberGenerator.Create())
            {
                ran.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }
    }
}
