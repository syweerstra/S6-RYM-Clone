using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Business
{
    public static class TokenGenerator
    {
        //TODO: Shouldn't be here
        const string issuer = "https://localhost:11000";
        const string secret = "geheimpje geheimpje2 geheimpje3 geheimpje4 geheimpje 5";
        const double daysUntilExpire = 1;
        public static string CreateToken(IdentityUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("userId", user.Id.ToString()),
                new Claim("Username", user.UserName)
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var signCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                claims: authClaims,
                expires: DateTime.Now.AddDays(daysUntilExpire),
                signingCredentials: signCredentials);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
