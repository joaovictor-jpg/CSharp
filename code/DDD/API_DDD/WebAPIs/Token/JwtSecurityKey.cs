using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPIs.Token
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }

        public static implicit operator JwtSecurityKey(SecurityKey v)
        {
            throw new NotImplementedException();
        }
    }
}
