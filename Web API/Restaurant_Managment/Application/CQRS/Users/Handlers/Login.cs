using Application.Services;
using Common.Exceptions;
using Common.GlobalResopnses.Generics;
using Common.Security;
using Domain.Entites;
using MediatR;
using Microsoft.Extensions.Configuration;
using Repository.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.CQRS.Users.Handlers;

public class Login
{
    public class LoginRequest : IRequest<ResponseModel<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public sealed class LoginHandler(IUnitOfWork unitOfWork, IConfiguration configuration) : IRequestHandler<LoginRequest, ResponseModel<string>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IConfiguration _configuration = configuration;

        public async Task<ResponseModel<string>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email) ?? throw new BadRequestException("User does not Exists with provided email");

            var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);

            if (hashedPassword != user.PasswordHash) throw new BadRequestException("Wrong Password");

            List<Claim> authClaims = [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone)
                ];

            JwtSecurityToken jwtToken = TokenService.CreateToken(authClaims, configuration);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new ResponseModel<string>
            {
                Data = tokenString,
                Errors = [],
                IsSuccess = true
            };
        }
    }
}