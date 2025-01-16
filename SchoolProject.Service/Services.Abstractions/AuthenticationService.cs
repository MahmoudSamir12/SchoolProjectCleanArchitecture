using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Service.Services.Abstractions
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        public AuthenticationService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        #region GetJWTToken
        public Task<string> GetJWTToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(nameof(UserClaimModel.UserName), user.UserName),
                new Claim(nameof(UserClaimModel.Email), user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
            };

            #region old code

            //string strKey = _configuration["JWTSettings:Key"]!;
            #region Information about ! symbol
            //The ! symbol is called the null - conditional operator (NCO)or the null -
            //forgiving operator. It tells the compiler that it's safe to access the result
            //of the expression on its left-hand side, even if it might be null.

            //So, !does two things:

            //It performs a null - coalescing operation, similar to ??.If the value is null,
            //    it will return the default value(in this case, the result of the expression on 
            //    its left-hand side).

            //It suppresses any compile-time warnings about potential null reference
            //    exceptions. This means that if you're certain that the configuration key
            //        exists, you can use ! to avoid the compiler complaining about a 
            //    potential null reference exception.

            //However, if you're using .NET Core 8 or later and C# 11 or later, you can use 
            //    the null-forgiving operator !. instead of !. The !. operator is more
            //    explicit and tells the compiler that you're intentionally ignoring potential
            //        null values.

            //string strKey = _configuration["JWTSettings:Key"]!.Value;

            //In this case, Value is a property that returns the actual value associated with
            //    the key.

            //Using! or!. is generally considered safe when you're certain that the key 
            //    exists in the configuration, and it helps prevent unnecessary checks and
            //    null reference exceptions.
            #endregion
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(strKey));
            //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //var jwtToken = new JwtSecurityToken(
            //    issuer: _configuration["JWTSettings:Issuer"],
            //    audience: _configuration["JWTSettings:Audience"],
            //    claims: claims,
            //    expires: DateTime.UtcNow.AddMinutes(2),
            //    signingCredentials: credentials
            //);

            //var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            //return await Task.FromResult(accessToken);
            #endregion

            string strKey = _jwtSettings.Key!;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(strKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credentials
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Task.FromResult(accessToken);
        }
        #endregion
    }
}
