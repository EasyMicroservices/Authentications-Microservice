using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Helpers
{
    public class AuthenticationHelper
    {

        public static async Task<string> HashPassword(string password)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
