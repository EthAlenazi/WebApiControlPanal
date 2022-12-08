using ControllPanel.Data;
using ControllPanel.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ControllPanel.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private  ApiUser _user;

        public AuthManager(UserManager<ApiUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> ValidateUser(LoginDTO userDTO)//check if is user in our database!
        {
            _user = await _userManager.FindByNameAsync(userDTO.Email); //match with userName then
            return (_user != null && await _userManager.CheckPasswordAsync(_user, userDTO.Password)); //check pass 
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSingingCredentials(); //Return the encrypted Key 
            var claims = await GetClaims(); //Return the users with Each roles for every one of them 
            var token = GenerateTokenOpations(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        private JwtSecurityToken GenerateTokenOpations(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var JWTSetting = _configuration.GetSection("Jwt");
            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(JWTSetting.GetSection("Lifetime").Value));
           
            var token = new JwtSecurityToken(
                issuer: JWTSetting.GetSection("Issuer").Value,//Return Issuer Name 
                claims: claims, //List of users 
                expires: expiration,
                signingCredentials: signingCredentials // Return encrypted Key 
                );

            return token;

        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name,_user.UserName )
            };
            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private SigningCredentials GetSingingCredentials()
        {

            var Key = Environment.GetEnvironmentVariable("KEY");
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

        }
    }
}
