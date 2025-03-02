using AuthenticationMicroservice.ApplicationCore.Contracts.Services;
using AuthenticationMicroservice.ApplicationCore.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationMicroservice.Infrastucture.Services
{
    public class JwtTokenService : ITokenService
    {
        private const string JWT_SECURITY_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        public AuthenticationHttpResponse GenerateToken(string userName, int tokenValidMins, IEnumerable<string> roles)
        {       
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidMins);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claims = new List<Claim>() { new Claim(ClaimTypes.Name, userName) };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            
            var claimsIdentity = new ClaimsIdentity(claims);

            var signInCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity, 
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signInCredentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new AuthenticationHttpResponse
            {
                UserName = userName,
                ExpireIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalMinutes,
                Token = tokenString
            };
        }
    }
}
