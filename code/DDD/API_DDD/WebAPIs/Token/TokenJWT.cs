using System.IdentityModel.Tokens.Jwt;

namespace WebAPIs.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken _jwtSecurityToken;

        internal TokenJWT(JwtSecurityToken jwtSecurityToken)
        {
            _jwtSecurityToken = jwtSecurityToken;
        }

        public DateTime ValidTo => _jwtSecurityToken.ValidTo;

        public string value => new JwtSecurityTokenHandler().WriteToken(this._jwtSecurityToken);
    }
}
