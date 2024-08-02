using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CalorieTrack.Infrastructure.Authentication.TokenGenerator;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        Debug.WriteLine("start; ");
Debug.WriteLine(user.FirstName);
Debug.WriteLine(user.Email);
Debug.WriteLine(user.GoogleUserId);
Debug.WriteLine(user.ProfileType.ToString());
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Name, user.FirstName ?? ""),
            new(JwtRegisteredClaimNames.Email, user.Email  ?? ""),
            new("id", user.Guid.ToString()),
            new("role", user.ProfileType.ToString()),
        };
Debug.Write(claims);
 
        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
            signingCredentials: credentials
        );
        


        return new JwtSecurityTokenHandler().WriteToken(token);
    }

 
}