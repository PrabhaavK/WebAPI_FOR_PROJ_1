using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace TuljaBhavani_Theertham.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        private readonly string _secretKey;

        public AuthService(UserRepository userRepository, string secretKey)
        {
            _userRepository = userRepository;
            _secretKey = secretKey;
        }

        public async Task<bool> RegisterUser(User user)
        {
            // Hash the password and set the PasswordHash and PasswordSalt
            using (var hmac = new HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            }
            return await _userRepository.AddUser(user);
        }

        public async Task<string> LoginUser(string username, string password)
        {
            var user = await _userRepository.ValidateUser(username, password);
            if (user == null) return null;

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
