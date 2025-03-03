﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services;

public static class TokenService
{
    public static JwtSecurityToken CreateToken(List<Claim> authClaiims, IConfiguration configuration)
    {
        var authSingingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

        var token = new JwtSecurityToken(
            issuer: configuration["JWT: ValidIssuer"],
            audience: configuration["JWT: ValidAudience"],
            claims: authClaiims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(authSingingKey, SecurityAlgorithms.HmacSha256));

        return token;
    }
}