using Application.CQRS.Users.DTOs;
using Application.Services;
using Application.Services.LogService;
using Common.Exceptions;
using Common.GlobalResopnses.Generics;
using Common.Security;
using Domain.Entites;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using Repository.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.CQRS.Users.Handlers;

public class Login
{
    public class LoginRequest : IRequest<ResponseModel<LoginReponseDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public sealed class LoginHandler(IUnitOfWork unitOfWork, IConfiguration configuration, ILoggerService loggerService) : IRequestHandler<LoginRequest, ResponseModel<LoginReponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ResponseModel<LoginReponseDto>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                loggerService.LogWarning($"User does not Exists with {request.Email} email");
                throw new BadRequestException("User does not Exists with provided email");
            }
            var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);

            if (hashedPassword != user.PasswordHash)
            {
                loggerService.LogWarning("Wrong password");
                throw new BadRequestException("Wrong Password");
            }
            List<Claim> authClaims = [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Role,user.UserRole.ToString())
                ];

            JwtSecurityToken jwtToken = TokenService.CreateToken(authClaims, configuration);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            string refreshTokenString = TokenService.GenerateRefreshToken();

            RefreshToken refreshToken = new()
            {
                Token = refreshTokenString,
                UserId = user.Id,
                ExpirationDate = DateTime.Now.AddDays(Double.Parse(configuration.GetRequiredSection("JWT:RefreshTokenExpirationDays").Value!)),
            };

            await _unitOfWork.RefreshTokenRepository.SaveRefreshToken(refreshToken);
            await _unitOfWork.SaveChanges();

            loggerService.LogInfo($"{request.Email} logged in");
            return new ResponseModel<LoginReponseDto>
            {
                Data = new LoginReponseDto
                {
                    AccessToken = tokenString,
                    RefreshToken = refreshTokenString
                },
                Errors = [],
                IsSuccess = true
            };
        }
    }
}